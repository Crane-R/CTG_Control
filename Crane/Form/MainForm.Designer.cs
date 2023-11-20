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
            contextMenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainTable).BeginInit();
            SuspendLayout();
            // 
            // contextMenuMain
            // 
            contextMenuMain.ImageScalingSize = new Size(20, 20);
            contextMenuMain.Items.AddRange(new ToolStripItem[] { sssToolStripMenuItem, DeleteCurrent });
            contextMenuMain.Name = "contextMenuMain";
            contextMenuMain.Size = new Size(383, 52);
            // 
            // sssToolStripMenuItem
            // 
            sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            sssToolStripMenuItem.Size = new Size(382, 24);
            sssToolStripMenuItem.Text = "执行压缩（！注意确认左边三角标选择行）";
            sssToolStripMenuItem.Click += ExecuteBtn_Click;
            // 
            // DeleteCurrent
            // 
            DeleteCurrent.Name = "DeleteCurrent";
            DeleteCurrent.Size = new Size(382, 24);
            DeleteCurrent.Text = "删除当前指向行项";
            DeleteCurrent.Click += DeleteCurrent_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(1375, 12);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(150, 50);
            addBtn.TabIndex = 4;
            addBtn.Text = "添加项";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += AddBtn_Click;
            // 
            // AllExecuteBtn
            // 
            AllExecuteBtn.Location = new Point(1375, 68);
            AllExecuteBtn.Name = "AllExecuteBtn";
            AllExecuteBtn.Size = new Size(150, 50);
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
            mainTable.Location = new Point(12, 12);
            mainTable.Name = "mainTable";
            mainTable.RowHeadersWidth = 51;
            mainTable.RowTemplate.Height = 29;
            mainTable.Size = new Size(1352, 620);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1537, 644);
            Controls.Add(mainTable);
            Controls.Add(AllExecuteBtn);
            Controls.Add(addBtn);
            Name = "MainForm";
            Load += MainForm_Load;
            contextMenuMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainTable).EndInit();
            ResumeLayout(false);
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
    }
}