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
            sureBtn = new Button();
            addSourcePath = new TextBox();
            addTargetPath = new TextBox();
            SuspendLayout();
            // 
            // sureBtn
            // 
            sureBtn.Location = new Point(460, 15);
            sureBtn.Name = "sureBtn";
            sureBtn.Size = new Size(93, 29);
            sureBtn.TabIndex = 0;
            sureBtn.Text = "确认";
            sureBtn.UseVisualStyleBackColor = true;
            // 
            // addSourcePath
            // 
            addSourcePath.ForeColor = SystemColors.ScrollBar;
            addSourcePath.Location = new Point(15, 15);
            addSourcePath.Name = "addSourcePath";
            addSourcePath.Size = new Size(200, 27);
            addSourcePath.TabIndex = 1;
            addSourcePath.Text = "点我选择他妈的源路径";
            addSourcePath.Click += AddSourcePath_Click;
            // 
            // addTargetPath
            // 
            addTargetPath.ForeColor = Color.Silver;
            addTargetPath.Location = new Point(230, 15);
            addTargetPath.Name = "addTargetPath";
            addTargetPath.Size = new Size(200, 27);
            addTargetPath.TabIndex = 2;
            addTargetPath.Text = "点我选择TM的目标路径";
            addTargetPath.Click += AddTargetPath_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 74);
            Controls.Add(addTargetPath);
            Controls.Add(addSourcePath);
            Controls.Add(sureBtn);
            Name = "AddForm";
            Text = "AddForm";
            Load += AddForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sureBtn;
        private TextBox addSourcePath;
        private TextBox addTargetPath;
    }
}