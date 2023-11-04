using CTG_Control.crane.form;
using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using CTG_Control.Crane.Model.Service;

namespace CTG_Control
{
    public partial class MainForm : Form
    {
        public static ListView mainTableData;

        public MainForm()
        {
            //窗体初始化
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            mainTableData = mainTable;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //表格数据初始化
            List<CompassItem> compassItems = AllDataDao.ReadAll();
            int count = compassItems.Count;
            ListViewItem[] lvs = new ListViewItem[count];
            for (int i = 0; i < count; i++)
            {
                CompassItem compassItem = compassItems[i];
                lvs[i] = new ListViewItem(new string[] { compassItem.SourcePath, compassItem.TargetPath, "" });
            }
            mainTable.Items.AddRange(lvs);

            //定义表格行高
            ImageList imgList = new()
            {
                ImageSize = new Size(1, 30)
            };
            mainTable.SmallImageList = imgList;

            for (int i = 0; i < mainTable.Items.Count; i++)
            {
                Button btn = new()
                {
                    Visible = true,
                    Text = "执行"
                };

                btn.Click += button_Click;
                mainTable.Controls.Add(btn);
                btn.Size = new Size(
                    mainTable.Columns[2].Width - 10,
                   //TODO:无法确定列高
                   30
                );
                btn.Location = new Point(
                    mainTable.Width - mainTable.Columns[2].Width,
                    (i + 1) * 30
                    );
            }

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dkfnkdjflds");
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            new AddForm().ShowDialog();
        }
    }
}