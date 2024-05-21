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
            BoligIdLabel = new Label();
            AdresseLabel = new Label();
            BoligIdTextBox = new TextBox();
            AdresseTextbox = new TextBox();
            SuspendLayout();
            // 
            // BoligIdLabel
            // 
            BoligIdLabel.AutoSize = true;
            BoligIdLabel.Location = new Point(12, 9);
            BoligIdLabel.Name = "BoligIdLabel";
            BoligIdLabel.Size = new Size(44, 15);
            BoligIdLabel.TabIndex = 0;
            BoligIdLabel.Text = "BoligId";
            // 
            // AdresseLabel
            // 
            AdresseLabel.AutoSize = true;
            AdresseLabel.Location = new Point(8, 38);
            AdresseLabel.Name = "AdresseLabel";
            AdresseLabel.Size = new Size(48, 15);
            AdresseLabel.TabIndex = 1;
            AdresseLabel.Text = "Adresse";
            // 
            // BoligIdTextBox
            // 
            BoligIdTextBox.Location = new Point(62, 6);
            BoligIdTextBox.Name = "BoligIdTextBox";
            BoligIdTextBox.ReadOnly = true;
            BoligIdTextBox.Size = new Size(149, 23);
            BoligIdTextBox.TabIndex = 3;
            // 
            // AdresseTextbox
            // 
            AdresseTextbox.Location = new Point(62, 35);
            AdresseTextbox.Name = "AdresseTextbox";
            AdresseTextbox.ReadOnly = true;
            AdresseTextbox.Size = new Size(149, 23);
            AdresseTextbox.TabIndex = 4;
            // 
            // AdvanceInfoBolig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(815, 244);
            Controls.Add(AdresseTextbox);
            Controls.Add(BoligIdTextBox);
            Controls.Add(AdresseLabel);
            Controls.Add(BoligIdLabel);
            Name = "AdvanceInfoBolig";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BoligIdLabel;
        private Label AdresseLabel;
        private TextBox BoligIdTextBox;
        private TextBox AdresseTextbox;
    }
}