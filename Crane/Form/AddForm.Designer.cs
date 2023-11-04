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
            SureBtn = new Button();
            addSourcePath = new TextBox();
            addTargetPath = new TextBox();
            ChooseSourcePath = new FolderBrowserDialog();
            ChooseTargetPath = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // SureBtn
            // 
            SureBtn.Location = new Point(640, 107);
            SureBtn.Name = "SureBtn";
            SureBtn.Size = new Size(100, 30);
            SureBtn.TabIndex = 0;
            SureBtn.Text = "确认";
            SureBtn.UseVisualStyleBackColor = true;
            SureBtn.Click += SureBtn_Click;
            // 
            // addSourcePath
            // 
            addSourcePath.ForeColor = SystemColors.ScrollBar;
            addSourcePath.Location = new Point(40, 12);
            addSourcePath.Name = "addSourcePath";
            addSourcePath.Size = new Size(700, 27);
            addSourcePath.TabIndex = 1;
            addSourcePath.Click += AddSourcePath_Click;
            // 
            // addTargetPath
            // 
            addTargetPath.ForeColor = Color.Silver;
            addTargetPath.Location = new Point(40, 59);
            addTargetPath.Name = "addTargetPath";
            addTargetPath.Size = new Size(700, 27);
            addTargetPath.TabIndex = 2;
            addTargetPath.Click += AddTargetPath_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 154);
            Controls.Add(addTargetPath);
            Controls.Add(addSourcePath);
            Controls.Add(SureBtn);
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
    }
}