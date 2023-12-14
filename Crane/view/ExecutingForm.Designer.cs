namespace CTG_Control.Crane
{
    partial class ExecutingForm
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
            progressBar = new ProgressBar();
            progressBarLabel = new Label();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(72, 43);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(595, 70);
            progressBar.TabIndex = 0;
            progressBar.Click += progressBar_Click;
            // 
            // progressBarLabel
            // 
            progressBarLabel.AutoSize = true;
            progressBarLabel.Font = new Font("Microsoft YaHei UI", 12.1008406F, FontStyle.Bold, GraphicsUnit.Point);
            progressBarLabel.Location = new Point(72, 132);
            progressBarLabel.Name = "progressBarLabel";
            progressBarLabel.Size = new Size(92, 27);
            progressBarLabel.TabIndex = 1;
            progressBarLabel.Text = "进度显示";
            // 
            // ExecutingForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 196);
            Controls.Add(progressBarLabel);
            Controls.Add(progressBar);
            Name = "ExecutingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ExecutingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ProgressBar progressBar;
        public Label progressBarLabel;
    }
}