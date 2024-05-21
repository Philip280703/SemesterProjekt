﻿using SemesterProjekt.DataAccess;
using SemesterProjekt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemesterProjekt.Forms
{
    public partial class UpdateBoligForm : Form
    {
        public UpdateBoligForm(int MæglerId, string Adresse, int BoligId, int PostNr, int Udbudspris, int Kvadratmeter, string BoligType, bool aktiv)
        {
            InitializeComponent();
            BoligIdTextBox.Text = "" + BoligId;
            AdresseTextbox.Text = Adresse;
            PostNrTextbox.Text = "" + PostNr;
            UdbudsprisTextbox.Text = "" + Udbudspris;
            KvadratmeterTextbox.Text = "" + Kvadratmeter;
            double kvmpris = Udbudspris / Kvadratmeter;
            KvmPrisTextBox.Text = "" + kvmpris;
            BoligTypeTextbox.Text = BoligType;
            AktivTextbox.Text = "" + aktiv;
            MaglerIdTextbox.Text = "" + MæglerId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InfoBolig ib = new InfoBolig();
            ib.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbHandler db = new DbHandler();
            int boligiid = int.Parse(BoligIdTextBox.Text);
            int nyudbudspris = int.Parse(textBox1.Text);
            db.UpdateBolig(new Bolig { UdbudsPris = nyudbudspris }, boligiid);
            MessageBox.Show("Boligens Udbudspris er opdateret");
            this.Hide();
            
        }
    }
}
