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
            //�����ʼ��
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = Constants.PROGRAM_VERSION;
            InitializeComponent();
            mainTableData = mainTable;
        }

        internal void MainForm_Load(object sender, EventArgs e)
        {
            //������ݳ�ʼ��
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
                MessageBox.Show("ѹ��������Ҫ����WinRAR������WinRAR��ѹ���㷨������Դ������Ҫ�����԰�װWinRAR����ʹ�ô˳���");
            }

            int index = mainTableData.CurrentRow.Index;
            DataGridViewRow dataGridViewRow = mainTableData.Rows[index];
            bool result = ExecuteCompress(dataGridViewRow.Cells[0].Value, dataGridViewRow.Cells[1].Value, false);
            if (result)
            {
                MessageBox.Show("ִ�����");
            }
        }

        private bool ExecuteCompress(object sourcePathValue, object targetPathValue, bool isOneKey)
        {
            if (sourcePathValue is null || targetPathValue is null)
            {
                if (!isOneKey)
                {
                    MessageBox.Show("Դ·����Ŀ��·������Ϊ��", "��ַΪ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            //TODO�������޷�����object����toStringΪ�յ��������ʱ���������ַ���
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
                    MessageBox.Show("ִ�й���������Ŀ¼Ϊ�յĴ���ִ��ֹͣ��\r\n" + (i + 1) + "��֮ǰ������" + (i + 1) + "�У���ִ�����",
                        "��ַΪ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allTrue = false;
                }

            }
            if (allTrue)
            {
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