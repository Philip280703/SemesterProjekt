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
    public partial class AdvanceInfoBolig : Form
    {
        public AdvanceInfoBolig()
        {
            InitializeComponent();
        }

        public AdvanceInfoBolig(int MæglerId, string Adresse, int BoligId, int PostNr, int Udbudspris, int Kvadratmeter, string BoligType, bool aktiv)
        {
            InitializeComponent();
            BoligIdTextBox.Text = "" + MæglerId;
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

        private void TilbageButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
