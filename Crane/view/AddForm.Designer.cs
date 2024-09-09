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
            label4 = new Label();
            IntervalValue = new TextBox();
            IntervalUnit = new Label();
            ChooseStandard = new ComboBox();
            SuspendLayout();
            // 
            // SureBtn
            // 
            SureBtn.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SureBtn.Location = new Point(969, 142);
            SureBtn.Margin = new Padding(3, 4, 3, 4);
            SureBtn.Name = "SureBtn";
            SureBtn.Size = new Size(160, 60);
            SureBtn.TabIndex = 0;
            SureBtn.Text = "确认";
            SureBtn.UseVisualStyleBackColor = true;
            SureBtn.Click += SureBtn_Click;
            // 
            // addSourcePath
            // 
            addSourcePath.ForeColor = SystemColors.ScrollBar;
            addSourcePath.Location = new Point(168, 56);
            addSourcePath.Margin = new Padding(3, 4, 3, 4);
            addSourcePath.Name = "addSourcePath";
            addSourcePath.Size = new Size(961, 30);
            addSourcePath.TabIndex = 1;
            addSourcePath.Click += AddSourcePath_Click;
            addSourcePath.Leave += addSourcePath_Leave;
            // 
            // addTargetPath
            // 
            addTargetPath.ForeColor = Color.Black;
            addTargetPath.Location = new Point(168, 96);
            addTargetPath.Margin = new Padding(3, 4, 3, 4);
            addTargetPath.Name = "addTargetPath";
            addTargetPath.Size = new Size(961, 30);
            addTargetPath.TabIndex = 2;
            addTargetPath.Click += AddTargetPath_Click;
            addTargetPath.Leave += addTargetPath_Leave;
            // 
            // DefaultUpPathCBox
            // 
            DefaultUpPathCBox.AutoSize = true;
            DefaultUpPathCBox.Location = new Point(19, 144);
            DefaultUpPathCBox.Margin = new Padding(3, 4, 3, 4);
            DefaultUpPathCBox.Name = "DefaultUpPathCBox";
            DefaultUpPathCBox.Size = new Size(288, 28);
            DefaultUpPathCBox.TabIndex = 3;
            DefaultUpPathCBox.Text = "将该次目标地址设为默认上传点";
            DefaultUpPathCBox.UseVisualStyleBackColor = true;
            // 
            // markNameBox
            // 
            markNameBox.ForeColor = SystemColors.ScrollBar;
            markNameBox.Location = new Point(168, 13);
            markNameBox.Margin = new Padding(5, 4, 5, 4);
            markNameBox.Name = "markNameBox";
            markNameBox.Size = new Size(961, 30);
            markNameBox.TabIndex = 4;
            markNameBox.Click += markNameBox_Click;
            markNameBox.Leave += markNameBox_Leave;
            // 
            // isAuto
            // 
            isAuto.AutoSize = true;
            isAuto.Checked = true;
            isAuto.CheckState = CheckState.Checked;
            isAuto.Location = new Point(19, 180);
            isAuto.Margin = new Padding(5, 4, 5, 4);
            isAuto.Name = "isAuto";
            isAuto.Size = new Size(144, 28);
            isAuto.TabIndex = 5;
            isAuto.Text = "是否自动备份";
            isAuto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(19, 15);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 6;
            label1.Text = "标识名：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(19, 56);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 28);
            label2.TabIndex = 7;
            label2.Text = "源路径：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(19, 99);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 28);
            label3.TabIndex = 8;
            label3.Text = "目标路径：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(401, 145);
            label4.Name = "label4";
            label4.Size = new Size(136, 24);
            label4.TabIndex = 9;
            label4.Text = "自动备份间隔：";
            // 
            // IntervalValue
            // 
            IntervalValue.Location = new Point(543, 142);
            IntervalValue.Name = "IntervalValue";
            IntervalValue.Size = new Size(61, 30);
            IntervalValue.TabIndex = 10;
            // 
            // IntervalUnit
            // 
            IntervalUnit.AutoSize = true;
            IntervalUnit.Location = new Point(610, 145);
            IntervalUnit.Name = "IntervalUnit";
            IntervalUnit.Size = new Size(46, 24);
            IntervalUnit.TabIndex = 11;
            IntervalUnit.Text = "小时";
            // 
            // ChooseStandard
            // 
            ChooseStandard.FormattingEnabled = true;
            ChooseStandard.Items.AddRange(new object[] { "慢速项", "中速项", "快速项" });
            ChooseStandard.Location = new Point(662, 142);
            ChooseStandard.Name = "ChooseStandard";
            ChooseStandard.Size = new Size(130, 32);
            ChooseStandard.TabIndex = 12;
            ChooseStandard.Text = "标准值选择";
            ChooseStandard.SelectedIndexChanged += ChooseStandard_SelectedIndexChanged;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1153, 224);
            Controls.Add(ChooseStandard);
            Controls.Add(IntervalUnit);
            Controls.Add(IntervalValue);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(isAuto);
            Controls.Add(markNameBox);
            Controls.Add(DefaultUpPathCBox);
            Controls.Add(addTargetPath);
            Controls.Add(addSourcePath);
            Controls.Add(SureBtn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
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
        private Label label4;
        private TextBox IntervalValue;
        private Label IntervalUnit;
        private ComboBox ChooseStandard;
    }
}