using CTG_Control.crane.form;
using CTG_Control.Crane.Constant;
using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using CTG_Control.Crane.Service;
using System.IO;
using System.Windows.Forms;

namespace CTG_Control
{
    public partial class MainForm : Form
    {
        public static DataGridView mainTableData;

        private readonly int ID_INDEX = 0;
        private readonly int SOURCE_PATH_INDEX = 1;
        private readonly int TARGET_PATH_INDEX = 2;
        private readonly int LATELY_DATE_INDEX = 3;

        //����ʱ�ı�
        private readonly string COUNTDOWN_LABEL = "�������ͬ������";
        private int COUNTDOWN_TIME = ConfigService.GetValueByInt("countDownTime");
        private int SHUT_DOWN_TIME = ConfigService.GetValueByInt("shutDownTime");

        private Thread countDownThread;
        private ManualResetEvent countDownChoke = new ManualResetEvent(true);

        public MainForm()
        {

            WindowState = FormWindowState.Minimized;
            //�����ʼ��
            StartPosition = FormStartPosition.CenterScreen;
            Text = Constants.PROGRAM_VERSION;

            InitializeComponent();
            mainTableData = mainTable;

            mainNotifyIcon.Text = Constants.PROGRAM_VERSION;

            if (ConfigService.GetValue("isNotify").Equals("1"))
            {
                notification.Checked = true;
                mainNotifyIcon.BalloonTipText = ConfigService.GetValue("notificationText");
                //��ʵ�˲����Ѿ����ã�����ʱ���ɲ���ϵͳ����
                mainNotifyIcon.ShowBalloonTip(2000);
            }
            else
            {
                notification.Checked = false;
            }

            timeJudgeCheckBox.Checked = ConfigService.GetValue("isTimeJudge").Equals("1");

            //�ж���������
            if (ConfigService.GetValueByBool("isStartUp"))
            {
                new StartUpService().OpenStartUp();
            }
            else
            {
                new StartUpService().CloseStartUp();
            }

            CheckForIllegalCrossThreadCalls = false;

            //����ͬ������ʱ
            countDownThread = new(new ThreadStart(() =>
            {
                for (int i = COUNTDOWN_TIME; i >= 0; i--)
                {
                    countDownChoke.WaitOne();
                    SyCountDownLabel.Text = COUNTDOWN_TIME-- + COUNTDOWN_LABEL;
                    Thread.Sleep(1000);
                }
                SyCountDownLabel.Text = "ͬ��ָ���Ѿ��´�";
                SyExecuteAll();
            }));
            countDownThread.Start();

        }

        public void init()
        {
            //https://blog.csdn.net/cxwl3sxl/article/details/8807763
            this.BeginInvoke(new Action(() =>
            {
                //������ݳ�ʼ��
                List<CompressItem> compassItems = DataDao.ReadAll();
                mainTableData.Rows.Clear();
                compassItems.ForEach(item =>
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(mainTableData);
                    row.Cells[SOURCE_PATH_INDEX].Value = item.SourcePath;
                    row.Cells[TARGET_PATH_INDEX].Value = item.TargetPath;
                    row.Cells[LATELY_DATE_INDEX].Value = item.LatelyDate;
                    row.Cells[ID_INDEX].Value = item.Id;
                    mainTableData.Rows.Add(row);
                });
            }));
        }

