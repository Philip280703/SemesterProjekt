﻿using SemesterProjekt.DataAccess;
using SemesterProjekt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SemesterProjekt.Forms
{
    public partial class EjendomsmæglerForm : Form
    {
        DbHandler db;

        //Variabler der kan/skal gemmes (Mægler)
        int row;
        int MaeglerId;
        string MFname;
        string MLname;
        bool MAktiv;
        string MEmail;
        int MTlfNr;
        int Afdeling;

        //Variabler der skal gemmes (Sælger)
        int BoligIid;
        string Adresse;
        int PostNr;
        int Udbudspris;
        int Kvadratmeter;
        string BoligType;
        bool Aktiv;




        public EjendomsmæglerForm()
        {
            InitializeComponent();
            db = new DbHandler();
            Dgv_Mægler.DataSource = db.GetAllEjendomsMaegler();
            
        }

        private void Dgv_Mægler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            db = new DbHandler();
            row = e.RowIndex;

            try
            {
                DataGridViewRow data = Dgv_Mægler.Rows[row];
                MaeglerId = (int)data.Cells["MId"].Value;
                MFname = (string)data.Cells["MFname"].Value;
                MLname = (string)data.Cells["MLname"].Value;
                MAktiv = (bool)data.Cells["MAktiv"].Value;
                MEmail = (string)data.Cells["MEmail"].Value;
                MTlfNr = (int)data.Cells["MTlfNr"].Value;
                Afdeling = (int)data.Cells["Afdeling"].Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Viser alle aktive boliger i Aktiv DGV
            List<Bolig> Boliger = db.GetAllBolig();
            Dgv_Aktive_Boliger.DataSource = Boliger.Where(b => b.MaeglerId == MaeglerId && b.SalgsPris < 1).ToList();
            Dgv_Aktive_Boliger.ClearSelection();

            //Viser alle inaktive boliger i inaktiv DGV
            Dgv_Inaktive_Boliger.DataSource = Boliger.Where(b => b.MaeglerId == MaeglerId && b.SalgsPris > 1).ToList();
            Dgv_Inaktive_Boliger.ClearSelection();
        }

        private void Dgv_Aktive_Boliger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            db = new DbHandler();
            row = e.RowIndex;

            try
            {
                DataGridViewRow Data = Dgv_Aktive_Boliger.Rows[row];
                MaeglerId = (int)Data.Cells["MaeglerId"].Value;
                Adresse = (string)Data.Cells["Adresse"].Value;
                BoligIid = (int)Data.Cells["BoligId"].Value;
                PostNr = (int)Data.Cells["PostNr"].Value;
                Udbudspris = (int)Data.Cells["UdbudsPris"].Value;
                Kvadratmeter = (int)Data.Cells["Kvadratmeter"].Value;
                BoligType = (string)Data.Cells["BoligType"].Value;
                Aktiv = (bool)Data.Cells["Aktiv"].Value;
                this.Dgv_Aktive_Boliger.Columns["UdbudsPris"].DefaultCellStyle.Format = "C0";
                this.Dgv_Aktive_Boliger.Columns["SalgsPris"].DefaultCellStyle.Format = "C0";
                this.Dgv_Aktive_Boliger.Columns["KvmPris"].DefaultCellStyle.Format = "C0";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Saelger sa = db.GetSingleSaelgerBasedOfBoligId(BoligIid);
            TxtBox_Sælger_Navn.Text = sa.SFname + " " + sa.SLname;
            TxtBox_Sælger_Email.Text = sa.SEmail;
            TxtBox_Sælger_TlfNr.Text = "" + sa.STlfNr;

            TxtBox_Køber_TlfNr.Text = "";
            TxtBox_Køber_Navn.Text = "";
            TxtBox_Køber_Email.Text = "";

        }

        private void Dgv_Inaktive_Boliger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            db = new DbHandler();
            row = e.RowIndex;

            try
            {
                DataGridViewRow Data = Dgv_Inaktive_Boliger.Rows[row];
                MaeglerId = (int)Data.Cells["MaeglerId"].Value;
                Adresse = (string)Data.Cells["Adresse"].Value;
                BoligIid = (int)Data.Cells["BoligId"].Value;
                PostNr = (int)Data.Cells["PostNr"].Value;
                Udbudspris = (int)Data.Cells["UdbudsPris"].Value;
                Kvadratmeter = (int)Data.Cells["Kvadratmeter"].Value;
                BoligType = (string)Data.Cells["BoligType"].Value;
                Aktiv = (bool)Data.Cells["Aktiv"].Value;
                this.Dgv_Aktive_Boliger.Columns["UdbudsPris"].DefaultCellStyle.Format = "C0";
                this.Dgv_Aktive_Boliger.Columns["SalgsPris"].DefaultCellStyle.Format = "C0";
                this.Dgv_Aktive_Boliger.Columns["KvmPris"].DefaultCellStyle.Format = "C0";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Saelger sa = db.GetSingleSaelgerBasedOfBoligId(BoligIid);
            TxtBox_Sælger_Navn.Text = sa.SFname + " " + sa.SLname;
            TxtBox_Sælger_Email.Text = sa.SEmail;
            TxtBox_Sælger_TlfNr.Text = "" + sa.STlfNr;

            Kunde ku = db.GetSingleKundeBasedOfBoligId(BoligIid);
            TxtBox_Køber_Email.Text = ku.KEmail;
            TxtBox_Køber_Navn.Text = ku.KFname + " " + ku.KLname;
            TxtBox_Køber_TlfNr.Text = "" + ku.KTlfNr;
        }

        private void EjendomsmæglerForm_Load(object sender, EventArgs e)
        {
            //Gør så Der ikke automatisk vælges 1 row i DGV 
            Dgv_Mægler.ClearSelection();
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            NewMaeglerform newMaeglerform = new NewMaeglerform();
            newMaeglerform.Show();
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            OpdaterMaeglerForm opdaterMaegler = new OpdaterMaeglerForm(MaeglerId, MFname, MLname, MEmail, MTlfNr, Afdeling);
            opdaterMaegler.Show();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            var updater = MessageBox.Show("Ejendomsmægler inaktiv", "Vil du gøre denne Ejendomsmægler inaktiv", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (updater == DialogResult.Yes)
            {
                db.UpdateEjendomsMaeglerAktivitet(new EjendomsMaegler { MAktiv = false }, MaeglerId);
            }
            if (updater == DialogResult.No)
            {
                db.UpdateEjendomsMaeglerAktivitet(new EjendomsMaegler { MAktiv = true }, MaeglerId);
            }
            MessageBox.Show("Ejendomsmægler aktivitet er nu opdateret");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Dgv_Mægler.DataSource = db.GetAllEjendomsMaegler();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
         
            var AreyouSure = MessageBox.Show("Er du sikker på at du vil slette denne Ejendomsmægler permanent?", "", MessageBoxButtons.YesNo);

            if (AreyouSure == DialogResult.Yes)
            {
                db.HardDeleteEjendomsMaeglerFromDB(MaeglerId);             
                MessageBox.Show("Boligen er nu solgt");
            }
        }
    }
}
