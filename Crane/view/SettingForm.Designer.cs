namespace CTG_Control.Crane.view
{
    partial class SettingForm
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
            isAutoBack = new CheckBox();
            textBox1 = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // isAutoBack
            // 
            isAutoBack.AutoSize = true;
            isAutoBack.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            isAutoBack.Location = new Point(12, 12);
            isAutoBack.Name = "isAutoBack";
            isAutoBack.Size = new Size(125, 25);
            isAutoBack.TabIndex = 0;
            isAutoBack.Text = "是否自动备份";
            isAutoBack.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(156, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 57);
            label1.Name = "label1";
            label1.Size = new Size(138, 21);
            label1.TabIndex = 2;
            label1.Text = "自动备份时间间隔";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "天", "周", "月" });
            comboBox1.Location = new Point(262, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(100, 25);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(384, 178);
            button1.Name = "button1";
            button1.Size = new Size(107, 36);
            button1.TabIndex = 4;
            button1.Text = "确定";
            button1.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 226);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(isAutoBack);
            Name = "SettingForm";
            Text = "SettingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox isAutoBack;
        private TextBox textBox1;
        private Label label1;
        private ComboBox comboBox1;
        private Button button1;
    }
}