        internal async void MainForm_Load(object sender, EventArgs e)
        {
            init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compressItem"></param>
        /// <param name="isOneKey">�����ǵ���ִ�л���һ��ִ��</param>
        /// <returns></returns>
        private bool ExecuteCompress(CompressItem compressItem, bool isOneKey, bool isJudgeTime)
        {
            if (CompressService.NotExistsWinRar())
            {
                MessageBox.Show("ѹ��������Ҫ����WinRAR������WinRAR��ѹ���㷨������Դ������Ҫ�����԰�װWinRAR����ʹ�ô˳���");
                return false;
            }

            //ʱ���⣺��������ϴ�ͬ��ʱ������12h����ͬ��
            if (ConfigService.GetValue("isTimeJudge").Equals("1")
                && isJudgeTime
                && DateTime.Now.Subtract(compressItem.LatelyDate).TotalHours < 12)
            {
                return false;
            }

            if (compressItem.SourcePath is null || compressItem.TargetPath is null)
            {
                if (!isOneKey)
                {
                    MessageBox.Show("Դ·����Ŀ��·������Ϊ��", "��ַΪ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }

            //��ʼִ��ǰ���ð�ť
            controlFunction(false);

            CompressService.CompressRar(compressItem);
            controlFunction(true);
            return true;
        }

        private void controlFunction(bool isAble)
        {
            addBtn.Enabled = isAble;
            AllExecuteBtn.Enabled = isAble;
            contextMenuMain.Enabled = isAble;
            sfxCheckBox.Enabled = isAble;
            isStartUpCheckBox.Enabled = isAble;
            timeJudgeCheckBox.Enabled = isAble;
            notification.Enabled = isAble;
            StopSyBtn.Enabled = isAble;
        }

        /// <summary>
        /// �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            new AddForm(this).ShowDialog();
        }

        /// <summary>
        /// ����ִ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteBtn_Click(object sender, EventArgs e)
        {
            int index = mainTableData.CurrentRow.Index;
            DataGridViewRow dataGridViewRow = mainTableData.Rows[index];
            _ = DateTime.TryParse(dataGridViewRow.Cells[LATELY_DATE_INDEX].Value.ToString(), out DateTime dateTime);
            CompressItem compressItem = new CompressItem(
                dataGridViewRow.Cells[SOURCE_PATH_INDEX].Value.ToString(),
                dataGridViewRow.Cells[TARGET_PATH_INDEX].Value.ToString(),
                dateTime,
                Convert.ToInt32(dataGridViewRow.Cells[0].Value.ToString())
            );
            new ProgressService().StartProgress(new FileCountService().FileLengthCount(compressItem.SourcePath), compressItem);
            ExecuteCompress(compressItem, true, false);
            init();
        }

        /// <summary>
        /// �����Զ�ִ��ѹ������
        /// </summary>
        private void SyExecuteAll()
        {
            int count = mainTableData.RowCount;
            CompressItem compressItem = new();
            for (int i = 0; i < count; i++)
            {
                compressItem.SourcePath = mainTableData.Rows[i].Cells[SOURCE_PATH_INDEX].Value.ToString() ?? "Դ·��Ϊ��";
                compressItem.TargetPath = mainTableData.Rows[i].Cells[TARGET_PATH_INDEX].Value.ToString() ?? "Ŀ��·��Ϊ��";
                _ = DateTime.TryParse(mainTableData.Rows[i].Cells[LATELY_DATE_INDEX].Value.ToString(), out DateTime dateTime);
                compressItem.LatelyDate = dateTime;
                compressItem.Id = Convert.ToInt32(mainTableData.Rows[i].Cells[ID_INDEX].Value.ToString());
                ExecuteCompress(compressItem, false, true);
            }
            init();
            try
            {
                Thread shutdownThread = new(new ThreadStart(() =>
                {
                    for (int i = SHUT_DOWN_TIME; i >= 0; i--)
                    {
                        SyCountDownLabel.Text = "�Զ�ͬ���Ѿ���ɣ�" + i + "����������";
                        Thread.Sleep(1000);
                    }
                    System.Environment.Exit(0);
                }));
                shutdownThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void AllExecuteBtn_Click(object sender, EventArgs e)
        {
            int count = mainTableData.RowCount;
            List<CompressItem> compressItems = new List<CompressItem>();
            long fileCount = 0;
            FileCountService fileCountService = new FileCountService();
            for (int i = 0; i < count; i++)
            {
                CompressItem compressItem = new();
                compressItem.SourcePath = mainTableData.Rows[i].Cells[SOURCE_PATH_INDEX].Value.ToString() ?? "Դ·��Ϊ��";
                compressItem.TargetPath = mainTableData.Rows[i].Cells[TARGET_PATH_INDEX].Value.ToString() ?? "Ŀ��·��Ϊ��";
                _ = DateTime.TryParse(mainTableData.Rows[i].Cells[LATELY_DATE_INDEX].Value.ToString(), out DateTime dateTime);
                compressItem.LatelyDate = dateTime;
                compressItem.Id = Convert.ToInt32(mainTableData.Rows[i].Cells[ID_INDEX].Value.ToString());
                fileCount += fileCountService.FileLengthCount(compressItem.SourcePath);
                compressItems.Add(compressItem);
            }
            new ProgressService().StartProgress(fileCount, "һ��ִ��");
            for (int i = 0; i < count; i++)
            {
                ExecuteCompress(compressItems[i], false, true);
            }
            MessageBox.Show("����ѹ��ִ�����");
            init();
        }

        private void MainTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > 0)
            {
                if (mainTableData.Rows[e.RowIndex].Selected == false)
                {
                    mainTableData.ClearSelection();
                    mainTableData.Rows[e.RowIndex].Selected = true;
                }
                contextMenuMain.Show(MousePosition.X, MousePosition.Y);
            }
        }

        /// <summary>
        /// �Ҽ�ɾ����ǰ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCurrent_Click(object sender, EventArgs e)
        {
            DataDao.DeleteByIndex(mainTableData.CurrentRow.Index);
            init();
        }

        private void mainTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mainContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ע���жϹر��¼�reason��Դ�ڴ��尴ť�������ò˵��˳�ʱ�޷��˳�!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //ȡ��"�رմ���"�¼�
                e.Cancel = true;
                //ʹ�ر�ʱ���������½���С��Ч��
                WindowState = FormWindowState.Minimized;
            }
        }

        private void mainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = WindowState == FormWindowState.Minimized ?
                FormWindowState.Normal : FormWindowState.Minimized;
        }

