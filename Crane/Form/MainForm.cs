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

        private readonly int ID_INDEX = 0;
        private readonly int SOURCE_PATH_INDEX = 1;
        private readonly int TARGET_PATH_INDEX = 2;
        private readonly int LATELY_DATE_INDEX = 3;

        public MainForm()
        {
            //�����ʼ��
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = Constants.PROGRAM_VERSION;
            InitializeComponent();
            mainTableData = mainTable;
        }

        internal void MainForm_Load(object sender, EventArgs e)
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

            //AllExecuteBtn_Click(null,null);
        }

        private void ExecuteBtn_Click(object sender, EventArgs e)
        {
            if (CompressService.NotExistsWinRar())
            {
                MessageBox.Show("ѹ��������Ҫ����WinRAR������WinRAR��ѹ���㷨������Դ������Ҫ�����԰�װWinRAR����ʹ�ô˳���");
            }

            int index = mainTableData.CurrentRow.Index;
            DataGridViewRow dataGridViewRow = mainTableData.Rows[index];
            _ = DateTime.TryParse(dataGridViewRow.Cells[LATELY_DATE_INDEX].Value.ToString(), out DateTime dateTime);
            CompressItem compressItem = new CompressItem(
                dataGridViewRow.Cells[SOURCE_PATH_INDEX].Value.ToString(),
                dataGridViewRow.Cells[TARGET_PATH_INDEX].Value.ToString(),
                dateTime,
                Convert.ToInt32(dataGridViewRow.Cells[0].Value.ToString())
            );
            bool result = ExecuteCompress(compressItem, false);
            if (result)
            {
                MainFormRefresh();
                MessageBox.Show("ִ�����");
            }
        }

        private bool ExecuteCompress(CompressItem compressItem, bool isOneKey)
        {
            //ʱ���⣺��������ϴ�ͬ��ʱ������12h����ͬ��
            if (DateTime.Now.Subtract(compressItem.LatelyDate).TotalHours < 12)
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
            //TODO�������޷�����object����toStringΪ�յ��������ʱ���������ַ���
            string sourcePath = compressItem.SourcePath;
            string targetPath = compressItem.TargetPath +
              "\\" + sourcePath.Substring(sourcePath.LastIndexOf("\\") + 1) + ".rar";
            CompressService.CompressRar(sourcePath, targetPath);
            //ִ�����ѹ�����������
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
                compressItem.SourcePath = mainTableData.Rows[i].Cells[SOURCE_PATH_INDEX].Value.ToString() ?? "Դ·��Ϊ��";
                compressItem.TargetPath = mainTableData.Rows[i].Cells[TARGET_PATH_INDEX].Value.ToString() ?? "Ŀ��·��Ϊ��";
                _ = DateTime.TryParse(mainTableData.Rows[i].Cells[LATELY_DATE_INDEX].Value.ToString(), out DateTime dateTime);
                compressItem.LatelyDate = dateTime;
                compressItem.Id = Convert.ToInt32(mainTableData.Rows[i].Cells[ID_INDEX].Value.ToString());
                if (!ExecuteCompress(compressItem, true))
                {
                    MessageBox.Show("ִ�й���������Ŀ¼Ϊ�յĴ���ִ��ֹͣ��\r\n" + (i + 1) + "��֮ǰ������" + (i + 1) + "�У���ִ�����",
                        "��ַΪ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allTrue = false;
                }
            }
            if (allTrue)
            {
                MainFormRefresh();
                MessageBox.Show("����ѹ��ִ�����");
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