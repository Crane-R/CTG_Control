using CTG_Control.crane.form;
using CTG_Control.Crane;
using CTG_Control.Crane.Constant;
using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using CTG_Control.Crane.Service;
using System.Timers;

namespace CTG_Control
{
    public partial class MainForm : Form
    {
        public static DataGridView mainTableData;

        private readonly int ID_INDEX = 0;
        private readonly int SOURCE_PATH_INDEX = 1;
        private readonly int TARGET_PATH_INDEX = 2;
        private readonly int LATELY_DATE_INDEX = 3;

        //倒计时文本
        private readonly string COUNTDOWN_LABEL = "秒后启动同步程序";
        private int COUNTDOWN_TIME = 10;

        private Thread countDownThread;
        private ManualResetEvent countDownChoke = new ManualResetEvent(true);

        public MainForm()
        {

            WindowState = FormWindowState.Minimized;
            //窗体初始化
            StartPosition = FormStartPosition.CenterScreen;
            Text = Constants.PROGRAM_VERSION;

            InitializeComponent();
            mainTableData = mainTable;

            mainNotifyIcon.Text = Constants.PROGRAM_VERSION;

            if (ConfigService.GetValue("isNotify").Equals("1"))
            {
                notification.Checked = true;
                mainNotifyIcon.BalloonTipText = "正在同步";
                //其实此参数已经弃用，具体时间由操作系统控制
                mainNotifyIcon.ShowBalloonTip(2000);
            }
            else
            {
                notification.Checked = false;
            }

            timeJudgeCheckBox.Checked = ConfigService.GetValue("isTimeJudge").Equals("1");

            CheckForIllegalCrossThreadCalls = false;

            //启动同步倒计时
            countDownThread = new(new ThreadStart(() =>
            {
                for (int i = COUNTDOWN_TIME; i >= 0; i--)
                {
                    if (!countDownChoke.WaitOne())
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                    SyCountDownLabel.Text = COUNTDOWN_TIME-- + COUNTDOWN_LABEL;
                }
                SyCountDownLabel.Text = "同步指令已经下达";
                SyExecuteAll();
            }));
            countDownThread.Start();

        }

        internal void MainForm_Load(object sender, EventArgs e)
        {
            //表格数据初始化
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compressItem"></param>
        /// <param name="isOneKey">区分是单独执行还是一键执行</param>
        /// <returns></returns>
        private bool ExecuteCompress(CompressItem compressItem, bool isOneKey, bool isJudgeTime)
        {
            if (CompressService.NotExistsWinRar())
            {
                MessageBox.Show("压缩程序需要依赖WinRAR，但因WinRAR的压缩算法并不开源，故需要您电脑安装WinRAR才能使用此程序");
                return false;
            }

            //时间检测：如果距离上次同步时间少于12h，则不同步
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
                    MessageBox.Show("源路径或目标路径不可为空", "地址为空", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }

            CompressService.CompressRar(compressItem);
            return true;
        }

        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            new AddForm(this).ShowDialog();
        }

        /// <summary>
        /// 单项执行
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
            ExecuteCompress(compressItem, true, false);
            new ProgressService().StartProgress(
                (int)(new FileCountService().FileLengthCount(compressItem.SourcePath) / 10000),
                compressItem.SourcePath + " -> " + compressItem.TargetPath);



        }

        /// <summary>
        /// 程序自动执行压缩方法
        /// </summary>
        private void SyExecuteAll()
        {
            int count = mainTableData.RowCount;
            CompressItem compressItem = new();
            for (int i = 0; i < count; i++)
            {
                compressItem.SourcePath = mainTableData.Rows[i].Cells[SOURCE_PATH_INDEX].Value.ToString() ?? "源路径为空";
                compressItem.TargetPath = mainTableData.Rows[i].Cells[TARGET_PATH_INDEX].Value.ToString() ?? "目标路径为空";
                _ = DateTime.TryParse(mainTableData.Rows[i].Cells[LATELY_DATE_INDEX].Value.ToString(), out DateTime dateTime);
                compressItem.LatelyDate = dateTime;
                compressItem.Id = Convert.ToInt32(mainTableData.Rows[i].Cells[ID_INDEX].Value.ToString());
                ExecuteCompress(compressItem, false, true);
            }
            SyCountDownLabel.Text = "自动同步已经完成";
        }

        private void AllExecuteBtn_Click(object sender, EventArgs e)
        {
            int count = mainTableData.RowCount;
            bool allTrue = true;
            List<CompressItem> compressItems = new List<CompressItem>();
            long fileCount = 0;
            FileCountService fileCountService = new FileCountService();
            for (int i = 0; i < count; i++)
            {
                CompressItem compressItem = new();
                compressItem.SourcePath = mainTableData.Rows[i].Cells[SOURCE_PATH_INDEX].Value.ToString() ?? "源路径为空";
                compressItem.TargetPath = mainTableData.Rows[i].Cells[TARGET_PATH_INDEX].Value.ToString() ?? "目标路径为空";
                _ = DateTime.TryParse(mainTableData.Rows[i].Cells[LATELY_DATE_INDEX].Value.ToString(), out DateTime dateTime);
                compressItem.LatelyDate = dateTime;
                compressItem.Id = Convert.ToInt32(mainTableData.Rows[i].Cells[ID_INDEX].Value.ToString());
                fileCount += fileCountService.FileLengthCount(compressItem.SourcePath);
                compressItems.Add(compressItem);


            }
            new ProgressService().StartProgress(fileCount, "一键执行");
            for (int i = 0; i < count; i++)
            {
                if (!ExecuteCompress(compressItems[i], false, true))
                {
                    MessageBox.Show("执行过程中遇到目录为空的错误，执行停止。\r\n" + (i + 1) + "行之前（不含" + (i + 1) + "行）已执行完成",
                        "地址为空", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allTrue = false;
                }
            }

            if (allTrue)
            {
                MessageBox.Show("任务压缩执行完成");
            }
            MainFormRefresh();
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
        /// 右键删除当前行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCurrent_Click(object sender, EventArgs e)
        {
            DataDao.DeleteByIndex(mainTableData.CurrentRow.Index);
            MainFormRefresh();
        }

        public void MainFormRefresh()
        {
            MainForm_Load(null, null);
        }

        private void mainTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mainContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消"关闭窗口"事件
                e.Cancel = true;
                //使关闭时窗口向右下角缩小的效果
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
            this.StopSyBtn.Enabled = false;
        }

        /// <summary>
        /// 检测修改是否通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notification_CheckedChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("isNotify", notification.Checked ? "1" : "0");
        }

        /// <summary>
        /// 时间检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeJudgeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("isTimeJudge", timeJudgeCheckBox.Checked ? "1" : "0");
        }

    }
}