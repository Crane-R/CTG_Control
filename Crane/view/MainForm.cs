using CTG_Control.crane.form;
using CTG_Control.Crane.Constant;
using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using CTG_Control.Crane.Service;
using CTG_Control.Crane.view;

namespace CTG_Control
{
    public partial class MainForm : Form
    {
        public static DataGridView? mainTableData;

        private readonly int ID_INDEX = 0;
        private readonly int MARK_NAME_INDEX = 1;
        private readonly int SOURCE_PATH_INDEX = 2;
        private readonly int IS_AUTO_INDEX = 3;

        //����ʱ�ı�
        private readonly string COUNTDOWN_LABEL = "�������ͬ������";
        private int COUNTDOWN_TIME = ConfigService.GetValueByInt("countDownTime");
        private int SHUT_DOWN_TIME = ConfigService.GetValueByInt("shutDownTime");

        private Thread countDownThread;
        private ManualResetEvent countDownChoke = new ManualResetEvent(true);

        public MainForm()
        {
            //�����ʼ��
            WindowState = FormWindowState.Minimized;
            StartPosition = FormStartPosition.CenterScreen;
            Text = Constants.PROGRAM_VERSION;

            InitializeComponent();
            mainTableData = mainTable;

            mainNotifyIcon.Text = Constants.PROGRAM_VERSION;

            CheckForIllegalCrossThreadCalls = false;

            //����ͬ������ʱ
            SyCountDownLabel.Text = COUNTDOWN_TIME + COUNTDOWN_LABEL;
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

        /// <summary>
        /// ������ݳ�ʼ��
        /// </summary>
        public void Init()
        {
            //https://blog.csdn.net/cxwl3sxl/article/details/8807763
            this.BeginInvoke(new Action(() =>
            {
                //������ݳ�ʼ��
                List<CompressItem> compassItems = DataDao.ReadAll();
                mainTableData.Rows.Clear();
                FileCountService fileCountService = new FileCountService();
                long sourceSum = 0;
                double totalBackTime = 0;
                compassItems.ForEach(item =>
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(mainTableData);
                    row.Cells[ID_INDEX].Value = item.Id;
                    row.Cells[MARK_NAME_INDEX].Value = item.MarkName;
                    row.Cells[SOURCE_PATH_INDEX].Value = item.SourcePath;
                    row.Cells[IS_AUTO_INDEX].Value = item.IsAutoBack ? "��" : "��";
                    mainTableData.Rows.Add(row);
                    //����ܺ�ʱ��
                    //sourceSum += fileCountService.FileLengthCount(item.SourcePath);
                    totalBackTime += item.LastBackPast;
                });
                //TotalItemsSize.Text = fileCountService.FormatFileCount(sourceSum);
                TotalLastPast.Text = totalBackTime.ToString("0.000");
                backLocationInput.Text = ConfigService.GetValue("DefaultTargetPath");
            }));
        }

        internal async void MainForm_Load(object sender, EventArgs e)
        {
            Init();
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
                MessageBox.Show("������Ҫ����WinRAR�����Ȱ�װ");
                return false;
            }

            //ʱ����
            if (ConfigService.GetValue("isTimeJudge").Equals("1")
                && isJudgeTime
                && DateTime.Now.Subtract(compressItem.LatelyDate).TotalHours < compressItem.BackInterval)
            {
                return false;
            }

