﻿namespace CTG_Control
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
            restoreItem = new ToolStripMenuItem();
            addBtn = new Button();
            AllExecuteBtn = new Button();
            mainTable = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            markName = new DataGridViewTextBoxColumn();
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
            isStartUpCheckBox = new CheckBox();
            sfxCheckBox = new CheckBox();
            exitBtn = new Button();
            SourceBitSumLabel = new Label();
            label2 = new Label();
            contextMenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainTable).BeginInit();
            mainContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuMain
            // 
            contextMenuMain.ImageScalingSize = new Size(20, 20);
            contextMenuMain.Items.AddRange(new ToolStripItem[] { sssToolStripMenuItem, DeleteCurrent, restoreItem });
            contextMenuMain.Name = "contextMenuMain";
            contextMenuMain.Size = new Size(305, 70);
            // 
            // sssToolStripMenuItem
            // 
            sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            sssToolStripMenuItem.Size = new Size(304, 22);
            sssToolStripMenuItem.Text = "执行压缩（！注意确认左边三角标选择行）";
            sssToolStripMenuItem.Click += ExecuteBtn_Click;
            // 
            // DeleteCurrent
            // 
            DeleteCurrent.Name = "DeleteCurrent";
            DeleteCurrent.Size = new Size(304, 22);
            DeleteCurrent.Text = "删除当前指向行项";
            DeleteCurrent.Click += DeleteCurrent_Click;
            // 
            // restoreItem
            // 
            restoreItem.Name = "restoreItem";
            restoreItem.Size = new Size(304, 22);
            restoreItem.Text = "从目标地址覆盖还原（点我默认第一个）";
            restoreItem.Click += restoreItem_Click;
            restoreItem.MouseHover += restoreItem_MouseHover;
            // 
            // addBtn
            // 
            addBtn.BackColor = SystemColors.Control;
            addBtn.Cursor = Cursors.Hand;
            addBtn.Font = new Font("Microsoft YaHei UI", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point);
            addBtn.Location = new Point(974, 479);
            addBtn.Margin = new Padding(2, 3, 2, 3);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(121, 42);
            addBtn.TabIndex = 4;
            addBtn.Text = "添加项";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += AddBtn_Click;
            // 
            // AllExecuteBtn
            // 
            AllExecuteBtn.BackColor = SystemColors.Control;
            AllExecuteBtn.Cursor = Cursors.Hand;
            AllExecuteBtn.Font = new Font("Microsoft YaHei UI", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point);
            AllExecuteBtn.ForeColor = SystemColors.ActiveCaptionText;
            AllExecuteBtn.Location = new Point(1099, 479);
            AllExecuteBtn.Margin = new Padding(2, 3, 2, 3);
            AllExecuteBtn.Name = "AllExecuteBtn";
            AllExecuteBtn.Size = new Size(121, 42);
            AllExecuteBtn.TabIndex = 5;
            AllExecuteBtn.Text = "一键执行";
            AllExecuteBtn.UseVisualStyleBackColor = false;
            AllExecuteBtn.Click += AllExecuteBtn_Click;
            // 
            // mainTable
            // 
            mainTable.AllowUserToAddRows = false;
            mainTable.AllowUserToDeleteRows = false;
            mainTable.BackgroundColor = SystemColors.Control;
            mainTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainTable.Columns.AddRange(new DataGridViewColumn[] { id, markName, SourcePath, TargetPath, LatelyDate });
            mainTable.ContextMenuStrip = contextMenuMain;
            mainTable.Location = new Point(11, 12);
            mainTable.Margin = new Padding(2, 3, 2, 3);
            mainTable.Name = "mainTable";
            mainTable.RowHeadersWidth = 51;
            mainTable.RowTemplate.Height = 29;
            mainTable.Size = new Size(1334, 461);
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
            // markName
            // 
            markName.Frozen = true;
            markName.HeaderText = "标识";
            markName.Name = "markName";
            markName.ReadOnly = true;
            // 
            // SourcePath
            // 
            SourcePath.Frozen = true;
            SourcePath.HeaderText = "源路径";
            SourcePath.MinimumWidth = 500;
            SourcePath.Name = "SourcePath";
            SourcePath.ReadOnly = true;
            SourcePath.Width = 500;
            // 
            // TargetPath
            // 
            TargetPath.Frozen = true;
            TargetPath.HeaderText = "目标路径";
            TargetPath.MinimumWidth = 500;
            TargetPath.Name = "TargetPath";
            TargetPath.ReadOnly = true;
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
            mainContextMenuStrip.Size = new Size(113, 70);
            mainContextMenuStrip.Opening += mainContextMenuStrip_Opening;
            // 
            // MinimalToolStripMenuItem
            // 
            MinimalToolStripMenuItem.Name = "MinimalToolStripMenuItem";
            MinimalToolStripMenuItem.Size = new Size(112, 22);
            MinimalToolStripMenuItem.Text = "最小化";
            MinimalToolStripMenuItem.Click += MinimalToolStripMenuItem_Click;
            // 
            // MaximalToolStripMenuItem
            // 
            MaximalToolStripMenuItem.Name = "MaximalToolStripMenuItem";
            MaximalToolStripMenuItem.Size = new Size(112, 22);
            MaximalToolStripMenuItem.Text = "还原";
            MaximalToolStripMenuItem.Click += MaximalToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(112, 22);
            ExitToolStripMenuItem.Text = "退出";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // SyCountDownLabel
            // 
            SyCountDownLabel.AutoSize = true;
            SyCountDownLabel.Font = new Font("Microsoft YaHei UI", 12.1008406F, FontStyle.Bold, GraphicsUnit.Point);
            SyCountDownLabel.ForeColor = Color.FromArgb(192, 0, 0);
            SyCountDownLabel.Location = new Point(11, 476);
            SyCountDownLabel.Margin = new Padding(2, 0, 2, 0);
            SyCountDownLabel.MaximumSize = new Size(0, 132);
            SyCountDownLabel.Name = "SyCountDownLabel";
            SyCountDownLabel.Size = new Size(166, 24);
            SyCountDownLabel.TabIndex = 8;
            SyCountDownLabel.Text = "10秒后启动同步程序";
            SyCountDownLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StopSyBtn
            // 
            StopSyBtn.BackColor = Color.IndianRed;
            StopSyBtn.Cursor = Cursors.Hand;
            StopSyBtn.Font = new Font("Microsoft YaHei UI", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point);
            StopSyBtn.ForeColor = SystemColors.ButtonHighlight;
            StopSyBtn.Location = new Point(835, 479);
            StopSyBtn.Margin = new Padding(2, 3, 2, 3);
            StopSyBtn.Name = "StopSyBtn";
            StopSyBtn.Size = new Size(135, 42);
            StopSyBtn.TabIndex = 7;
            StopSyBtn.Text = "终止自动同步";
            StopSyBtn.UseVisualStyleBackColor = false;
            StopSyBtn.Click += StopSyBtn_Click;
            // 
            // notification
            // 
            notification.AutoSize = true;
            notification.Checked = true;
            notification.CheckState = CheckState.Checked;
            notification.Location = new Point(732, 479);
            notification.Margin = new Padding(2, 3, 2, 3);
            notification.Name = "notification";
            notification.Size = new Size(99, 21);
            notification.TabIndex = 9;
            notification.Text = "自动同步通知";
            notification.UseVisualStyleBackColor = true;
            notification.CheckedChanged += notification_CheckedChanged;
            // 
            // timeJudgeCheckBox
            // 
            timeJudgeCheckBox.AutoSize = true;
            timeJudgeCheckBox.Checked = true;
            timeJudgeCheckBox.CheckState = CheckState.Checked;
            timeJudgeCheckBox.Location = new Point(732, 506);
            timeJudgeCheckBox.Margin = new Padding(2, 3, 2, 3);
            timeJudgeCheckBox.Name = "timeJudgeCheckBox";
            timeJudgeCheckBox.Size = new Size(75, 21);
            timeJudgeCheckBox.TabIndex = 10;
            timeJudgeCheckBox.Text = "时间检测";
            timeJudgeCheckBox.UseVisualStyleBackColor = true;
            timeJudgeCheckBox.CheckedChanged += timeJudgeCheckBox_CheckedChanged;
            // 
            // isStartUpCheckBox
            // 
            isStartUpCheckBox.AutoSize = true;
            isStartUpCheckBox.Checked = true;
            isStartUpCheckBox.CheckState = CheckState.Checked;
            isStartUpCheckBox.Location = new Point(641, 479);
            isStartUpCheckBox.Margin = new Padding(2, 3, 2, 3);
            isStartUpCheckBox.Name = "isStartUpCheckBox";
            isStartUpCheckBox.Size = new Size(75, 21);
            isStartUpCheckBox.TabIndex = 11;
            isStartUpCheckBox.Text = "开机自启";
            isStartUpCheckBox.UseVisualStyleBackColor = true;
            isStartUpCheckBox.CheckedChanged += isStartUpCheckBox_CheckedChanged;
            // 
            // sfxCheckBox
            // 
            sfxCheckBox.AutoSize = true;
            sfxCheckBox.Checked = true;
            sfxCheckBox.CheckState = CheckState.Checked;
            sfxCheckBox.Location = new Point(641, 506);
            sfxCheckBox.Margin = new Padding(2, 3, 2, 3);
            sfxCheckBox.Name = "sfxCheckBox";
            sfxCheckBox.Size = new Size(87, 21);
            sfxCheckBox.TabIndex = 12;
            sfxCheckBox.Text = "创建自解压";
            sfxCheckBox.UseVisualStyleBackColor = true;
            sfxCheckBox.CheckedChanged += sfxCheckBox_CheckedChanged;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = SystemColors.ControlDarkDark;
            exitBtn.Cursor = Cursors.Hand;
            exitBtn.Font = new Font("Microsoft YaHei UI", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point);
            exitBtn.ForeColor = SystemColors.ButtonHighlight;
            exitBtn.Location = new Point(1224, 479);
            exitBtn.Margin = new Padding(2, 3, 2, 3);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(121, 42);
            exitBtn.TabIndex = 13;
            exitBtn.Text = "退出程序";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += ExitBtn_Click;
            // 
            // SourceBitSumLabel
            // 
            SourceBitSumLabel.AutoSize = true;
            SourceBitSumLabel.Font = new Font("Microsoft YaHei UI", 12.1008406F, FontStyle.Bold, GraphicsUnit.Point);
            SourceBitSumLabel.ForeColor = Color.Navy;
            SourceBitSumLabel.Location = new Point(11, 503);
            SourceBitSumLabel.Margin = new Padding(2, 0, 2, 0);
            SourceBitSumLabel.MaximumSize = new Size(0, 132);
            SourceBitSumLabel.Name = "SourceBitSumLabel";
            SourceBitSumLabel.Size = new Size(163, 24);
            SourceBitSumLabel.TabIndex = 14;
            SourceBitSumLabel.Text = "项源目录大小总和：";
            SourceBitSumLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12.1008406F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(303, 503);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.MaximumSize = new Size(0, 132);
            label2.Name = "label2";
            label2.Size = new Size(95, 24);
            label2.TabIndex = 15;
            label2.Text = "预估时间：";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1356, 532);
            Controls.Add(label2);
            Controls.Add(SourceBitSumLabel);
            Controls.Add(exitBtn);
            Controls.Add(sfxCheckBox);
            Controls.Add(isStartUpCheckBox);
            Controls.Add(timeJudgeCheckBox);
            Controls.Add(notification);
            Controls.Add(mainTable);
            Controls.Add(SyCountDownLabel);
            Controls.Add(StopSyBtn);
            Controls.Add(AllExecuteBtn);
            Controls.Add(addBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 3, 2, 3);
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
        private NotifyIcon mainNotifyIcon;
        private ContextMenuStrip mainContextMenuStrip;
        private ToolStripMenuItem MinimalToolStripMenuItem;
        private ToolStripMenuItem MaximalToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private Label SyCountDownLabel;
        private Button StopSyBtn;
        private CheckBox notification;
        private CheckBox timeJudgeCheckBox;
        private CheckBox isStartUpCheckBox;
        private CheckBox sfxCheckBox;
        private ToolStripMenuItem restoreItem;
        private Button exitBtn;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn markName;
        private DataGridViewTextBoxColumn SourcePath;
        private DataGridViewTextBoxColumn TargetPath;
        private DataGridViewTextBoxColumn LatelyDate;
        private Label SourceBitSumLabel;
        private Label label2;
    }
}