using SemesterProjekt.DataAccess;
using SemesterProjekt.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemesterProjekt.Forms
{
    public partial class InfoBolig : Form
    {
        AdvanceInfoBolig aib;
        DbHandler db;
        int BoligIid;
        string Adresse;
        int PostNr;
        int Udbudspris;
        int Kvadratmeter;
        string BoligType;
        bool Aktiv;
        int MæglerId;
        int row;
        int BoligId;



        public InfoBolig()
        {
            InitializeComponent();
            db = new DbHandler();
            aib = new AdvanceInfoBolig();
            DGVBolig.DataSource = null;
            DGVBolig.DataSource = db.GetAllBolig();

            // Formaterer de columns med de givende titler med formatet "N0"
            // som betyder Tusinde seperator uden tal til højre for 0
            this.DGVBolig.Columns["UdbudsPris"].DefaultCellStyle.Format = "N0";
            this.DGVBolig.Columns["SalgsPris"].DefaultCellStyle.Format = "N0";
            this.DGVBolig.Columns["KvmPris"].DefaultCellStyle.Format = "N0";

            int gns = AveragePrice();
            textBoxGns.Text = $"{gns:C0}";
        }

        private void txtSearchbar_TextChanged(object sender, EventArgs e)
        {
            List<Bolig> filter = db.SearchbarBolig(txtSearchbar.Text);
            DGVBolig.DataSource = filter;
            int gns = AveragePrice();
            textBoxGns.Text = $"{gns:C0}";

            //Gør så Der ikke automatisk vælges 1 row i DGV
            DGVBolig.ClearSelection();
        }

        private void comboBoxBoligType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string combobox = ComboBoxBoligtype.Text;
            if (combobox == "BoligType")
            {
                DGVBolig.DataSource = db.GetAllBolig();
            }
            else
            {
                List<Bolig> filter = db.GetAllBolig();
                DGVBolig.DataSource = filter.Where(b => b.BoligType == combobox).ToList();
            }
            int gns = AveragePrice();
            textBoxGns.Text = $"{gns:C0}";

            //Gør så Der ikke automatisk vælges 1 row i DGV
            DGVBolig.ClearSelection();
        }
        private void comboBoxPostNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            string combobox = comboBoxPostNr.Text;
            if (combobox == "PostNr")
            {
                DGVBolig.DataSource = db.GetAllBolig();
            }
            else
            {

                List<Bolig> filter = db.GetAllBolig();

                DGVBolig.DataSource = filter.Where(b => b.PostNr == int.Parse(comboBoxPostNr.Text)).ToList();
            }
            int gns = AveragePrice();
            textBoxGns.Text = $"{gns:C0}";

            //Gør så Der ikke automatisk vælges 1 row i DGV
            DGVBolig.ClearSelection();
        }

        private void comboBoxPris_SelectedIndexChanged(object sender, EventArgs e)
        {
            string combobox = comboBoxPris.Text;
            if (combobox == "Pris")
            {
                DGVBolig.DataSource = db.GetAllBolig();
            }
            else
            {
                int num1 = int.Parse(combobox.Split("-")[0]);
                int num2 = int.Parse(combobox.Split("-")[1]);
                List<Bolig> filter = db.GetAllBolig();
                DGVBolig.DataSource = filter.Where(b => b.UdbudsPris >= num1 && b.UdbudsPris <= num2).ToList();
            }
            int gns = AveragePrice();
            textBoxGns.Text = $"{gns:C0}";

            //Gør så Der ikke automatisk vælges 1 row i DGV
            DGVBolig.ClearSelection();
        }

        private void comboxSortering_SelectedIndexChanged(object sender, EventArgs e)
        {
            string combox = comboxSortering.Text;
            if (combox == "Sortering") 
            {
                DGVBolig.DataSource = db.GetAllBolig();
            }
            else if (combox == "Adresse (alfabetisk)") {  List<Bolig> BoligSotering = db.GetAllBolig(); DGVBolig.DataSource = BoligSotering.OrderBy(b => b.Adresse).ToList(); }
            else if (combox == "Udbudspris (lav - høj)") { List<Bolig> BoligSortering = db.GetAllBolig(); DGVBolig.DataSource = BoligSortering.OrderBy(b => b.UdbudsPris).ToList(); }
            else if (combox == "Udbudspris (høj - lav)") { List<Bolig> BoligSortering = db.GetAllBolig(); DGVBolig.DataSource = BoligSortering.OrderByDescending(b => b.UdbudsPris).ToList(); }
            else if (combox == "Kvm (lav - høj)") { List<Bolig> BoligSortering = db.GetAllBolig(); DGVBolig.DataSource = BoligSortering.OrderBy(b => b.Kvadratmeter).ToList(); }
            else if (combox == "Kvm (høj - lav)") { List<Bolig> BoligSortering = db.GetAllBolig(); DGVBolig.DataSource = BoligSortering.OrderByDescending(b => b.Kvadratmeter).ToList(); }
            else if (combox == "Kvadratmeterpris (lav - høj)") { List<Bolig> BoligSortering = db.GetAllBolig(); DGVBolig.DataSource = BoligSortering.OrderBy(b => b.KvmPris).ToList(); }
            else if (combox == "Kvadratmeterpris (høj - lav)") { List<Bolig> BoligSortering = db.GetAllBolig(); DGVBolig.DataSource = BoligSortering.OrderByDescending(b => b.KvmPris).ToList(); }
            else if (combox == "Salgspris (lav - høj)") { List<Bolig> BoligSortering = db.GetAllBolig(); DGVBolig.DataSource = BoligSortering.OrderBy(b => b.SalgsPris).ToList(); }
            else if (combox == "Salgspris (høj - lav)") { List<Bolig> BoligSortering = db.GetAllBolig(); DGVBolig.DataSource = BoligSortering.OrderByDescending(b => b.SalgsPris).ToList(); }

            int gns = AveragePrice();
            textBoxGns.Text = $"{gns:C0}";

            DGVBolig.ClearSelection();
        }

        private void dataGridViewBolig_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Henter info omkring ejendomsmægler som er koblet til bolig
            DbHandler db = new DbHandler();
            row = e.RowIndex;
            try
            {
                DataGridViewRow data = DGVBolig.Rows[row];

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

            // Henter info omkring Sælger som er tilkoblet Bolig

        }


        private int AveragePrice()
        {
            // Beregn gennemsnit
            int sum = 0;
            for (int i = 0; i < DGVBolig.Rows.Count; i++)
            {
                sum += Convert.ToInt32(DGVBolig.Rows[i].Cells[5].Value);
            }
            int countRow = DGVBolig.Rows.Count;
            int gns = sum / countRow;
            return gns;

        }
        private void buttonSaelgBolig_Click(object sender, EventArgs e)
        {
            AdvanceInfoBolig aib = new AdvanceInfoBolig(MæglerId, Adresse, BoligIid, PostNr, Udbudspris, Kvadratmeter, BoligType, Aktiv);
            try
            {
                aib.Show();
            }
            catch (Exception ex)
            {

            }

        }

        private void buttonOpdaterBolig_Click(object sender, EventArgs e)
        {
            UpdateBoligForm updateBolig = new UpdateBoligForm(MæglerId, Adresse, BoligIid, PostNr, Udbudspris, Kvadratmeter, BoligType, Aktiv);

            try
            {
                updateBolig.Show();
            }
            catch (Exception ex) { }

        }

        private void Refreshbutton_Click(object sender, EventArgs e)
        {
            DGVBolig.DataSource = db.GetAllBolig();
        }

        private void buttonNyBolig_Click(object sender, EventArgs e)
        {
            NewBoligForm newBoligForm = new NewBoligForm();
            newBoligForm.Show();
        }


        private void Aktiv_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Aktiv_checkbox.Checked)
            {
                List<Bolig> Aktivbolig = db.GetAllBolig();
                List<Bolig> TrueAktivBolig = Aktivbolig.Where(b => b.SalgsPris < 1).ToList();
                DGVBolig.DataSource = TrueAktivBolig;
            }
            else
            {
                DGVBolig.DataSource = db.GetAllBolig();
            }
            //Gør så Der ikke automatisk vælges 1 row i DGV
            DGVBolig.ClearSelection();
        }

        private void Sletbolig_button_Click(object sender, EventArgs e)
        {
            DbHandler dbHandler = new DbHandler();
            var AreyouSure = MessageBox.Show("Er du sikker på at du vil slette denne bolig permanent?", "", MessageBoxButtons.YesNo);

            if (AreyouSure == DialogResult.Yes)
            {
                dbHandler.HardDeleteSaelgerFromDB(BoligIid);
                dbHandler.HardDeleteBoligFromDB(BoligIid);
                MessageBox.Show("Boligen er nu solgt");
            }

        }

        private void InfoBolig_Load(object sender, EventArgs e)
        {
            //Gør så Der ikke automatisk vælges 1 row i DGV når formen loades
            DGVBolig.ClearSelection();
        }

        private void btn_ExportToCSV_Click(object sender, EventArgs e)
        {
            var ExporttoCsv = MessageBox.Show("vil du eksportere alle boliger til en CSV fil?", "Export to csv", MessageBoxButtons.YesNo);
            if (ExporttoCsv == DialogResult.Yes)
            {
                try
                {
                    db.GetCSVAllBoligActive();
                    MessageBox.Show("Liste af alle aktive boliger er nu exporteret til din computer under mappen csv");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not able to Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ExportThistoCsv = MessageBox.Show("vil du eksportere alle boliger med dette postnummer til en CSV fil?", "Export to csv", MessageBoxButtons.YesNo);
            if (ExportThistoCsv == DialogResult.Yes)
            {
                try
                {
                    db.GetCSVEverything(int.Parse(comboBoxPostNr.Text));
                    MessageBox.Show("Listen er nu eksporteret til din mappe 'csv' ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Not able to Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
