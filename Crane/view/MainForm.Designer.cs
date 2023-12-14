namespace CTG_Control
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            folderBrowserDialog1 = new FolderBrowserDialog();
            contextMenuMain = new ContextMenuStrip(components);
            sssToolStripMenuItem = new ToolStripMenuItem();
            DeleteCurrent = new ToolStripMenuItem();
            addBtn = new Button();
            AllExecuteBtn = new Button();
            mainTable = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            SourcePath = new DataGridViewTextBoxColumn();
            TargetPath = new DataGridViewTextBoxColumn();
            LatelyDate = new DataGridViewTextBoxColumn();
            mainNotifyIcon = new NotifyIcon(components);
            mainContextMenuStrip = new ContextMenuStrip(components);
            MinimalToolStripMenuItem = new ToolStripMenuItem();
            MaximalToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            SyCountDownLabel = new Label();
            StopSyBtn = new Button();
            notification = new CheckBox();
            timeJudgeCheckBox = new CheckBox();
            checkBox1 = new CheckBox();
            contextMenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainTable).BeginInit();
            mainContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuMain
            // 
            contextMenuMain.ImageScalingSize = new Size(20, 20);
            contextMenuMain.Items.AddRange(new ToolStripItem[] { sssToolStripMenuItem, DeleteCurrent });
            contextMenuMain.Name = "contextMenuMain";
            contextMenuMain.Size = new Size(364, 52);
            // 
            // sssToolStripMenuItem
            // 
            sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            sssToolStripMenuItem.Size = new Size(363, 24);
            sssToolStripMenuItem.Text = "执行压缩（！注意确认左边三角标选择行）";
            sssToolStripMenuItem.Click += ExecuteBtn_Click;
            // 
            // DeleteCurrent
            // 
            DeleteCurrent.Name = "DeleteCurrent";
            DeleteCurrent.Size = new Size(363, 24);
            DeleteCurrent.Text = "删除当前指向行项";
            DeleteCurrent.Click += DeleteCurrent_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(1369, 12);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(155, 50);
            addBtn.TabIndex = 4;
            addBtn.Text = "添加项";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += AddBtn_Click;
            // 
            // AllExecuteBtn
            // 
            AllExecuteBtn.Location = new Point(1369, 78);
            AllExecuteBtn.Name = "AllExecuteBtn";
            AllExecuteBtn.Size = new Size(155, 50);
            AllExecuteBtn.TabIndex = 5;
            AllExecuteBtn.Text = "一键执行";
            AllExecuteBtn.UseVisualStyleBackColor = true;
            AllExecuteBtn.Click += AllExecuteBtn_Click;
            // 
            // mainTable
            // 
            mainTable.AllowUserToAddRows = false;
            mainTable.AllowUserToDeleteRows = false;
            mainTable.BackgroundColor = SystemColors.Control;
            mainTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainTable.Columns.AddRange(new DataGridViewColumn[] { id, SourcePath, TargetPath, LatelyDate });
            mainTable.ContextMenuStrip = contextMenuMain;
            mainTable.Location = new Point(34, 12);
            mainTable.Name = "mainTable";
            mainTable.RowHeadersWidth = 51;
            mainTable.RowTemplate.Height = 29;
            mainTable.Size = new Size(1317, 580);
            mainTable.TabIndex = 6;
            mainTable.CellContentClick += mainTable_CellContentClick;
            mainTable.CellMouseDown += MainTable_CellMouseDown;
            // 
            // id
            // 
            id.Frozen = true;
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 50;
            // 
            // SourcePath
            // 
            SourcePath.Frozen = true;
            SourcePath.HeaderText = "源路径";
            SourcePath.MinimumWidth = 500;
            SourcePath.Name = "SourcePath";
            SourcePath.Width = 500;
            // 
            // TargetPath
            // 
            TargetPath.Frozen = true;
            TargetPath.HeaderText = "目标路径";
            TargetPath.MinimumWidth = 500;
            TargetPath.Name = "TargetPath";
            TargetPath.Width = 500;
            // 
            // LatelyDate
            // 
            LatelyDate.Frozen = true;
            LatelyDate.HeaderText = "最近执行日期";
            LatelyDate.MinimumWidth = 6;
            LatelyDate.Name = "LatelyDate";
            LatelyDate.ReadOnly = true;
            LatelyDate.Width = 250;
            // 
            // mainNotifyIcon
            // 
            mainNotifyIcon.ContextMenuStrip = mainContextMenuStrip;
            mainNotifyIcon.Icon = (Icon)resources.GetObject("mainNotifyIcon.Icon");
            mainNotifyIcon.Text = "mainNotifyIcon";
            mainNotifyIcon.Visible = true;
            mainNotifyIcon.MouseClick += mainNotifyIcon_MouseClick;
            // 
            // mainContextMenuStrip
            // 
            mainContextMenuStrip.ImageScalingSize = new Size(20, 20);
            mainContextMenuStrip.Items.AddRange(new ToolStripItem[] { MinimalToolStripMenuItem, MaximalToolStripMenuItem, ExitToolStripMenuItem });
            mainContextMenuStrip.Name = "mainContextMenuStrip";
            mainContextMenuStrip.Size = new Size(124, 76);
            mainContextMenuStrip.Opening += mainContextMenuStrip_Opening;
            // 
            // MinimalToolStripMenuItem
            // 
            MinimalToolStripMenuItem.Name = "MinimalToolStripMenuItem";
            MinimalToolStripMenuItem.Size = new Size(123, 24);
            MinimalToolStripMenuItem.Text = "最小化";
            MinimalToolStripMenuItem.Click += MinimalToolStripMenuItem_Click;
            // 
            // MaximalToolStripMenuItem
            // 
            MaximalToolStripMenuItem.Name = "MaximalToolStripMenuItem";
            MaximalToolStripMenuItem.Size = new Size(123, 24);
            MaximalToolStripMenuItem.Text = "还原";
            MaximalToolStripMenuItem.Click += MaximalToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(123, 24);
            ExitToolStripMenuItem.Text = "退出";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // SyCountDownLabel
            // 
            SyCountDownLabel.AutoSize = true;
            SyCountDownLabel.Font = new Font("Microsoft YaHei UI", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point);
            SyCountDownLabel.ForeColor = Color.FromArgb(192, 0, 0);
            SyCountDownLabel.Location = new Point(1358, 301);
            SyCountDownLabel.MaximumSize = new Size(0, 155);
            SyCountDownLabel.Name = "SyCountDownLabel";
            SyCountDownLabel.Size = new Size(166, 24);
            SyCountDownLabel.TabIndex = 8;
            SyCountDownLabel.Text = "10秒后启动同步程序";
            // 
            // StopSyBtn
            // 
            StopSyBtn.Location = new Point(1369, 146);
            StopSyBtn.Name = "StopSyBtn";
            StopSyBtn.Size = new Size(155, 50);
            StopSyBtn.TabIndex = 7;
            StopSyBtn.Text = "点击终止同步";
            StopSyBtn.UseVisualStyleBackColor = true;
            StopSyBtn.Click += StopSyBtn_Click;
            // 
            // notification
            // 
            notification.AutoSize = true;
            notification.Checked = true;
            notification.CheckState = CheckState.Checked;
            notification.Location = new Point(1369, 568);
            notification.Name = "notification";
            notification.Size = new Size(148, 24);
            notification.TabIndex = 9;
            notification.Text = "自动同步是否通知";
            notification.UseVisualStyleBackColor = true;
            notification.CheckedChanged += notification_CheckedChanged;
            // 
            // timeJudgeCheckBox
            // 
            timeJudgeCheckBox.AutoSize = true;
            timeJudgeCheckBox.Checked = true;
            timeJudgeCheckBox.CheckState = CheckState.Checked;
            timeJudgeCheckBox.Location = new Point(1369, 526);
            timeJudgeCheckBox.Name = "timeJudgeCheckBox";
            timeJudgeCheckBox.Size = new Size(118, 24);
            timeJudgeCheckBox.TabIndex = 10;
            timeJudgeCheckBox.Text = "是否时间检测";
            timeJudgeCheckBox.UseVisualStyleBackColor = true;
            timeJudgeCheckBox.CheckedChanged += timeJudgeCheckBox_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(1369, 480);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(163, 24);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "是否开机自启（待）";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1536, 627);
            Controls.Add(checkBox1);
            Controls.Add(timeJudgeCheckBox);
            Controls.Add(notification);
            Controls.Add(mainTable);
            Controls.Add(SyCountDownLabel);
            Controls.Add(StopSyBtn);
            Controls.Add(AllExecuteBtn);
            Controls.Add(addBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            contextMenuMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainTable).EndInit();
            mainContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FolderBrowserDialog folderBrowserDialog1;
        private Button addBtn;
        private Button AllExecuteBtn;
        private ContextMenuStrip contextMenuMain;
        private DataGridView mainTable;
        private ToolStripMenuItem sssToolStripMenuItem;
        private ToolStripMenuItem DeleteCurrent;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn SourcePath;
        private DataGridViewTextBoxColumn TargetPath;
        private DataGridViewTextBoxColumn LatelyDate;
        private NotifyIcon mainNotifyIcon;
        private ContextMenuStrip mainContextMenuStrip;
        private ToolStripMenuItem MinimalToolStripMenuItem;
        private ToolStripMenuItem MaximalToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private Label SyCountDownLabel;
        private Button StopSyBtn;
        private CheckBox notification;
        private CheckBox timeJudgeCheckBox;
        private CheckBox checkBox1;
    }
}