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
            label2 = new Label();
            AboutBtn = new Button();
            label1 = new Label();
            TotalLastPast = new Label();
            mainTable = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            markName = new DataGridViewTextBoxColumn();
            SourcePath = new DataGridViewTextBoxColumn();
            itemSetBtn = new DataGridViewButtonColumn();
            textBox1 = new TextBox();
            label3 = new Label();
            changeBackLocationBtn = new Button();
            contextMenuMain.SuspendLayout();
            mainContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainTable).BeginInit();
            SuspendLayout();
            // 
            // contextMenuMain
            // 
            contextMenuMain.ImageScalingSize = new Size(20, 20);
            contextMenuMain.Items.AddRange(new ToolStripItem[] { sssToolStripMenuItem, DeleteCurrent, restoreItem });
            contextMenuMain.Name = "contextMenuMain";
            contextMenuMain.Size = new Size(446, 100);
            // 
            // sssToolStripMenuItem
            // 
            sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            sssToolStripMenuItem.Size = new Size(445, 32);
            sssToolStripMenuItem.Text = "执行压缩（！注意确认左边三角标选择行）";
            sssToolStripMenuItem.Click += ExecuteBtn_Click;
            // 
            // DeleteCurrent
            // 
            DeleteCurrent.Name = "DeleteCurrent";
            DeleteCurrent.Size = new Size(445, 32);
            DeleteCurrent.Text = "删除当前指向行项";
            DeleteCurrent.Click += DeleteCurrent_Click;
            // 
            // restoreItem
            // 
            restoreItem.Name = "restoreItem";
            restoreItem.Size = new Size(445, 32);
            restoreItem.Text = "从目标地址覆盖还原（点我默认第一个）";
            restoreItem.Click += restoreItem_Click;
            restoreItem.MouseHover += restoreItem_MouseHover;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.LightSalmon;
            addBtn.Cursor = Cursors.Hand;
            addBtn.Font = new Font("Microsoft YaHei UI", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point);
            addBtn.ForeColor = SystemColors.ControlLightLight;
            addBtn.Location = new Point(921, 1075);
            addBtn.Margin = new Padding(3, 4, 3, 4);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(164, 62);
            addBtn.TabIndex = 4;
            addBtn.Text = "添加项";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += AddBtn_Click;
            // 
            // AllExecuteBtn
            // 
            AllExecuteBtn.BackColor = SystemColors.ActiveCaption;
            AllExecuteBtn.Cursor = Cursors.Hand;
            AllExecuteBtn.Font = new Font("Microsoft YaHei UI", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point);
            AllExecuteBtn.ForeColor = SystemColors.ButtonFace;
            AllExecuteBtn.Location = new Point(1036, 1075);
            AllExecuteBtn.Margin = new Padding(3, 4, 3, 4);
            AllExecuteBtn.Name = "AllExecuteBtn";
            AllExecuteBtn.Size = new Size(164, 62);
            AllExecuteBtn.TabIndex = 5;
            AllExecuteBtn.Text = "一键执行";
            AllExecuteBtn.UseVisualStyleBackColor = false;
            AllExecuteBtn.Click += AllExecuteBtn_Click;
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
            mainContextMenuStrip.Size = new Size(142, 100);
            mainContextMenuStrip.Opening += mainContextMenuStrip_Opening;
            // 
            // MinimalToolStripMenuItem
            // 
            MinimalToolStripMenuItem.Name = "MinimalToolStripMenuItem";
            MinimalToolStripMenuItem.Size = new Size(141, 32);
            MinimalToolStripMenuItem.Text = "最小化";
            MinimalToolStripMenuItem.Click += MinimalToolStripMenuItem_Click;
            // 
            // MaximalToolStripMenuItem
            // 
            MaximalToolStripMenuItem.Name = "MaximalToolStripMenuItem";
            MaximalToolStripMenuItem.Size = new Size(141, 32);
            MaximalToolStripMenuItem.Text = "还原";
            MaximalToolStripMenuItem.Click += MaximalToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(141, 32);
            ExitToolStripMenuItem.Text = "退出";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // SyCountDownLabel
            // 
            SyCountDownLabel.AutoSize = true;
            SyCountDownLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SyCountDownLabel.ForeColor = Color.FromArgb(192, 0, 0);
            SyCountDownLabel.Location = new Point(15, 1056);
            SyCountDownLabel.MaximumSize = new Size(0, 194);
            SyCountDownLabel.Name = "SyCountDownLabel";
            SyCountDownLabel.Size = new Size(220, 31);
            SyCountDownLabel.TabIndex = 8;
            SyCountDownLabel.Text = "x秒后启动同步程序";
            SyCountDownLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StopSyBtn
            // 
            StopSyBtn.BackColor = Color.Brown;
            StopSyBtn.Cursor = Cursors.Hand;
            StopSyBtn.Font = new Font("Microsoft YaHei UI", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point);
            StopSyBtn.ForeColor = SystemColors.ButtonHighlight;
            StopSyBtn.Location = new Point(1223, 1077);
            StopSyBtn.Margin = new Padding(3, 4, 3, 4);
            StopSyBtn.Name = "StopSyBtn";
            StopSyBtn.Size = new Size(303, 62);
            StopSyBtn.TabIndex = 7;
            StopSyBtn.Text = "快单击我！！！快";
            StopSyBtn.UseVisualStyleBackColor = false;
            StopSyBtn.Click += StopSyBtn_Click;
            // 
            // notification
            // 
            notification.AutoSize = true;
            notification.Checked = true;
            notification.CheckState = CheckState.Checked;
            notification.Location = new Point(801, 1073);
            notification.Margin = new Padding(3, 4, 3, 4);
            notification.Name = "notification";
            notification.Size = new Size(152, 29);
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
            timeJudgeCheckBox.Location = new Point(801, 1108);
            timeJudgeCheckBox.Margin = new Padding(3, 4, 3, 4);
            timeJudgeCheckBox.Name = "timeJudgeCheckBox";
            timeJudgeCheckBox.Size = new Size(114, 29);
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
            isStartUpCheckBox.Location = new Point(643, 1073);
            isStartUpCheckBox.Margin = new Padding(3, 4, 3, 4);
            isStartUpCheckBox.Name = "isStartUpCheckBox";
            isStartUpCheckBox.Size = new Size(114, 29);
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
            sfxCheckBox.Location = new Point(643, 1110);
            sfxCheckBox.Margin = new Padding(3, 4, 3, 4);
            sfxCheckBox.Name = "sfxCheckBox";
            sfxCheckBox.Size = new Size(133, 29);
            sfxCheckBox.TabIndex = 12;
            sfxCheckBox.Text = "创建自解压";
            sfxCheckBox.UseVisualStyleBackColor = true;
            sfxCheckBox.CheckedChanged += sfxCheckBox_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(15, 1108);
            label2.MaximumSize = new Size(0, 194);
            label2.Name = "label2";
            label2.Size = new Size(222, 28);
            label2.TabIndex = 15;
            label2.Text = "所有项执行时间总计：";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AboutBtn
            // 
            AboutBtn.BackColor = SystemColors.Info;
            AboutBtn.Cursor = Cursors.Hand;
            AboutBtn.Font = new Font("Microsoft YaHei UI", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point);
            AboutBtn.ForeColor = SystemColors.ControlDarkDark;
            AboutBtn.Location = new Point(1125, 1077);
            AboutBtn.Margin = new Padding(3, 4, 3, 4);
            AboutBtn.Name = "AboutBtn";
            AboutBtn.Size = new Size(164, 62);
            AboutBtn.TabIndex = 16;
            AboutBtn.Text = "关于软件";
            AboutBtn.UseVisualStyleBackColor = false;
            AboutBtn.Click += AboutBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(437, 1111);
            label1.Name = "label1";
            label1.Size = new Size(54, 28);
            label1.TabIndex = 17;
            label1.Text = "分钟";
            // 
            // TotalLastPast
            // 
            TotalLastPast.AutoSize = true;
            TotalLastPast.Location = new Point(299, 1111);
            TotalLastPast.Name = "TotalLastPast";
            TotalLastPast.Size = new Size(22, 25);
            TotalLastPast.TabIndex = 18;
            TotalLastPast.Text = "0";
            // 
            // mainTable
            // 
            mainTable.AllowUserToAddRows = false;
            mainTable.AllowUserToDeleteRows = false;
            mainTable.BackgroundColor = SystemColors.Control;
            mainTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainTable.Columns.AddRange(new DataGridViewColumn[] { id, markName, SourcePath, itemSetBtn });
            mainTable.ContextMenuStrip = contextMenuMain;
            mainTable.Enabled = false;
            mainTable.Location = new Point(15, 66);
            mainTable.Margin = new Padding(3, 4, 3, 4);
            mainTable.Name = "mainTable";
            mainTable.ReadOnly = true;
            mainTable.RowHeadersWidth = 51;
            mainTable.RowTemplate.Height = 29;
            mainTable.Size = new Size(1793, 973);
            mainTable.TabIndex = 6;
            mainTable.CellClick += mainTable_CellClick;
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
            markName.MinimumWidth = 100;
            markName.Name = "markName";
            markName.ReadOnly = true;
            markName.Width = 300;
            // 
            // SourcePath
            // 
            SourcePath.Frozen = true;
            SourcePath.HeaderText = "备份路径";
            SourcePath.MinimumWidth = 800;
            SourcePath.Name = "SourcePath";
            SourcePath.ReadOnly = true;
            SourcePath.Width = 1200;
            // 
            // itemSetBtn
            // 
            itemSetBtn.Frozen = true;
            itemSetBtn.HeaderText = "是否自动备份&更多";
            itemSetBtn.MinimumWidth = 8;
            itemSetBtn.Name = "itemSetBtn";
            itemSetBtn.ReadOnly = true;
            itemSetBtn.Resizable = DataGridViewTriState.True;
            itemSetBtn.Width = 190;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(160, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(600, 34);
            textBox1.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(15, 13);
            label3.Name = "label3";
            label3.Size = new Size(128, 30);
            label3.TabIndex = 20;
            label3.Text = "备份库路径";
            // 
            // changeBackLocationBtn
            // 
            changeBackLocationBtn.Location = new Point(790, 12);
            changeBackLocationBtn.Name = "changeBackLocationBtn";
            changeBackLocationBtn.Size = new Size(200, 35);
            changeBackLocationBtn.TabIndex = 21;
            changeBackLocationBtn.Text = "修改备份库位置";
            changeBackLocationBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1832, 1168);
            Controls.Add(changeBackLocationBtn);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(TotalLastPast);
            Controls.Add(label1);
            Controls.Add(AboutBtn);
            Controls.Add(label2);
            Controls.Add(sfxCheckBox);
            Controls.Add(isStartUpCheckBox);
            Controls.Add(timeJudgeCheckBox);
            Controls.Add(notification);
            Controls.Add(mainTable);
            Controls.Add(SyCountDownLabel);
            Controls.Add(StopSyBtn);
            Controls.Add(AllExecuteBtn);
            Controls.Add(addBtn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            contextMenuMain.ResumeLayout(false);
            mainContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FolderBrowserDialog folderBrowserDialog1;
        private Button addBtn;
        private Button AllExecuteBtn;
        private ContextMenuStrip contextMenuMain;
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
        private Label label2;
        private Button AboutBtn;
        private Label label1;
        private Label TotalLastPast;
        private DataGridView mainTable;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn markName;
        private DataGridViewTextBoxColumn SourcePath;
        private DataGridViewButtonColumn itemSetBtn;
        private TextBox textBox1;
        private Label label3;
        private Button changeBackLocationBtn;
    }
}