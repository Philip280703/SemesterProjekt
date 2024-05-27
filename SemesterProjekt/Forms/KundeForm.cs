using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SemesterProjekt.DataAccess;
using SemesterProjekt.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SemesterProjekt.Forms
{

    public partial class KundeForm : Form
    {
        DbHandler db;
        int row;

        //Gemmer alle værdier i Kunde modellen
        int KId;
        string KFname;
        string KLname;
        int KBoligId;
        string KEmail;
        int KTlfNr;

        // Gemmer alle værdier fra bolig til dvg
        int BoligIid;
        string Adresse;
        int PostNr;
        int Udbudspris;
        int Kvadratmeter;
        string BoligType;
        bool Aktiv;
        int MæglerId;
        int BoligId;


        public KundeForm()
        {
            db = new DbHandler();
            InitializeComponent();
            DGVKunde.DataSource = db.GetAllKunder();
        }

        private void DGVKunde_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            db = new DbHandler();
            row = e.RowIndex;

            try
            {
                DataGridViewRow data = DGVKunde.Rows[row];
                KId = (int)data.Cells["KId"].Value;
                KFname = (string)data.Cells["KFname"].Value;
                KLname = (string)data.Cells["KLname"].Value;
                KBoligId = (int)data.Cells["KBoligId"].Value;
                KEmail = (string)data.Cells["KEmail"].Value;
                KTlfNr = (int)data.Cells["KTlfNr"].Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Bolig> boliger = db.GetAllBolig();
            this.

            DGV_Kunde_Bolig.DataSource = boliger.Where(b => b.BoligId == KBoligId).ToList();
            this.DGV_Kunde_Bolig.Columns["Udbudspris"].DefaultCellStyle.Format = "C0";
            this.DGV_Kunde_Bolig.Columns["Salgspris"].DefaultCellStyle.Format = "C0";


        }





        private void DGVKunde_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Henter info omkring kunde som er koblet til bolig
            DbHandler db = new DbHandler();
            row = e.RowIndex;
            try
            {
                DataGridViewRow data = DGVKunde.Rows[row];
                KId = (int)data.Cells["KId"].Value;
                KFname = (string)data.Cells["KFname"].Value;
                KLname = (string)data.Cells["KLname"].Value;
                KBoligId = (int)data.Cells["KBoligId"].Value;
                KEmail = (string)data.Cells["KEmail"].Value;
                KTlfNr = (int)data.Cells["KTlfNr"].Value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (KBoligId < 1)
            {

                textbox_MaeglerNavn.Text = " ";
                Txtbox_MaeglerTlf.Text = "";
                Txtbox_MaeglerEmail.Text = "";

                Txtbox_SaelgerNavn.Text = "";
                Txtbox_SælgerTlfnr.Text = "";
                Txtbox_SaelgerEmail.Text = "";
            }

        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            Newkunde nk = new Newkunde();
            nk.Show();
        }

        private void DGV_Kunde_Bolig_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Henter info omkring ejendomsmægler som er koblet til bolig
            DbHandler db = new DbHandler();
            row = e.RowIndex;
            try
            {
                DataGridViewRow data = DGV_Kunde_Bolig.Rows[row];

                MæglerId = (int)data.Cells["MaeglerId"].Value;
                Adresse = (string)data.Cells["Adresse"].Value;
                BoligIid = (int)data.Cells["BoligId"].Value;
                PostNr = (int)data.Cells["PostNr"].Value;
                Udbudspris = (int)data.Cells["UdbudsPris"].Value;
                Kvadratmeter = (int)data.Cells["Kvadratmeter"].Value;
                BoligType = (string)data.Cells["BoligType"].Value;
                Aktiv = (bool)data.Cells["Aktiv"].Value;
                BoligId = (int)data.Cells["BoligId"].Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (KBoligId < 1)
            {

                textbox_MaeglerNavn.Text = " ";
                Txtbox_MaeglerTlf.Text = "";
                Txtbox_MaeglerEmail.Text = "";

                Txtbox_SaelgerNavn.Text = "";
                Txtbox_SælgerTlfnr.Text = "";
                Txtbox_SaelgerEmail.Text = "";
            }
            else
            {

                //Tilføjer informationer over i Sælger kassen
                Saelger sa = db.GetSingleSaelgerBasedOfBoligId(BoligId);
                Txtbox_SaelgerNavn.Text = sa.SFname + " " + sa.SLname;
                Txtbox_SælgerTlfnr.Text = "" + sa.STlfNr;
                Txtbox_SaelgerEmail.Text = sa.SEmail;

                //Tilføjer information over i Mægler kassen
                EjendomsMaegler em = db.GetSingleEjendomsMaegler(MæglerId);
                textbox_MaeglerNavn.Text = em.MFname + " " + em.MLname;
                Txtbox_MaeglerTlf.Text = "" + em.MTlfNr;
                Txtbox_MaeglerEmail.Text = em.MEmail;
            }


        }

        public void UpdateKundeData()
        {
            DGVKunde.Refresh();
            DGVKunde.Update();
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            OpdaterKundeform kf = new OpdaterKundeform(KFname, KLname, KEmail, KTlfNr, KId);
            kf.Show();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Er du sikker på du gerne vil slette Køberen", "Advarsel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                db.HardDeleteKundeFromDB(KId);
                MessageBox.Show("Køberen er slettet");
            }
            else
            {
            }
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            DGVKunde.DataSource = db.GetAllKunder();
            DGVKunde.ClearSelection();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            KundeSortering();
        }

        private void KundeSortering()
        {
            try

            {
                List<Kunde> kundelist = db.GetAllKunder();
                // Søgbar ændring

                if (!string.IsNullOrEmpty(TxtSearch.Text))
                {
                    kundelist = kundelist.Where(k => k.KFname.Contains(TxtSearch.Text)).ToList();
                }

                DGVKunde.DataSource = kundelist;
                DGVKunde.ClearSelection();
            }
            catch (Exception ex)
            {
             MessageBox.Show($"Error: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }

    
}
