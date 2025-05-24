namespace CTG_Control.Crane.view
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            groupBox1 = new GroupBox();
            timeJudgeCheckBox = new CheckBox();
            notification = new CheckBox();
            startUpCheckBox = new CheckBox();
            sfxCheckBox = new CheckBox();
            mainNotifyIcon = new NotifyIcon(components);
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(timeJudgeCheckBox);
            groupBox1.Controls.Add(notification);
            groupBox1.Controls.Add(startUpCheckBox);
            groupBox1.Controls.Add(sfxCheckBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "软件功能";
            // 
            // timeJudgeCheckBox
            // 
            timeJudgeCheckBox.AutoSize = true;
            timeJudgeCheckBox.Location = new Point(6, 131);
            timeJudgeCheckBox.Name = "timeJudgeCheckBox";
            timeJudgeCheckBox.Size = new Size(144, 28);
            timeJudgeCheckBox.TabIndex = 3;
            timeJudgeCheckBox.Text = "压缩时间检测";
            timeJudgeCheckBox.UseVisualStyleBackColor = true;
            timeJudgeCheckBox.CheckedChanged += timeJudgeCheckBox_CheckedChanged;
            // 
            // notification
            // 
            notification.AutoSize = true;
            notification.Location = new Point(6, 97);
            notification.Name = "notification";
            notification.Size = new Size(144, 28);
            notification.TabIndex = 2;
            notification.Text = "自动同步通知";
            notification.UseVisualStyleBackColor = true;
            notification.CheckedChanged += notification_CheckedChanged;
            // 
            // startUpCheckBox
            // 
            startUpCheckBox.AutoSize = true;
            startUpCheckBox.Location = new Point(6, 63);
            startUpCheckBox.Name = "startUpCheckBox";
            startUpCheckBox.Size = new Size(108, 28);
            startUpCheckBox.TabIndex = 1;
            startUpCheckBox.Text = "开机自启";
            startUpCheckBox.UseVisualStyleBackColor = true;
            startUpCheckBox.CheckedChanged += startUpCheckBox_CheckedChanged;
            // 
            // sfxCheckBox
            // 
            sfxCheckBox.AutoSize = true;
            sfxCheckBox.Location = new Point(6, 29);
            sfxCheckBox.Name = "sfxCheckBox";
            sfxCheckBox.Size = new Size(180, 28);
            sfxCheckBox.TabIndex = 0;
            sfxCheckBox.Text = "压缩时创建自解压";
            sfxCheckBox.UseVisualStyleBackColor = true;
            sfxCheckBox.CheckedChanged += sfxCheckBox_CheckedChanged;
            // 
            // mainNotifyIcon
            // 
            mainNotifyIcon.Icon = (Icon)resources.GetObject("mainNotifyIcon.Icon");
            mainNotifyIcon.Text = "mainNotifyIcon";
            mainNotifyIcon.Visible = true;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "SettingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "设置";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox timeJudgeCheckBox;
        private CheckBox notification;
        private CheckBox startUpCheckBox;
        private CheckBox sfxCheckBox;
        private NotifyIcon mainNotifyIcon;
    }
}