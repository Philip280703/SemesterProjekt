namespace SemesterProjekt.Forms
{
    partial class AdvanceInfoBolig
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
            BackButton = new Button();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 405);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(115, 33);
            BackButton.TabIndex = 0;
            BackButton.Text = "Tilbage";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // AdvanceInfoBolig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BackButton);
            Name = "AdvanceInfoBolig";
            Text = "Form3";
            ResumeLayout(false);
        }

        #endregion

        private Button BackButton;
    }
}