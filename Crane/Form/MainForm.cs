using CTG_Control.crane.form;

namespace CTG_Control
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //窗体初始化
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //表格数据初始化
            ListViewItem[] lvs = new ListViewItem[3];
            lvs[0] = new ListViewItem(new string[] { "行1列11", "行1列2", "" });
            lvs[1] = new ListViewItem(new string[] { "行2列1", "行2列2", "" });
            lvs[2] = new ListViewItem(new string[] { "行3列1", "行3列2", "" });
            mainTable.Items.AddRange(lvs);

            //定义表格行高
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
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