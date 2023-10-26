using CTG_Control.Crane.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTG_Control.crane.form
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            this.StartPosition = FormStartPosition.CenterParent;

            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            addSourcePath.Text = Constants.ADD_SOURCE_PATH_BLANK;
            addTargetPath.Text = Constants.ADD_TARGET_PATH_BLANK;
        }

        private void AddSourcePath_Click(object sender, EventArgs e)
        {
            //C#和Java中this的指向或许有不同，
            //在Java中这里应该是this.Text而C#是addSourcePath.Text
            if (Constants.ADD_SOURCE_PATH_BLANK.Equals(addSourcePath.Text))
            {
                addSourcePath.Text = null;
            }
        }

        private void AddTargetPath_Click(object sender, EventArgs e)
        {
            if (Constants.ADD_TARGET_PATH_BLANK.Equals(addTargetPath.Text))
            {
                addTargetPath.Text = null;
            }
        }
    }
}
