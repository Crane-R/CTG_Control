using CTG_Control.Crane.Constant;
using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using CTG_Control.Crane.Service;

namespace CTG_Control.crane.form
{
    public partial class AddForm : Form
    {

        //记载主窗体
        private readonly MainForm mainForm;

        public AddForm(MainForm mainForm)
        {
            this.StartPosition = FormStartPosition.CenterParent;

            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            markNameBox.Text = Constants.MARK_NAME_BLANK;
            addSourcePath.Text = Constants.ADD_SOURCE_PATH_BLANK;
            addTargetPath.Text = ConfigService.GetValue("DefaultTargetPath");
        }

        private void AddSourcePath_Click(object sender, EventArgs e)
        {
            Path_Click(Constants.ADD_SOURCE_PATH_BLANK, addSourcePath, ChooseSourcePath);
        }

        private void AddTargetPath_Click(object sender, EventArgs e)
        {
            Path_Click(Constants.ADD_TARGET_PATH_BLANK, addTargetPath, ChooseTargetPath);
        }

        private void Path_Click(string constant, TextBox path, FolderBrowserDialog folderBrowserDialog)
        {
            //C#和Java中this的指向或许有不同，
            //在Java中这里应该是this.Text而C#是addSourcePath.Text
            if (constant.Equals(path.Text))
            {
                path.Text = null;
                path.ForeColor = Color.Black;
            }

            folderBrowserDialog.Description = "请选择源路径";
            //TODO选择路径框无法居中
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (path.Text != null && path.Text.Length > 0)
            {
                folderBrowserDialog.SelectedPath = path.Text;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void SureBtn_Click(object sender, EventArgs e)
        {
            string sourcePath = addSourcePath.Text;
            string targetPath = addTargetPath.Text;
            string markName = markNameBox.Text;
            if ("".Equals(sourcePath) || "".Equals(targetPath)
                || Constants.ADD_SOURCE_PATH_BLANK.Equals(sourcePath)
                || Constants.ADD_TARGET_PATH_BLANK.Equals(targetPath))
            {
                //请确认源路径和目标路径不为空
                MessageBox.Show("请确认源路径和目标路径不为空", "提示");
                return;
            }

            //写数据
            DataDao.Add(new CompressItem(IdService.GenerateId(), markName, sourcePath, targetPath, DateTime.MinValue));
            mainForm.Init();

            //是否修改默认上传地址
            if (DefaultUpPathCBox.Checked == true)
            {
                ConfigService.SetValue("DefaultTargetPath", targetPath);
            }

            Close();
        }

        private void markNameBox_Click(object sender, EventArgs e)
        {
            markNameBox.Clear();
        }

        private void markNameBox_Leave(object sender, EventArgs e)
        {
            judgeText(markNameBox, Constants.MARK_NAME_BLANK);
        }

        private void addSourcePath_Leave(object sender, EventArgs e)
        {
            judgeText(addSourcePath, Constants.ADD_SOURCE_PATH_BLANK);
        }

        private void addTargetPath_Leave(object sender, EventArgs e)
        {
            judgeText(addTargetPath, Constants.ADD_TARGET_PATH_BLANK);
        }

        /// <summary>
        /// 三输入框偶然聚合
        /// </summary>
        private void judgeText(TextBox textBox, string blankStr)
        {
            if (textBox.Text.Equals(blankStr))
            {
                textBox.ForeColor = Color.FromArgb(200, 200, 200);
                return;
            }
            if (textBox.Text == "" || textBox.Text is null)
            {
                textBox.Text = blankStr;
                textBox.ForeColor = Color.FromArgb(200, 200, 200);
            }
            else
            {
                textBox.ForeColor = Color.Black;
            }
        }

    }
}
