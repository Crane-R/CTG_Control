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
            isAuto = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // SureBtn
            // 
            SureBtn.Location = new Point(633, 97);
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
            addSourcePath.Location = new Point(107, 40);
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
            addTargetPath.Location = new Point(107, 68);
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
            DefaultUpPathCBox.Location = new Point(12, 102);
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
            markNameBox.Location = new Point(107, 9);
            markNameBox.Name = "markNameBox";
            markNameBox.Size = new Size(613, 23);
            markNameBox.TabIndex = 4;
            markNameBox.Click += markNameBox_Click;
            markNameBox.Leave += markNameBox_Leave;
            // 
            // isAuto
            // 
            isAuto.AutoSize = true;
            isAuto.Checked = true;
            isAuto.CheckState = CheckState.Checked;
            isAuto.Location = new Point(212, 102);
            isAuto.Name = "isAuto";
            isAuto.Size = new Size(99, 21);
            isAuto.TabIndex = 5;
            isAuto.Text = "是否自动备份";
            isAuto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 6;
            label1.Text = "标识名：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(74, 21);
            label2.TabIndex = 7;
            label2.Text = "源路径：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 70);
            label3.Name = "label3";
            label3.Size = new Size(90, 21);
            label3.TabIndex = 8;
            label3.Text = "目标路径：";
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 146);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(isAuto);
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
        private CheckBox isAuto;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}