namespace CTG_Control.Crane.view
{
    partial class DetailMore
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
            IsAutoBack = new CheckBox();
            IntervalValue = new TextBox();
            label1 = new Label();
            SureBtn = new Button();
            label2 = new Label();
            LastBackTime = new Label();
            label4 = new Label();
            LastBackPast = new Label();
            label3 = new Label();
            label5 = new Label();
            ChooseStandard = new ComboBox();
            SuspendLayout();
            // 
            // IsAutoBack
            // 
            IsAutoBack.AutoSize = true;
            IsAutoBack.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            IsAutoBack.Location = new Point(19, 101);
            IsAutoBack.Margin = new Padding(5, 4, 5, 4);
            IsAutoBack.Name = "IsAutoBack";
            IsAutoBack.Size = new Size(144, 28);
            IsAutoBack.TabIndex = 0;
            IsAutoBack.Text = "是否自动备份";
            IsAutoBack.UseVisualStyleBackColor = true;
            // 
            // IntervalValue
            // 
            IntervalValue.Location = new Point(183, 140);
            IntervalValue.Margin = new Padding(5, 4, 5, 4);
            IntervalValue.Name = "IntervalValue";
            IntervalValue.Size = new Size(73, 30);
            IntervalValue.TabIndex = 1;
            IntervalValue.Leave += IntervalValue_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(19, 143);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(154, 24);
            label1.TabIndex = 2;
            label1.Text = "自动备份时间间隔";
            // 
            // SureBtn
            // 
            SureBtn.Location = new Point(603, 251);
            SureBtn.Margin = new Padding(5, 4, 5, 4);
            SureBtn.Name = "SureBtn";
            SureBtn.Size = new Size(168, 51);
            SureBtn.TabIndex = 4;
            SureBtn.Text = "确定";
            SureBtn.UseVisualStyleBackColor = true;
            SureBtn.Click += SureBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 19);
            label2.Name = "label2";
            label2.Size = new Size(136, 24);
            label2.TabIndex = 5;
            label2.Text = "最近执行日期：";
            // 
            // LastBackTime
            // 
            LastBackTime.AutoSize = true;
            LastBackTime.Location = new Point(175, 19);
            LastBackTime.Name = "LastBackTime";
            LastBackTime.Size = new Size(154, 24);
            LastBackTime.TabIndex = 6;
            LastBackTime.Text = "显示最近执行日期";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 59);
            label4.Name = "label4";
            label4.Size = new Size(136, 24);
            label4.TabIndex = 7;
            label4.Text = "最近执行用时：";
            // 
            // LastBackPast
            // 
            LastBackPast.AutoSize = true;
            LastBackPast.Location = new Point(175, 59);
            LastBackPast.Name = "LastBackPast";
            LastBackPast.Size = new Size(154, 24);
            LastBackPast.TabIndex = 8;
            LastBackPast.Text = "显示最近执行用时";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(266, 143);
            label3.Name = "label3";
            label3.Size = new Size(46, 24);
            label3.TabIndex = 9;
            label3.Text = "小时";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(335, 59);
            label5.Name = "label5";
            label5.Size = new Size(46, 24);
            label5.TabIndex = 10;
            label5.Text = "分钟";
            // 
            // ChooseStandard
            // 
            ChooseStandard.FormattingEnabled = true;
            ChooseStandard.Items.AddRange(new object[] { "慢速项", "中速项", "快速项" });
            ChooseStandard.Location = new Point(318, 138);
            ChooseStandard.Name = "ChooseStandard";
            ChooseStandard.Size = new Size(130, 32);
            ChooseStandard.TabIndex = 13;
            ChooseStandard.Text = "标准值选择";
            ChooseStandard.SelectedIndexChanged += ChooseStandard_SelectedIndexChanged;
            // 
            // DetailMore
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 319);
            Controls.Add(ChooseStandard);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(LastBackPast);
            Controls.Add(label4);
            Controls.Add(LastBackTime);
            Controls.Add(label2);
            Controls.Add(SureBtn);
            Controls.Add(label1);
            Controls.Add(IntervalValue);
            Controls.Add(IsAutoBack);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5, 4, 5, 4);
            Name = "DetailMore";
            StartPosition = FormStartPosition.CenterParent;
            Text = "详情&更多";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox IsAutoBack;
        private TextBox IntervalValue;
        private Label label1;
        private Button SureBtn;
        private Label label2;
        private Label LastBackTime;
        private Label label4;
        private Label LastBackPast;
        private Label label3;
        private Label label5;
        private ComboBox ChooseStandard;
    }
}