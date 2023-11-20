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
            List<CompressItem> compassItems = AllDataDao.ReadAll();
            mainTableData.Rows.Clear();
            compassItems.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(mainTableData);
                row.Cells[0].Value = item.SourcePath;
                row.Cells[1].Value = item.TargetPath;
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
            bool result = ExecuteCompress(dataGridViewRow.Cells[0].Value, dataGridViewRow.Cells[1].Value, false);
            if (result)
            {
                MessageBox.Show("执行完毕");
            }
        }

        private bool ExecuteCompress(object sourcePathValue, object targetPathValue, bool isOneKey)
        {
            if (sourcePathValue is null || targetPathValue is null)
            {
                if (!isOneKey)
                {
                    MessageBox.Show("源路径或目标路径不可为空", "地址为空", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            //TODO：这里无法处理object调用toString为空的情况，暂时返回特殊字符串
            string sourcePath = sourcePathValue.ToString() ?? "ToString is null";
            string targetPath = targetPathValue.ToString() +
              "\\" + sourcePath.Substring(sourcePath.LastIndexOf("\\") + 1) + ".rar";
            CompressService.CompressRar(sourcePath, targetPath);
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
            for (int i = 0; i < count; i++)
            {
                if (!ExecuteCompress(mainTableData.Rows[i].Cells[0].Value, mainTableData.Rows[i].Cells[1].Value, true))
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
            int index = mainTableData.CurrentRow.Index;
            List<CompressItem> compressItems = AllDataDao.ReadAll();
            compressItems.RemoveAt(index);
            AllDataDao.WriteAll(compressItems);
            MainForm_Load(null, null);
        }

        private void mainTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}