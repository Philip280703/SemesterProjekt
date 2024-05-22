using SemesterProjekt.DataAccess;
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
        InfoBolig ib;
        Panel panel;

        public AdvanceInfoBolig()
        {
            InitializeComponent();
        }

        public AdvanceInfoBolig(int MæglerId, string Adresse, int BoligId, int PostNr, int Udbudspris, int Kvadratmeter, string BoligType, bool aktiv)
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


        private void btn_Tilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SælgBolig_Click(object sender, EventArgs e)
        {
            DbHandler db = new DbHandler();
            AdvanceInfoBolig aib = new AdvanceInfoBolig();
            int boligiid = int.Parse(BoligIdTextBox.Text);
            DateTime Salgsdatoen = Salgsdato.Value;
            bool aktiv = false;
            db.MarkBoligAsSold(new Models.Bolig { Aktiv = aktiv, SalgsDato = Salgsdatoen, SalgsPris = int.Parse(Salgspris.Text) }, boligiid);
            MessageBox.Show("Bolig er nu solgt!");
            InfoBolig ib = new InfoBolig();
            Homepage hp = new Homepage();
            this.Hide();
        }

        private void txtbox_BoligId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_Adresse(object sender, EventArgs e)
        {

        }

        private void txtbox_PostNr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_Udbudspris_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_Kvadratmeter_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxKvmPris_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_BoligType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_Aktiv_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_maelgerId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
