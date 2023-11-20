using CTG_Control.crane.form;
using CTG_Control.Crane.Constant;
using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using CTG_Control.Crane.Service;

namespace CTG_Control
{
    public partial class MainForm : Form
    {
        public static DataGridView mainTableData;

        public MainForm()
        {
            //窗体初始化
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = Constants.PROGRAM_VERSION;
            InitializeComponent();
            mainTableData = mainTable;
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
                row.Cells[0].Value = item.SourcePath;
                row.Cells[1].Value = item.TargetPath;
                row.Cells[2].Value = item.LatelyDate;
                row.Cells[3].Value = item.Id;
                mainTableData.Rows.Add(row);
            });

            //AllExecuteBtn_Click(null,null);
        }

        private void ExecuteBtn_Click(object sender, EventArgs e)
        {
            if (CompressService.NotExistsWinRar())
            {
                MessageBox.Show("压缩程序需要依赖WinRAR，但因WinRAR的压缩算法并不开源，故需要您电脑安装WinRAR才能使用此程序");
            }

            int index = mainTableData.CurrentRow.Index;
            DataGridViewRow dataGridViewRow = mainTableData.Rows[index];
            _ = DateTime.TryParse(dataGridViewRow.Cells[2].Value.ToString(), out DateTime dateTime);
            CompressItem compressItem = new CompressItem(
                dataGridViewRow.Cells[0].Value.ToString(),
                dataGridViewRow.Cells[1].Value.ToString(),
                dateTime,
                IdService.GenerateId()
            );
            bool result = ExecuteCompress(compressItem, false);
            if (result)
            {
                MainFormRefresh();
                MessageBox.Show("执行完毕");
            }
        }

        private bool ExecuteCompress(CompressItem compressItem, bool isOneKey)
        {
            //时间检测：如果距离上次同步时间少于12h，则不同步
            if (DateTime.Now.Subtract(compressItem.LatelyDate).TotalHours < 12)
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
            //TODO：这里无法处理object调用toString为空的情况，暂时返回特殊字符串
            string sourcePath = compressItem.SourcePath;
            string targetPath = compressItem.TargetPath +
              "\\" + sourcePath.Substring(sourcePath.LastIndexOf("\\") + 1) + ".rar";
            CompressService.CompressRar(sourcePath, targetPath);
            //执行完毕压缩后更新日期
            compressItem.LatelyDate = DateTime.Now;
            DataDao.UpdateOne(compressItem);
            return true;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            new AddForm(this).ShowDialog();
        }

        private void AllExecuteBtn_Click(object sender, EventArgs e)
        {
            int count = mainTableData.RowCount;
            bool allTrue = true;
            CompressItem compressItem = new();
            for (int i = 0; i < count; i++)
            {
                compressItem.SourcePath = mainTableData.Rows[i].Cells[0].Value.ToString() ?? "源路径为空";
                compressItem.TargetPath = mainTableData.Rows[i].Cells[1].Value.ToString() ?? "目标路径为空";
                _ = DateTime.TryParse(mainTableData.Rows[i].Cells[1].Value.ToString(), out DateTime dateTime);
                compressItem.LatelyDate = dateTime;
                if (!ExecuteCompress(compressItem, true))
                {
                    MessageBox.Show("执行过程中遇到目录为空的错误，执行停止。\r\n" + (i + 1) + "行之前（不含" + (i + 1) + "行）已执行完成",
                        "地址为空", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allTrue = false;
                }
            }
            if (allTrue)
            {
                MainFormRefresh();
                MessageBox.Show("任务压缩执行完成");
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
    }
}