        private void MinimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MaximalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainNotifyIcon.Visible = false;
            Close();
            Dispose();
            Environment.Exit(Environment.ExitCode);
        }

        private void mainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = WindowState == FormWindowState.Minimized ?
                FormWindowState.Normal : FormWindowState.Minimized;
        }

        private void StopSyBtn_Click(object sender, EventArgs e)
        {
            countDownChoke.Reset();
            SyCountDownLabel.Text = "�Զ�ͬ���ѱ��սᣬ�´�������ԭ";
            this.StopSyBtn.Enabled = false;
            StopSyBtn.Hide();
        }

        /// <summary>
        /// ����޸��Ƿ�֪ͨ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notification_CheckedChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("isNotify", notification.Checked ? "1" : "0");
        }

        /// <summary>
        /// ʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeJudgeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("isTimeJudge", timeJudgeCheckBox.Checked ? "1" : "0");
        }

        private void isStartUpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("isStartUp", isStartUpCheckBox.Checked ? "1" : "0");
        }

        private void sfxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("sfx", sfxCheckBox.Checked ? "1" : "0");
        }

        /// <summary>
        /// ��ԭ�˵�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreItem_Click(object sender, EventArgs e)
        {
            if (restoreItem.DropDownItems.Count == 0)
            {
                MessageBox.Show("����û�п��Ի�ԭ���ļ�");
                return;
            }
            restoreSecondMenuClick(null, null);
        }

        /// <summary>
        /// ��̬���ض����˵�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreItem_MouseHover(object sender, EventArgs e)
        {
            List<ToolStripMenuItem> toolStripMenuItems = new List<ToolStripMenuItem>();
            DataGridViewRow currentRow = mainTableData.Rows[mainTableData.CurrentRow.Index];
            string[] files = Directory.GetFiles(currentRow.Cells[TARGET_PATH_INDEX].Value.ToString());
            int len = files.Length;
            restoreItem.DropDownItems.Clear();
            for (int i = 0; i < len; i++)
            {
                ToolStripMenuItem menu_item = new ToolStripMenuItem();
                if (!files[i].ToString().EndsWith(".rar"))
                {
                    continue;
                }
                menu_item.Name = files[i].ToString();
                menu_item.Text = files[i].ToString();
                menu_item.Click += restoreSecondMenuClick;
                restoreItem.DropDownItems.Add(menu_item);
            }
        }

        private void restoreSecondMenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender != null ? (ToolStripMenuItem)sender : (ToolStripMenuItem)restoreItem.DropDownItems[0];
            string rarFileName = item.Text;
            DataGridViewRow currentRow = mainTableData.Rows[mainTableData.CurrentRow.Index];
            string sourceDir = currentRow.Cells[SOURCE_PATH_INDEX].Value.ToString();
            DirectoryInfo directory = new DirectoryInfo(sourceDir);
            DirectoryInfo? parentDir = directory.Parent;
            directory.Delete(true);
            new ProgressService().StartProgress(new FileCountService().FileLengthCount(rarFileName), "�ԭִ��");
            CompressService.DeCompressRar(rarFileName, parentDir.FullName);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}