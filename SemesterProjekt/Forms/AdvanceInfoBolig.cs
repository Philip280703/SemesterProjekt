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
        DbHandler db;
        int row;
        int KId;

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
            db = new DbHandler();
            DGVKunder.DataSource = db.GetAllKunder();
        }


        private void btn_Tilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DGVKunder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;
            try
            {
                DataGridViewRow data = DGVKunder.Rows[row];

                KId = (int)data.Cells["Kid"].Value;
                textBoxKundeId.Text = KId.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void SælgBolig_Click(object sender, EventArgs e)
        {
            DbHandler db = new DbHandler();
            int boligiid = int.Parse(BoligIdTextBox.Text);
            DateTime Salgsdatoen = Salgsdato.Value;
            db.MarkBoligAsSold(new Models.Bolig { Aktiv = false, SalgsDato = Salgsdatoen, SalgsPris = int.Parse(Salgspris.Text) }, boligiid);
           

            db.UpdateKunde(new Models.Kunde { KBoligId = boligiid }, KId);
            MessageBox.Show("Bolig er nu solgt!");
            this.Hide();
        }

    }
}