            if (compressItem.SourcePath is null)
            {
                if (!isOneKey)
                {
                    MessageBox.Show("Դ·������Ϊ��", "��ַΪ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }

            //��ʼִ��ǰ���ð�ť
            string text = SyCountDownLabel.Text;
            SyCountDownLabel.Text = "����ִ���С���";
            ControlFunction(false);

            //��ʼ��ʱ
            DateTime startTime = DateTime.Now;
            CompressService.CompressRar(compressItem);
            compressItem.LatelyDate = DateTime.Now;
            //��ʱ����
            compressItem.LastBackPast = Convert.ToDouble(DateTime.Now.Subtract(startTime).TotalMinutes);
            DataDao.UpdateOne(compressItem);

            SyCountDownLabel.Text = text;
            ControlFunction(true);
            return true;
        }

        private void ControlFunction(bool isAble)
        {
            contextMenuMain.Enabled = isAble;
            StopSyBtn.Enabled = isAble;
            backLocationLock.Enabled = isAble;
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
            CompressItem compressItem = DataDao.SelectById(Convert.ToInt32(dataGridViewRow.Cells[ID_INDEX].Value.ToString()));
            ExecuteCompress(compressItem, true, false);
            Init();
        }

        private int GetCurrentyRowId()
        {
            int currentRow = mainTableData.CurrentRow.Index;
            return Convert.ToInt32(mainTableData.Rows[currentRow].Cells[ID_INDEX].Value.ToString());
        }

        /// <summary>
        /// �����Զ�ִ��ѹ������
        /// </summary>
        private void SyExecuteAll()
        {
            int count = mainTableData.RowCount;
            CompressItem compressItem = new();
            DeleteService deleteService = new DeleteService();
            for (int i = 0; i < count; i++)
            {
                compressItem = DataDao.SelectById(Convert.ToInt32(mainTableData.Rows[i].Cells[ID_INDEX].Value.ToString()));
                if (!compressItem.IsAutoBack)
                {
                    continue;
                }
                ExecuteCompress(compressItem, false, true);

                //�Զ����ɾ��
                string sourcePath = compressItem.SourcePath;
                deleteService.AutoJudgeDelete(ConfigService.GetValue("DefaultTargetPath") + "\\" + sourcePath.Substring(sourcePath.LastIndexOf("\\") + 1), 72);
            }
            Init();

            try
            {
                Thread shutdownThread = new(new ThreadStart(() =>
                {
                    for (int i = SHUT_DOWN_TIME; i >= 0; i--)
                    {
                        SyCountDownLabel.Text = "�Զ�ͬ���Ѿ���ɣ�" + i + "����������";
                        Thread.Sleep(1000);
                    }
                    Environment.Exit(0);
                }));
                shutdownThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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
            Init();
        }

        private void mainTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ע���жϹر��¼�reason��Դ�ڴ��尴ť�������ò˵��˳�ʱ�޷��˳�!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                System.Environment.Exit(0);
            }
        }

        private void mainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = WindowState == FormWindowState.Minimized ?
                FormWindowState.Normal : FormWindowState.Minimized;
        }

        /// <summary>
        /// ��ֹ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopSyBtn_Click(object sender, EventArgs e)
        {
            countDownChoke.Reset();
            SyCountDownLabel.Text = "�Զ�ͬ���ѱ���ֹ";
            this.StopSyBtn.Enabled = false;
            StopSyBtn.Hide();
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
            string sourcePath = currentRow.Cells[SOURCE_PATH_INDEX].Value.ToString();
            string targetPath = ConfigService.GetValue("DefaultTargetPath") + "\\"
               + sourcePath.Substring(sourcePath.LastIndexOf("\\") + 1);
            if (targetPath.Contains('.'))
            {
                targetPath = targetPath.Split(".")[0];
            }
            Directory.CreateDirectory(targetPath);
            string[] files = Directory.GetFiles(targetPath);
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
            if ("".Equals(directory.Extension))
            {
                directory.Delete(true);
            }
            else
            {
                File.Delete(directory.FullName);
            }
            CompressService.DeCompressRar(rarFileName, parentDir.FullName);
        }

        /// <summary>
        /// չʾ����ҳ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == IS_AUTO_INDEX)
            {
                new DetailMore(GetCurrentyRowId(), this).ShowDialog();
            }
        }

        private void backLocationLock_Click(object sender, EventArgs e)
        {
            if (!backLocationInput.Enabled)
            {
                backLocationInput.Enabled = true;
                backLocationLock.Text = "��������·��";
            }
            else
            {
                backLocationInput.Enabled = false;
                backLocationLock.Text = "��������·��";
            }
        }

        private void backLocationInput_Click(object sender, EventArgs e)
        {
            if (chooseBackLocation.ShowDialog() == DialogResult.OK)
            {
                backLocationInput.Text = chooseBackLocation.SelectedPath;
            }
        }

        private void settingItem_Click(object sender, EventArgs e)
        {
            new SettingForm().ShowDialog();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            if ("".Equals(ConfigService.GetValue("DefaultTargetPath").ToString()))
            {
                MessageBox.Show("����ѡ�񱸷ݿ�λ��");
                return;
            }
            new AddForm(this).ShowDialog();
        }

        private void allExecute_Click(object sender, EventArgs e)
        {
            int count = mainTableData.RowCount;
            List<CompressItem> compressItems = new List<CompressItem>();
            for (int i = 0; i < count; i++)
            {
                CompressItem compressItem = DataDao.SelectById(Convert.ToInt32(mainTableData.Rows[i].Cells[ID_INDEX].Value.ToString()));
                compressItems.Add(compressItem);
            }
            for (int i = 0; i < count; i++)
            {
                ExecuteCompress(compressItems[i], false, true);
            }
            MessageBox.Show("����ѹ��ִ�����");
            Init();
        }

        private void aboutItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void backLocationInput_TextChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("DefaultTargetPath", backLocationInput.Text);
        }
    }
}