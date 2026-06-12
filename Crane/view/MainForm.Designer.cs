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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            chooseBackLocation = new System.Windows.Forms.FolderBrowserDialog();
            contextMenuMain = new System.Windows.Forms.ContextMenuStrip(components);
            sssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DeleteCurrent = new System.Windows.Forms.ToolStripMenuItem();
            restoreItem = new System.Windows.Forms.ToolStripMenuItem();
            mainNotifyIcon = new System.Windows.Forms.NotifyIcon(components);
            SyCountDownLabel = new System.Windows.Forms.Label();
            StopSyBtn = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            TotalLastPast = new System.Windows.Forms.Label();
            mainTable = new System.Windows.Forms.DataGridView();
            id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            markName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SourcePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            itemSetBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            backLocationInput = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            backLocationLock = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addItem = new System.Windows.Forms.ToolStripMenuItem();
            allExecute = new System.Windows.Forms.ToolStripMenuItem();
            aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            settingItem = new System.Windows.Forms.ToolStripMenuItem();
            compressionProgressBar = new System.Windows.Forms.ProgressBar();
            compressionProgressLabel = new System.Windows.Forms.Label();
            contextMenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainTable).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuMain
            // 
            contextMenuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { sssToolStripMenuItem, DeleteCurrent, restoreItem });
            contextMenuMain.Name = "contextMenuMain";
            contextMenuMain.Size = new System.Drawing.Size(423, 94);
            contextMenuMain.Text = "项";
            // 
            // sssToolStripMenuItem
            // 
            sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            sssToolStripMenuItem.Size = new System.Drawing.Size(422, 30);
            sssToolStripMenuItem.Text = "执行压缩（！注意确认左边三角标选择行）";
            sssToolStripMenuItem.Click += ExecuteBtn_Click;
            // 
            // DeleteCurrent
            // 
            DeleteCurrent.Name = "DeleteCurrent";
            DeleteCurrent.Size = new System.Drawing.Size(422, 30);
            DeleteCurrent.Text = "删除当前指向行项";
            DeleteCurrent.Click += DeleteCurrent_Click;
            // 
            // restoreItem
            // 
            restoreItem.Name = "restoreItem";
            restoreItem.Size = new System.Drawing.Size(422, 30);
            restoreItem.Text = "从目标地址覆盖还原（点我默认第一个）";
            restoreItem.Click += restoreItem_Click;
            restoreItem.MouseHover += restoreItem_MouseHover;
            // 
            // mainNotifyIcon
            // 
            mainNotifyIcon.Icon = ((System.Drawing.Icon)resources.GetObject("mainNotifyIcon.Icon"));
            mainNotifyIcon.Text = "mainNotifyIcon";
            mainNotifyIcon.Visible = true;
            mainNotifyIcon.MouseClick += mainNotifyIcon_MouseClick;
            // 
            // SyCountDownLabel
            // 
            SyCountDownLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            SyCountDownLabel.AutoSize = true;
            SyCountDownLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            SyCountDownLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)192)), ((int)((byte)0)), ((int)((byte)0)));
            SyCountDownLabel.Location = new System.Drawing.Point(16, 887);
            SyCountDownLabel.MaximumSize = new System.Drawing.Size(0, 163);
            SyCountDownLabel.Name = "SyCountDownLabel";
            SyCountDownLabel.Size = new System.Drawing.Size(220, 31);
            SyCountDownLabel.TabIndex = 8;
            SyCountDownLabel.Text = "x秒后启动同步程序";
            SyCountDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SyCountDownLabel.Click += SyCountDownLabel_Click;
            // 
            // StopSyBtn
            // 
            StopSyBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            StopSyBtn.BackColor = System.Drawing.Color.Brown;
            StopSyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            StopSyBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.285714F, System.Drawing.FontStyle.Bold);
            StopSyBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            StopSyBtn.Location = new System.Drawing.Point(1319, 876);
            StopSyBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            StopSyBtn.Name = "StopSyBtn";
            StopSyBtn.Size = new System.Drawing.Size(186, 42);
            StopSyBtn.TabIndex = 7;
            StopSyBtn.Text = "终止自动同步";
            StopSyBtn.UseVisualStyleBackColor = false;
            StopSyBtn.Click += StopSyBtn_Click;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            label2.ForeColor = System.Drawing.Color.Navy;
            label2.Location = new System.Drawing.Point(293, 890);
            label2.MaximumSize = new System.Drawing.Size(0, 163);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(222, 28);
            label2.TabIndex = 15;
            label2.Text = "所有项执行时间总计：";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            label1.ForeColor = System.Drawing.Color.Navy;
            label1.Location = new System.Drawing.Point(672, 893);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 28);
            label1.TabIndex = 17;
            label1.Text = "分钟";
            // 
            // TotalLastPast
            // 
            TotalLastPast.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            TotalLastPast.AutoSize = true;
            TotalLastPast.Location = new System.Drawing.Point(573, 893);
            TotalLastPast.Name = "TotalLastPast";
            TotalLastPast.Size = new System.Drawing.Size(21, 24);
            TotalLastPast.TabIndex = 18;
            TotalLastPast.Text = "0";
            // 
            // mainTable
            // 
            mainTable.AllowUserToAddRows = false;
            mainTable.AllowUserToDeleteRows = false;
            mainTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            mainTable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            mainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { id, markName, SourcePath, itemSetBtn });
            mainTable.ContextMenuStrip = contextMenuMain;
            mainTable.Location = new System.Drawing.Point(24, 70);
            mainTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            mainTable.Name = "mainTable";
            mainTable.ReadOnly = true;
            mainTable.RowHeadersWidth = 51;
            mainTable.RowTemplate.Height = 29;
            mainTable.Size = new System.Drawing.Size(1793, 798);
            mainTable.TabIndex = 6;
            mainTable.CellClick += mainTable_CellClick;
            mainTable.CellContentClick += mainTable_CellContentClick;
            mainTable.CellMouseDown += MainTable_CellMouseDown;
            // 
            // id
            // 
            id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 313;
            // 
            // markName
            // 
            markName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            markName.HeaderText = "标识";
            markName.MinimumWidth = 100;
            markName.Name = "markName";
            markName.ReadOnly = true;
            markName.Width = 314;
            // 
            // SourcePath
            // 
            SourcePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            SourcePath.HeaderText = "备份路径";
            SourcePath.MinimumWidth = 800;
            SourcePath.Name = "SourcePath";
            SourcePath.ReadOnly = true;
            SourcePath.Width = 800;
            // 
            // itemSetBtn
            // 
            itemSetBtn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            itemSetBtn.HeaderText = "更多";
            itemSetBtn.MinimumWidth = 8;
            itemSetBtn.Name = "itemSetBtn";
            itemSetBtn.ReadOnly = true;
            itemSetBtn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            itemSetBtn.Width = 313;
            // 
            // backLocationInput
            // 
            backLocationInput.Enabled = false;
            backLocationInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            backLocationInput.Location = new System.Drawing.Point(162, 34);
            backLocationInput.Name = "backLocationInput";
            backLocationInput.Size = new System.Drawing.Size(660, 34);
            backLocationInput.TabIndex = 19;
            backLocationInput.Click += backLocationInput_Click;
            backLocationInput.TextChanged += backLocationInput_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            label3.Location = new System.Drawing.Point(24, 37);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(132, 28);
            label3.TabIndex = 20;
            label3.Text = "备份库路径：";
            // 
            // backLocationLock
            // 
            backLocationLock.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            backLocationLock.Location = new System.Drawing.Point(1597, 36);
            backLocationLock.Name = "backLocationLock";
            backLocationLock.Size = new System.Drawing.Size(220, 30);
            backLocationLock.TabIndex = 21;
            backLocationLock.Text = "解锁备份库路径";
            backLocationLock.UseVisualStyleBackColor = true;
            backLocationLock.Click += backLocationLock_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 功能ToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1829, 36);
            menuStrip1.TabIndex = 22;
            menuStrip1.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { addItem, allExecute, aboutItem, settingItem });
            功能ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            功能ToolStripMenuItem.Size = new System.Drawing.Size(70, 32);
            功能ToolStripMenuItem.Text = "功能";
            // 
            // addItem
            // 
            addItem.Name = "addItem";
            addItem.Size = new System.Drawing.Size(198, 36);
            addItem.Text = "添加项";
            addItem.Click += addItem_Click;
            // 
            // allExecute
            // 
            allExecute.Name = "allExecute";
            allExecute.Size = new System.Drawing.Size(198, 36);
            allExecute.Text = "一键执行";
            allExecute.Click += allExecute_Click;
            // 
            // aboutItem
            // 
            aboutItem.Name = "aboutItem";
            aboutItem.Size = new System.Drawing.Size(198, 36);
            aboutItem.Text = "关于软件";
            aboutItem.Click += aboutItem_Click;
            // 
            // settingItem
            // 
            settingItem.Name = "settingItem";
            settingItem.Size = new System.Drawing.Size(198, 36);
            settingItem.Text = "设置";
            settingItem.Click += settingItem_Click;
            // 
            // compressionProgressBar
            // 
            compressionProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            compressionProgressBar.Location = new System.Drawing.Point(842, 883);
            compressionProgressBar.Name = "compressionProgressBar";
            compressionProgressBar.Size = new System.Drawing.Size(456, 29);
            compressionProgressBar.TabIndex = 23;
            // 
            // compressionProgressLabel
            // 
            compressionProgressLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            compressionProgressLabel.AutoSize = true;
            compressionProgressLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            compressionProgressLabel.ForeColor = System.Drawing.Color.Navy;
            compressionProgressLabel.Location = new System.Drawing.Point(842, 853);
            compressionProgressLabel.Name = "compressionProgressLabel";
            compressionProgressLabel.Size = new System.Drawing.Size(148, 28);
            compressionProgressLabel.TabIndex = 24;
            compressionProgressLabel.Text = "压缩进度：0%";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(1829, 937);
            Controls.Add(compressionProgressLabel);
            Controls.Add(compressionProgressBar);
            Controls.Add(menuStrip1);
            Controls.Add(backLocationLock);
            Controls.Add(label3);
            Controls.Add(backLocationInput);
            Controls.Add(TotalLastPast);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(mainTable);
            Controls.Add(SyCountDownLabel);
            Controls.Add(StopSyBtn);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            contextMenuMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainTable).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FolderBrowserDialog chooseBackLocation;
        private Button addBtn;
        private ContextMenuStrip contextMenuMain;
        private ToolStripMenuItem sssToolStripMenuItem;
        private ToolStripMenuItem DeleteCurrent;
        private NotifyIcon mainNotifyIcon;
        private System.Windows.Forms.Label SyCountDownLabel;
        private Button StopSyBtn;
        private ToolStripMenuItem restoreItem;
        private Label label2;
        private Label label1;
        private Label TotalLastPast;
        private DataGridView mainTable;
        public TextBox backLocationInput;
        private Label label3;
        private Button backLocationLock;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 功能ToolStripMenuItem;
        private ToolStripMenuItem addItem;
        private ToolStripMenuItem allExecute;
        private ToolStripMenuItem aboutItem;
        private ToolStripMenuItem settingItem;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn markName;
        private DataGridViewTextBoxColumn SourcePath;
        private DataGridViewButtonColumn itemSetBtn;
        private ProgressBar compressionProgressBar;
        private Label compressionProgressLabel;
    }
}