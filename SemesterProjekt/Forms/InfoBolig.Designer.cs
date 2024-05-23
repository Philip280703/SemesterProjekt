namespace SemesterProjekt.Forms
{
    partial class InfoBolig
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
            panel1 = new Panel();
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox7 = new TextBox();
            label8 = new Label();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ScreenPnl = new Panel();
            button5 = new Button();
            btn_ExportToCSV = new Button();
            lblGnsKvm = new Label();
            textBoxGns = new TextBox();
            Sletbolig_button = new Button();
            Aktiv_checkbox = new CheckBox();
            Refreshbutton = new Button();
            comboBoxPris = new ComboBox();
            comboBoxPostNr = new ComboBox();
            ComboBoxBoligtype = new ComboBox();
            txtSearchbar = new TextBox();
            DGVBolig = new DataGridView();
            panel1.SuspendLayout();
            ScreenPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVBolig).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1029, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(318, 891);
            panel1.TabIndex = 1;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ControlDark;
            button4.Dock = DockStyle.Bottom;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(0, 663);
            button4.Margin = new Padding(3, 5, 3, 5);
            button4.Name = "button4";
            button4.Size = new Size(318, 76);
            button4.TabIndex = 16;
            button4.Text = "Opret Bolig";
            button4.UseVisualStyleBackColor = false;
            button4.Click += buttonNyBolig_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDark;
            button2.Dock = DockStyle.Bottom;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(0, 739);
            button2.Margin = new Padding(3, 5, 3, 5);
            button2.Name = "button2";
            button2.Size = new Size(318, 76);
            button2.TabIndex = 15;
            button2.Text = "Opdater Udbudspris";
            button2.UseVisualStyleBackColor = false;
            button2.Click += buttonOpdaterBolig_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Dock = DockStyle.Bottom;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 815);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(318, 76);
            button1.TabIndex = 14;
            button1.Text = "Sælg Bolig";
            button1.UseVisualStyleBackColor = false;
            button1.Click += buttonSaelgBolig_Click;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top;
            textBox5.Location = new Point(9, 515);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(297, 27);
            textBox5.TabIndex = 13;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(9, 486);
            label6.Name = "label6";
            label6.Size = new Size(54, 23);
            label6.TabIndex = 12;
            label6.Text = "Email";
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top;
            textBox6.Location = new Point(9, 451);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(297, 27);
            textBox6.TabIndex = 11;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(9, 422);
            label7.Name = "label7";
            label7.Size = new Size(57, 23);
            label7.TabIndex = 10;
            label7.Text = "Tlf Nr";
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.Top;
            textBox7.Location = new Point(9, 387);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(297, 27);
            textBox7.TabIndex = 9;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(9, 358);
            label8.Name = "label8";
            label8.Size = new Size(51, 23);
            label8.TabIndex = 8;
            label8.Text = "Navn";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 303);
            label5.Name = "label5";
            label5.Size = new Size(318, 89);
            label5.TabIndex = 7;
            label5.Text = "Sælger";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top;
            textBox4.Location = new Point(9, 255);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(297, 27);
            textBox4.TabIndex = 6;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(9, 225);
            label4.Name = "label4";
            label4.Size = new Size(54, 23);
            label4.TabIndex = 5;
            label4.Text = "Email";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top;
            textBox3.Location = new Point(9, 191);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(297, 27);
            textBox3.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(9, 161);
            label3.Name = "label3";
            label3.Size = new Size(57, 23);
            label3.TabIndex = 3;
            label3.Text = "Tlf Nr";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top;
            textBox2.Location = new Point(9, 127);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(297, 27);
            textBox2.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(9, 97);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 1;
            label2.Text = "Navn";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(2, 42);
            label1.Name = "label1";
            label1.Size = new Size(318, 89);
            label1.TabIndex = 0;
            label1.Text = "Mægler";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ScreenPnl
            // 
            ScreenPnl.Controls.Add(button5);
            ScreenPnl.Controls.Add(btn_ExportToCSV);
            ScreenPnl.Controls.Add(lblGnsKvm);
            ScreenPnl.Controls.Add(textBoxGns);
            ScreenPnl.Controls.Add(Sletbolig_button);
            ScreenPnl.Controls.Add(Aktiv_checkbox);
            ScreenPnl.Controls.Add(Refreshbutton);
            ScreenPnl.Controls.Add(comboBoxPris);
            ScreenPnl.Controls.Add(comboBoxPostNr);
            ScreenPnl.Controls.Add(ComboBoxBoligtype);
            ScreenPnl.Controls.Add(txtSearchbar);
            ScreenPnl.Controls.Add(DGVBolig);
            ScreenPnl.Dock = DockStyle.Fill;
            ScreenPnl.Location = new Point(0, 0);
            ScreenPnl.Margin = new Padding(3, 4, 3, 4);
            ScreenPnl.Name = "ScreenPnl";
            ScreenPnl.Size = new Size(1029, 891);
            ScreenPnl.TabIndex = 2;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(706, 11);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(122, 31);
            button5.TabIndex = 21;
            button5.Text = "Exp. postnr CSV";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // btn_ExportToCSV
            // 
            btn_ExportToCSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_ExportToCSV.Location = new Point(834, 12);
            btn_ExportToCSV.Margin = new Padding(3, 4, 3, 4);
            btn_ExportToCSV.Name = "btn_ExportToCSV";
            btn_ExportToCSV.Size = new Size(86, 31);
            btn_ExportToCSV.TabIndex = 20;
            btn_ExportToCSV.Text = "Exp. CSV";
            btn_ExportToCSV.UseVisualStyleBackColor = true;
            btn_ExportToCSV.Click += btn_ExportToCSV_Click;
            // 
            // lblGnsKvm
            // 
            lblGnsKvm.AutoSize = true;
            lblGnsKvm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGnsKvm.Location = new Point(544, 808);
            lblGnsKvm.Name = "lblGnsKvm";
            lblGnsKvm.Size = new Size(270, 31);
            lblGnsKvm.TabIndex = 19;
            lblGnsKvm.Text = "Gennemsnitlig KvmPris:";
            // 
            // textBoxGns
            // 
            textBoxGns.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxGns.Location = new Point(820, 805);
            textBoxGns.Name = "textBoxGns";
            textBoxGns.ReadOnly = true;
            textBoxGns.Size = new Size(178, 38);
            textBoxGns.TabIndex = 18;
            // 
            // Sletbolig_button
            // 
            Sletbolig_button.Location = new Point(14, 815);
            Sletbolig_button.Name = "Sletbolig_button";
            Sletbolig_button.Size = new Size(99, 34);
            Sletbolig_button.TabIndex = 17;
            Sletbolig_button.Text = "Slet bolig";
            Sletbolig_button.UseVisualStyleBackColor = true;
            Sletbolig_button.Click += Sletbolig_button_Click;
            // 
            // Aktiv_checkbox
            // 
            Aktiv_checkbox.AutoSize = true;
            Aktiv_checkbox.Location = new Point(800, 16);
            Aktiv_checkbox.Name = "Aktiv_checkbox";
            Aktiv_checkbox.Size = new Size(64, 24);
            Aktiv_checkbox.TabIndex = 6;
            Aktiv_checkbox.Text = "Aktiv";
            Aktiv_checkbox.UseVisualStyleBackColor = true;
            Aktiv_checkbox.CheckedChanged += Aktiv_checkbox_CheckedChanged;
            // 
            // Refreshbutton
            // 
            Refreshbutton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Refreshbutton.Location = new Point(936, 11);
            Refreshbutton.Margin = new Padding(3, 4, 3, 4);
            Refreshbutton.Name = "Refreshbutton";
            Refreshbutton.Size = new Size(86, 31);
            Refreshbutton.TabIndex = 5;
            Refreshbutton.Text = "Refresh";
            Refreshbutton.UseVisualStyleBackColor = true;
            Refreshbutton.Click += Refreshbutton_Click;
            // 
            // comboBoxPris
            // 
            comboBoxPris.FormattingEnabled = true;
            comboBoxPris.Items.AddRange(new object[] { "Pris", "0 - 999999", "1000000 - 1999999", "2000000 - 2999999", "3000000 - 3999999", "4000000 - 4999999" });
            comboBoxPris.Location = new Point(677, 15);
            comboBoxPris.Margin = new Padding(3, 4, 3, 4);
            comboBoxPris.Name = "comboBoxPris";
            comboBoxPris.Size = new Size(108, 28);
            comboBoxPris.TabIndex = 4;
            comboBoxPris.Text = "Pris";
            comboBoxPris.SelectedIndexChanged += comboBoxPris_SelectedIndexChanged;
            // 
            // comboBoxPostNr
            // 
            comboBoxPostNr.FormattingEnabled = true;
            comboBoxPostNr.Items.AddRange(new object[] { "PostNr", "1000", "2000", "3000", "4000", "5000", "6000", "7000", "7080", "7100", "7200", "7400", "8000", "9000" });
            comboBoxPostNr.Location = new Point(569, 15);
            comboBoxPostNr.Margin = new Padding(3, 4, 3, 4);
            comboBoxPostNr.Name = "comboBoxPostNr";
            comboBoxPostNr.Size = new Size(100, 28);
            comboBoxPostNr.TabIndex = 3;
            comboBoxPostNr.Text = "PostNr";
            comboBoxPostNr.SelectedIndexChanged += comboBoxPostNr_SelectedIndexChanged;
            // 
            // ComboBoxBoligtype
            // 
            ComboBoxBoligtype.FormattingEnabled = true;
            ComboBoxBoligtype.Items.AddRange(new object[] { "BoligType", "Villa", "Lejlighed", "Rækkehus", "Andelsbolig" });
            ComboBoxBoligtype.Location = new Point(446, 15);
            ComboBoxBoligtype.Margin = new Padding(3, 4, 3, 4);
            ComboBoxBoligtype.Name = "ComboBoxBoligtype";
            ComboBoxBoligtype.Size = new Size(116, 28);
            ComboBoxBoligtype.TabIndex = 2;
            ComboBoxBoligtype.Text = "BoligType";
            ComboBoxBoligtype.SelectedIndexChanged += comboBoxBoligType_SelectedIndexChanged;
            // 
            // txtSearchbar
            // 
            txtSearchbar.Location = new Point(14, 15);
            txtSearchbar.Margin = new Padding(3, 4, 3, 4);
            txtSearchbar.Name = "txtSearchbar";
            txtSearchbar.PlaceholderText = "Adresse";
            txtSearchbar.Size = new Size(425, 27);
            txtSearchbar.TabIndex = 1;
            txtSearchbar.TextChanged += txtSearchbar_TextChanged;
            // 
            // DGVBolig
            // 
            DGVBolig.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVBolig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVBolig.BackgroundColor = SystemColors.Control;
            DGVBolig.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVBolig.Location = new Point(14, 55);
            DGVBolig.Margin = new Padding(3, 4, 3, 4);
            DGVBolig.Name = "DGVBolig";
            DGVBolig.ReadOnly = true;
            DGVBolig.RowHeadersWidth = 51;
            DGVBolig.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVBolig.Size = new Size(1008, 749);
            DGVBolig.TabIndex = 0;
            DGVBolig.CellMouseClick += dataGridViewBolig_CellMouseClick;
            // 
            // InfoBolig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1347, 891);
            Controls.Add(ScreenPnl);
            Controls.Add(panel1);
            Name = "InfoBolig";
            Text = "Form2";
            Load += InfoBolig_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ScreenPnl.ResumeLayout(false);
            ScreenPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVBolig).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel ScreenPnl;
        private DataGridView DGVBolig;
        private TextBox txtSearchbar;
        private ComboBox ComboBoxBoligtype;
        private ComboBox comboBoxPostNr;
        private TrackBar trackBar1;
        private ComboBox comboBoxPris;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox7;
        private Label label8;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button Refreshbutton;
        private Button button4;
        private CheckBox Aktiv_checkbox;
        private Button Sletbolig_button;
        private TextBox textBoxGns;
        private Label lblGnsKvm;
        private Button btn_ExportToCSV;
        private Button button5;
    }
}