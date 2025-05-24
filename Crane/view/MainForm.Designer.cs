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
            chooseBackLocation = new FolderBrowserDialog();
            contextMenuMain = new ContextMenuStrip(components);
            sssToolStripMenuItem = new ToolStripMenuItem();
            DeleteCurrent = new ToolStripMenuItem();
            restoreItem = new ToolStripMenuItem();
            mainNotifyIcon = new NotifyIcon(components);
            SyCountDownLabel = new Label();
            StopSyBtn = new Button();
            label2 = new Label();
            label1 = new Label();
            TotalLastPast = new Label();
            mainTable = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            markName = new DataGridViewTextBoxColumn();
            SourcePath = new DataGridViewTextBoxColumn();
            itemSetBtn = new DataGridViewButtonColumn();
            backLocationInput = new TextBox();
            label3 = new Label();
            backLocationLock = new Button();
            menuStrip1 = new MenuStrip();
            功能ToolStripMenuItem = new ToolStripMenuItem();
            addItem = new ToolStripMenuItem();
            allExecute = new ToolStripMenuItem();
            aboutItem = new ToolStripMenuItem();
            settingItem = new ToolStripMenuItem();
            contextMenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainTable).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuMain
            // 
            contextMenuMain.ImageScalingSize = new Size(20, 20);
            contextMenuMain.Items.AddRange(new ToolStripItem[] { sssToolStripMenuItem, DeleteCurrent, restoreItem });
            contextMenuMain.Name = "contextMenuMain";
            contextMenuMain.Size = new Size(423, 94);
            contextMenuMain.Text = "项";
            // 
            // sssToolStripMenuItem
            // 
            sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            sssToolStripMenuItem.Size = new Size(422, 30);
            sssToolStripMenuItem.Text = "执行压缩（！注意确认左边三角标选择行）";
            sssToolStripMenuItem.Click += ExecuteBtn_Click;
            // 
            // DeleteCurrent
            // 
            DeleteCurrent.Name = "DeleteCurrent";
            DeleteCurrent.Size = new Size(422, 30);
            DeleteCurrent.Text = "删除当前指向行项";
            DeleteCurrent.Click += DeleteCurrent_Click;
            // 
            // restoreItem
            // 
            restoreItem.Name = "restoreItem";
            restoreItem.Size = new Size(422, 30);
            restoreItem.Text = "从目标地址覆盖还原（点我默认第一个）";
            restoreItem.Click += restoreItem_Click;
            restoreItem.MouseHover += restoreItem_MouseHover;
            // 
            // mainNotifyIcon
            // 
            mainNotifyIcon.Icon = (Icon)resources.GetObject("mainNotifyIcon.Icon");
            mainNotifyIcon.Text = "mainNotifyIcon";
            mainNotifyIcon.Visible = true;
            mainNotifyIcon.MouseClick += mainNotifyIcon_MouseClick;
            // 
            // SyCountDownLabel
            // 
            SyCountDownLabel.AutoSize = true;
            SyCountDownLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SyCountDownLabel.ForeColor = Color.FromArgb(192, 0, 0);
            SyCountDownLabel.Location = new Point(16, 1014);
            SyCountDownLabel.MaximumSize = new Size(0, 186);
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
            StopSyBtn.Location = new Point(1317, 1011);
            StopSyBtn.Margin = new Padding(3, 4, 3, 4);
            StopSyBtn.Name = "StopSyBtn";
            StopSyBtn.Size = new Size(186, 48);
            StopSyBtn.TabIndex = 7;
            StopSyBtn.Text = "终止自动同步";
            StopSyBtn.UseVisualStyleBackColor = false;
            StopSyBtn.Click += StopSyBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(293, 1017);
            label2.MaximumSize = new Size(0, 186);
            label2.Name = "label2";
            label2.Size = new Size(222, 28);
            label2.TabIndex = 15;
            label2.Text = "所有项执行时间总计：";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(672, 1021);
            label1.Name = "label1";
            label1.Size = new Size(54, 28);
            label1.TabIndex = 17;
            label1.Text = "分钟";
            // 
            // TotalLastPast
            // 
            TotalLastPast.AutoSize = true;
            TotalLastPast.Location = new Point(573, 1021);
            TotalLastPast.Name = "TotalLastPast";
            TotalLastPast.Size = new Size(21, 24);
            TotalLastPast.TabIndex = 18;
            TotalLastPast.Text = "0";
            // 
            // mainTable
            // 
            mainTable.AllowUserToAddRows = false;
            mainTable.AllowUserToDeleteRows = false;
            mainTable.BackgroundColor = SystemColors.ButtonFace;
            mainTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainTable.Columns.AddRange(new DataGridViewColumn[] { id, markName, SourcePath, itemSetBtn });
            mainTable.ContextMenuStrip = contextMenuMain;
            mainTable.Location = new Point(24, 80);
            mainTable.Margin = new Padding(3, 4, 3, 4);
            mainTable.Name = "mainTable";
            mainTable.ReadOnly = true;
            mainTable.RowHeadersWidth = 51;
            mainTable.RowTemplate.Height = 29;
            mainTable.Size = new Size(1793, 923);
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
            itemSetBtn.HeaderText = "更多";
            itemSetBtn.MinimumWidth = 8;
            itemSetBtn.Name = "itemSetBtn";
            itemSetBtn.ReadOnly = true;
            itemSetBtn.Resizable = DataGridViewTriState.True;
            itemSetBtn.Width = 190;
            // 
            // backLocationInput
            // 
            backLocationInput.Enabled = false;
            backLocationInput.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            backLocationInput.Location = new Point(162, 39);
            backLocationInput.Name = "backLocationInput";
            backLocationInput.Size = new Size(660, 34);
            backLocationInput.TabIndex = 19;
            backLocationInput.Click += backLocationInput_Click;
            backLocationInput.TextChanged += backLocationInput_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(24, 42);
            label3.Name = "label3";
            label3.Size = new Size(132, 28);
            label3.TabIndex = 20;
            label3.Text = "备份库路径：";
            // 
            // backLocationLock
            // 
            backLocationLock.Location = new Point(828, 39);
            backLocationLock.Name = "backLocationLock";
            backLocationLock.Size = new Size(220, 34);
            backLocationLock.TabIndex = 21;
            backLocationLock.Text = "解锁备份库路径";
            backLocationLock.UseVisualStyleBackColor = true;
            backLocationLock.Click += backLocationLock_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 功能ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1829, 36);
            menuStrip1.TabIndex = 22;
            menuStrip1.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            功能ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addItem, allExecute, aboutItem, settingItem });
            功能ToolStripMenuItem.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            功能ToolStripMenuItem.Size = new Size(70, 32);
            功能ToolStripMenuItem.Text = "功能";
            // 
            // addItem
            // 
            addItem.Name = "addItem";
            addItem.Size = new Size(198, 36);
            addItem.Text = "添加项";
            addItem.Click += addItem_Click;
            // 
            // allExecute
            // 
            allExecute.Name = "allExecute";
            allExecute.Size = new Size(198, 36);
            allExecute.Text = "一键执行";
            allExecute.Click += allExecute_Click;
            // 
            // aboutItem
            // 
            aboutItem.Name = "aboutItem";
            aboutItem.Size = new Size(198, 36);
            aboutItem.Text = "关于软件";
            aboutItem.Click += aboutItem_Click;
            // 
            // settingItem
            // 
            settingItem.Name = "settingItem";
            settingItem.Size = new Size(198, 36);
            settingItem.Text = "设置";
            settingItem.Click += settingItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1829, 1071);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Label SyCountDownLabel;
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
    }
}