namespace CTG_Control.Crane.view
{
    partial class AboutForm
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
            softwareNameLabel = new Label();
            SuspendLayout();
            // 
            // softwareNameLabel
            // 
            softwareNameLabel.AutoSize = true;
            softwareNameLabel.Location = new Point(34, 31);
            softwareNameLabel.Name = "softwareNameLabel";
            softwareNameLabel.Size = new Size(44, 17);
            softwareNameLabel.TabIndex = 0;
            softwareNameLabel.Text = "软件名";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(softwareNameLabel);
            Name = "AboutForm";
            Text = "关于软件";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label softwareNameLabel;
    }
}