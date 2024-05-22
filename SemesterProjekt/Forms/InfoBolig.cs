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
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db.GetAllBolig();
            aib = new AdvanceInfoBolig();
            DGVBolig.DataSource = null;
            DGVBolig.DataSource = db.GetAllBolig();

            // Formaterer de columns med de givende titler med formatet "N0"
            // som betyder Tusinde seperator uden tal til højre for 0
            this.DGVBolig.Columns["UdbudsPris"].DefaultCellStyle.Format = "N0";
            this.DGVBolig.Columns["SalgsPris"].DefaultCellStyle.Format = "N0";
            this.DGVBolig.Columns["KvmPris"].DefaultCellStyle.Format = "N0";

            int gns = AveragePrice();
            textBoxGns.Text = gns.ToString();
        }

        private void txtSearchbar_TextChanged(object sender, EventArgs e)
        {
            List<Bolig> filter = db.Searchbar(txtSearchbar.Text);
            DGVBolig.DataSource = filter;
            int gns = AveragePrice();
            textBoxGns.Text = gns.ToString();
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
            textBoxGns.Text = gns.ToString();
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
                int num1 = int.Parse(combobox.Split("-")[0]);
                int num2 = int.Parse(combobox.Split("-")[1]);
                List<Bolig> filter = db.GetAllBolig();
                DGVBolig.DataSource = filter.Where(b => b.PostNr >= num1 && b.PostNr <= num2).ToList();
            }
            int gns = AveragePrice();
            textBoxGns.Text = gns.ToString();
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
            textBoxGns.Text = gns.ToString();
        }

        private void dataGridViewBolig_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Henter info omkring ejendomsmægler som er koblet til bolig
            DbHandler db = new DbHandler();
            row = e.RowIndex;
            try
            {
            DataGridViewRow data = dataGridView1.Rows[row];
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
            textBox7.Text = sa.SFname + " " + sa.SLname;
            textBox6.Text = "" + sa.STlfNr;
            textBox5.Text = sa.SEmail;

            //Tilføjer information over i Mægler kassen
            EjendomsMaegler em = db.GetSingleEjendomsMaegler(MæglerId);
            textBox2.Text = em.MFname + " " + em.MLname;
            textBox3.Text = "" + em.MTlfNr;
            textBox4.Text = em.MEmail;

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
            aib.Show();
        }

        private void buttonOpdaterBolig_Click(object sender, EventArgs e)
        {
            UpdateBoligForm updateBolig = new UpdateBoligForm(MæglerId, Adresse, BoligIid, PostNr, Udbudspris, Kvadratmeter, BoligType, Aktiv);
            updateBolig.Show();
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

       
    }
}
