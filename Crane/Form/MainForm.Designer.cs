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
            folderBrowserDialog1 = new FolderBrowserDialog();
            mainTable = new ListView();
            sourcePath = new ColumnHeader();
            targetPath = new ColumnHeader();
            execution = new ColumnHeader();
            addBtn = new Button();
            AllExecuteBtn = new Button();
            SuspendLayout();
            // 
            // mainTable
            // 
            mainTable.Columns.AddRange(new ColumnHeader[] { sourcePath, targetPath, execution });
            mainTable.Location = new Point(12, 12);
            mainTable.Name = "mainTable";
            mainTable.Size = new Size(800, 400);
            mainTable.TabIndex = 3;
            mainTable.UseCompatibleStateImageBehavior = false;
            mainTable.View = View.Details;
            mainTable.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // sourcePath
            // 
            sourcePath.Text = "源路径";
            sourcePath.Width = 300;
            // 
            // targetPath
            // 
            targetPath.Text = "目标路径";
            targetPath.Width = 300;
            // 
            // execution
            // 
            execution.Text = "操作";
            execution.TextAlign = HorizontalAlignment.Center;
            execution.Width = 200;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(820, 12);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(150, 50);
            addBtn.TabIndex = 4;
            addBtn.Text = "添加项";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += AddBtn_Click;
            // 
            // AllExecuteBtn
            // 
            AllExecuteBtn.Location = new Point(820, 68);
            AllExecuteBtn.Name = "AllExecuteBtn";
            AllExecuteBtn.Size = new Size(150, 50);
            AllExecuteBtn.TabIndex = 5;
            AllExecuteBtn.Text = "一键执行";
            AllExecuteBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 454);
            Controls.Add(AllExecuteBtn);
            Controls.Add(addBtn);
            Controls.Add(mainTable);
            Name = "MainForm";
            Text = "CTG_Control v0.01";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private FolderBrowserDialog folderBrowserDialog1;
        public ListView mainTable;
        private ColumnHeader targetPath;
        private ColumnHeader execution;
        private Button addBtn;
        private Button AllExecuteBtn;
        private ColumnHeader sourcePath;
    }
}