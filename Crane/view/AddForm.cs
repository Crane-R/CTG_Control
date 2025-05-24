using CTG_Control.Crane.Constant;
using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using CTG_Control.Crane.Service;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Forms;

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
        }

        private void AddSourcePath_Click(object sender, EventArgs e)
        {
            if (Constants.ADD_SOURCE_PATH_BLANK.Equals(addSourcePath.Text))
            {
                addSourcePath.Text = null;
                addSourcePath.ForeColor = Color.Black;
            }
            if (!isFile.Checked)
            {
                ChooseSourcePath.Description = "请选择源路径";
                ChooseSourcePath.RootFolder = Environment.SpecialFolder.MyComputer;
                if (addSourcePath.Text != null && addSourcePath.Text.Length > 0)
                {
                    ChooseSourcePath.SelectedPath = addSourcePath.Text;
                }
                if (ChooseSourcePath.ShowDialog() == DialogResult.OK)
                {
                    addSourcePath.Text = ChooseSourcePath.SelectedPath;
                }
            }
            else
            {
                if (addSourcePath.Text != null && addSourcePath.Text.Length > 0)
                {
                    chooseBack.FileName = addSourcePath.Text;
                }
                if (chooseBack.ShowDialog() == DialogResult.OK)
                {
                    addSourcePath.Text = chooseBack.FileName;
                }
            }
        }

        private void SureBtn_Click(object sender, EventArgs e)
        {
            string sourcePath = addSourcePath.Text;
            string markName = markNameBox.Text;
            if ("".Equals(sourcePath)
                || Constants.ADD_SOURCE_PATH_BLANK.Equals(sourcePath)
                || "".Equals(markName)
                || Constants.MARK_NAME_BLANK.Equals(markName)
                )
            {
                MessageBox.Show("标识名、源路径不可为空", "判空提示");
                return;
            }

            //写数据
            DataDao.Add(new CompressItem(IdService.GenerateId(), markName, sourcePath,
                 DateTime.MinValue, isAuto.Checked,
                Convert.ToInt32(IntervalValue.Text.Equals("") ? ConfigService.GetValue("slowInterval") : IntervalValue.Text), 0));
            mainForm.Init();
            Close();
        }

        private void markNameBox_Click(object sender, EventArgs e)
        {
            markNameBox.Clear();
            markNameBox.ForeColor = Color.Black;
        }

        private void markNameBox_Leave(object sender, EventArgs e)
        {
            judgeText(markNameBox, Constants.MARK_NAME_BLANK);
        }

        private void addSourcePath_Leave(object sender, EventArgs e)
        {
            judgeText(addSourcePath, Constants.ADD_SOURCE_PATH_BLANK);
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

        private void ChooseStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string text = comboBox.SelectedItem.ToString();
            BackIntervalTool backIntervalTool = new BackIntervalTool();
            int hour = backIntervalTool.GetHourByStandardItemContent(text);
            IntervalValue.Text = hour.ToString();
        }

    }
}
