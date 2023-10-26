using CTG_Control.crane.form;

namespace CTG_Control
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //�����ʼ��
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //������ݳ�ʼ��
            ListViewItem[] lvs = new ListViewItem[3];
            lvs[0] = new ListViewItem(new string[] { "��1��11", "��1��2", "" });
            lvs[1] = new ListViewItem(new string[] { "��2��1", "��2��2", "" });
            lvs[2] = new ListViewItem(new string[] { "��3��1", "��3��2", "" });
            mainTable.Items.AddRange(lvs);

            //�������и�
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            mainTable.SmallImageList = imgList;

            for (int i = 0; i < mainTable.Items.Count; i++)
            {
                Button btn = new()
                {
                    Visible = true,
                    Text = "ִ��"
                };

                btn.Click += button_Click;
                mainTable.Controls.Add(btn);
                btn.Size = new Size(
                    mainTable.Columns[2].Width - 10,
                   //TODO:�޷�ȷ���и�
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