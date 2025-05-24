using CTG_Control.Crane.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTG_Control.Crane.view
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            if (ConfigService.GetValue("isNotify").Equals("1"))
            {
                notification.Checked = true;
                mainNotifyIcon.BalloonTipText = ConfigService.GetValue("notificationText");
            }
            else
            {
                notification.Checked = false;
            }
            timeJudgeCheckBox.Checked = ConfigService.GetValueByBool("isTimeJudge");
            startUpCheckBox.Checked = ConfigService.GetValueByBool("isStartUp");
            sfxCheckBox.Checked = ConfigService.GetValueByBool("sfx");
        }

        private void sfxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("sfx", sfxCheckBox.Checked ? "1" : "0");
        }

        private void startUpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //开发模式自启动失效
            string currentPath = PathService.GetApplicationPath();
            if (currentPath.Contains("Projects"))
            {
                return;
            }
            bool isStartUp = startUpCheckBox.Checked;
            ConfigService.SetValue("isStartUp", isStartUp ? "1" : "0");
            if (isStartUp)
            {
                new StartUpService().OpenStartUp();
            }
            else
            {
                new StartUpService().CloseStartUp();
            }
            mainNotifyIcon.BalloonTipText = "当前是否开机自启？" + isStartUp;
            //其实此参数已经弃用，具体时间由操作系统控制
            mainNotifyIcon.ShowBalloonTip(1000);
        }

        private void notification_CheckedChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("isNotify", notification.Checked ? "1" : "0");
        }

        private void timeJudgeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConfigService.SetValue("isTimeJudge", timeJudgeCheckBox.Checked ? "1" : "0");
        }
    }
}
