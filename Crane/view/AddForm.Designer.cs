namespace CTG_Control.crane.form
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            SureBtn = new Button();
            addSourcePath = new TextBox();
            addTargetPath = new TextBox();
            ChooseSourcePath = new FolderBrowserDialog();
            ChooseTargetPath = new FolderBrowserDialog();
            DefaultUpPathCBox = new CheckBox();
            markNameBox = new TextBox();
            SuspendLayout();
            // 
            // SureBtn
            // 
            SureBtn.Location = new Point(561, 106);
            SureBtn.Margin = new Padding(2, 3, 2, 3);
            SureBtn.Name = "SureBtn";
            SureBtn.Size = new Size(87, 26);
            SureBtn.TabIndex = 0;
            SureBtn.Text = "确认";
            SureBtn.UseVisualStyleBackColor = true;
            SureBtn.Click += SureBtn_Click;
            // 
            // addSourcePath
            // 
            addSourcePath.ForeColor = SystemColors.ScrollBar;
            addSourcePath.Location = new Point(35, 41);
            addSourcePath.Margin = new Padding(2, 3, 2, 3);
            addSourcePath.Name = "addSourcePath";
            addSourcePath.Size = new Size(613, 23);
            addSourcePath.TabIndex = 1;
            addSourcePath.Click += AddSourcePath_Click;
            addSourcePath.Leave += addSourcePath_Leave;
            // 
            // addTargetPath
            // 
            addTargetPath.ForeColor = Color.Black;
            addTargetPath.Location = new Point(35, 70);
            addTargetPath.Margin = new Padding(2, 3, 2, 3);
            addTargetPath.Name = "addTargetPath";
            addTargetPath.Size = new Size(613, 23);
            addTargetPath.TabIndex = 2;
            addTargetPath.Click += AddTargetPath_Click;
            addTargetPath.Leave += addTargetPath_Leave;
            // 
            // DefaultUpPathCBox
            // 
            DefaultUpPathCBox.AutoSize = true;
            DefaultUpPathCBox.Location = new Point(235, 111);
            DefaultUpPathCBox.Margin = new Padding(2, 3, 2, 3);
            DefaultUpPathCBox.Name = "DefaultUpPathCBox";
            DefaultUpPathCBox.Size = new Size(195, 21);
            DefaultUpPathCBox.TabIndex = 3;
            DefaultUpPathCBox.Text = "将该次目标地址设为默认上传点";
            DefaultUpPathCBox.UseVisualStyleBackColor = true;
            // 
            // markNameBox
            // 
            markNameBox.ForeColor = SystemColors.ScrollBar;
            markNameBox.Location = new Point(35, 12);
            markNameBox.Name = "markNameBox";
            markNameBox.Size = new Size(613, 23);
            markNameBox.TabIndex = 4;
            markNameBox.Click += markNameBox_Click;
            markNameBox.Leave += markNameBox_Leave;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 148);
            Controls.Add(markNameBox);
            Controls.Add(DefaultUpPathCBox);
            Controls.Add(addTargetPath);
            Controls.Add(addSourcePath);
            Controls.Add(SureBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 3, 2, 3);
            Name = "AddForm";
            Text = "添加项";
            Load += AddForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SureBtn;
        private TextBox addSourcePath;
        private TextBox addTargetPath;
        private FolderBrowserDialog ChooseSourcePath;
        private FolderBrowserDialog ChooseTargetPath;
        private CheckBox DefaultUpPathCBox;
        private TextBox markNameBox;
    }
}