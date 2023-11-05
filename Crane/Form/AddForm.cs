using CTG_Control.Crane.Constant;
using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;

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
            addSourcePath.Text = Constants.ADD_SOURCE_PATH_BLANK;
            addTargetPath.Text = Constants.ADD_TARGET_PATH_BLANK;
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
            if ("".Equals(sourcePath) || "".Equals(targetPath)
                || Constants.ADD_SOURCE_PATH_BLANK.Equals(sourcePath)
                || Constants.ADD_TARGET_PATH_BLANK.Equals(targetPath))
            {
                //请确认源路径和目标路径不为空
                MessageBox.Show("请确认源路径和目标路径不为空", "提示");
                return;
            }

            //写数据
            AllDataDao.Add(new CompressItem(sourcePath, targetPath));
            mainForm.MainForm_Load(null, null);
            Close();
        }

    }
}
