namespace SemesterProjekt.Forms
{
    partial class NewBoligForm
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
            button1 = new Button();
            MæglerIdLabel = new Label();
            BoligTypeLabel = new Label();
            KvadratmeterLabel = new Label();
            KvadratmeterTextbox = new TextBox();
            label1 = new Label();
            UdbudsprisTextbox = new TextBox();
            PostNrLabel = new Label();
            AdresseTextbox = new TextBox();
            AdresseLabel = new Label();
            groupBox1 = new GroupBox();
            comboBox3 = new ComboBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            groupBox2 = new GroupBox();
            label4 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            button2 = new Button();
            label6 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 401);
            button1.Name = "button1";
            button1.Size = new Size(75, 37);
            button1.TabIndex = 59;
            button1.Text = "Tilbage";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MæglerIdLabel
            // 
            MæglerIdLabel.AutoSize = true;
            MæglerIdLabel.Location = new Point(44, 225);
            MæglerIdLabel.Name = "MæglerIdLabel";
            MæglerIdLabel.Size = new Size(73, 20);
            MæglerIdLabel.TabIndex = 58;
            MæglerIdLabel.Text = "MæglerId";
            // 
            // BoligTypeLabel
            // 
            BoligTypeLabel.AutoSize = true;
            BoligTypeLabel.Location = new Point(36, 190);
            BoligTypeLabel.Name = "BoligTypeLabel";
            BoligTypeLabel.Size = new Size(75, 20);
            BoligTypeLabel.TabIndex = 54;
            BoligTypeLabel.Text = "BoligType";
            // 
            // KvadratmeterLabel
            // 
            KvadratmeterLabel.AutoSize = true;
            KvadratmeterLabel.Location = new Point(21, 155);
            KvadratmeterLabel.Name = "KvadratmeterLabel";
            KvadratmeterLabel.Size = new Size(98, 20);
            KvadratmeterLabel.TabIndex = 50;
            KvadratmeterLabel.Text = "Kvadratmeter";
            // 
            // KvadratmeterTextbox
            // 
            KvadratmeterTextbox.Location = new Point(117, 151);
            KvadratmeterTextbox.Margin = new Padding(3, 4, 3, 4);
            KvadratmeterTextbox.Name = "KvadratmeterTextbox";
            KvadratmeterTextbox.Size = new Size(170, 27);
            KvadratmeterTextbox.TabIndex = 49;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 116);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 48;
            label1.Text = "Udbudspris";
            // 
            // UdbudsprisTextbox
            // 
            UdbudsprisTextbox.Location = new Point(117, 112);
            UdbudsprisTextbox.Margin = new Padding(3, 4, 3, 4);
            UdbudsprisTextbox.Name = "UdbudsprisTextbox";
            UdbudsprisTextbox.Size = new Size(170, 27);
            UdbudsprisTextbox.TabIndex = 47;
            // 
            // PostNrLabel
            // 
            PostNrLabel.AutoSize = true;
            PostNrLabel.Location = new Point(60, 77);
            PostNrLabel.Name = "PostNrLabel";
            PostNrLabel.Size = new Size(52, 20);
            PostNrLabel.TabIndex = 46;
            PostNrLabel.Text = "PostNr";
            // 
            // AdresseTextbox
            // 
            AdresseTextbox.Location = new Point(117, 35);
            AdresseTextbox.Margin = new Padding(3, 4, 3, 4);
            AdresseTextbox.Name = "AdresseTextbox";
            AdresseTextbox.Size = new Size(170, 27);
            AdresseTextbox.TabIndex = 44;
            // 
            // AdresseLabel
            // 
            AdresseLabel.AutoSize = true;
            AdresseLabel.Location = new Point(55, 39);
            AdresseLabel.Name = "AdresseLabel";
            AdresseLabel.Size = new Size(61, 20);
            AdresseLabel.TabIndex = 42;
            AdresseLabel.Text = "Adresse";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox3);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(KvadratmeterTextbox);
            groupBox1.Controls.Add(MæglerIdLabel);
            groupBox1.Controls.Add(AdresseLabel);
            groupBox1.Controls.Add(BoligTypeLabel);
            groupBox1.Controls.Add(AdresseTextbox);
            groupBox1.Controls.Add(KvadratmeterLabel);
            groupBox1.Controls.Add(PostNrLabel);
            groupBox1.Controls.Add(UdbudsprisTextbox);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(91, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(327, 279);
            groupBox1.TabIndex = 60;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bolig informationer";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "100", "101", "102" });
            comboBox3.Location = new Point(117, 222);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(169, 28);
            comboBox3.TabIndex = 64;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1000", "2000", "3000", "4000", "5000", "6000", "7000", "7080", "7100", "7200", "8000", "9000" });
            comboBox1.Location = new Point(117, 74);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(169, 28);
            comboBox1.TabIndex = 63;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Villa", "Rækkehus", "Lejlighed", "Andelsbolig" });
            comboBox2.Location = new Point(117, 187);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(169, 28);
            comboBox2.TabIndex = 62;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(451, 57);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(289, 223);
            groupBox2.TabIndex = 61;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sælger af boligen";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 115);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 67;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 154);
            label5.Name = "label5";
            label5.Size = new Size(29, 20);
            label5.TabIndex = 68;
            label5.Text = "Tlf.";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(90, 112);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(170, 27);
            textBox3.TabIndex = 69;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(90, 151);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(170, 27);
            textBox4.TabIndex = 70;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 38);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 63;
            label2.Text = "Fornavn";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(90, 35);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(170, 27);
            textBox1.TabIndex = 65;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 77);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 64;
            label3.Text = "Efternavn";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(90, 74);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(170, 27);
            textBox2.TabIndex = 66;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlLight;
            button2.Location = new Point(515, 300);
            button2.Name = "button2";
            button2.Size = new Size(161, 67);
            button2.TabIndex = 62;
            button2.Text = "Sæt til Salg";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(118, 20);
            label6.TabIndex = 63;
            label6.Text = "Ny bolig til salg";
            // 
            // NewBoligForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Name = "NewBoligForm";
            Text = "NewBoligForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label MæglerIdLabel;
        private Label BoligTypeLabel;
        private Label KvadratmeterLabel;
        private TextBox KvadratmeterTextbox;
        private Label label1;
        private TextBox UdbudsprisTextbox;
        private Label PostNrLabel;
        private TextBox AdresseTextbox;
        private Label AdresseLabel;
        private GroupBox groupBox1;
        private ComboBox comboBox2;
        private GroupBox groupBox2;
        private Label label4;
        private Label label5;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Button button2;
        private Label label6;
        private ComboBox comboBox1;
        private ComboBox comboBox3;
    }
}