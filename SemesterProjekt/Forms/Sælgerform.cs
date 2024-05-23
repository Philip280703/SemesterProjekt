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
    public partial class Sælgerform : Form
    {
        DbHandler db;
        int row;

        //Gemmer Alle Værdier i sælger modellen
        int SId;
        string SFname;
        string SLname;
        int SBoligId;
        string SEmail;
        int STlfNr;

        public Sælgerform()
        {
            db = new DbHandler();
            InitializeComponent();
            DGVSælger.DataSource = db.GetAllSaelger();
        }

        private void Sælgerform_Load(object sender, EventArgs e)
        {
            DGVSælger.ClearSelection();
        }

        private void TxtSearchbar_TextChanged(object sender, EventArgs e)
        {
            List<Saelger> FiltreretSaelger = db.SearchbarSælger(TxtSearch.Text);
            DGVSælger.DataSource = FiltreretSaelger;
            DGVSælger.ClearSelection();
        }

        private void DGVSælger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            db = new DbHandler();

            try
            {
                DataGridViewRow data = DGVSælger.Rows[row];
                SId = (int)data.Cells["SId"].Value;
                SFname = (string)data.Cells["SFname"].Value;
                SLname = (string)data.Cells["SLname"].Value;
                SBoligId = (int)data.Cells["SBoligId"].Value;
                SEmail = (string)data.Cells["SEmail"].Value;
                STlfNr = (int)data.Cells["STlfNr"].Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Filtrere så boligens id matcher med det boligid som er koblet på sælgeren
            List<Bolig> Boliger = db.GetAllBolig();
            DGV_Saelger_Bolig.DataSource = Boliger.Where(b => b.BoligId == SBoligId).ToList();
            DGV_Saelger_Bolig.ClearSelection();
        }

        private void Btn_Sorter_Solgt_Click(object sender, EventArgs e)
        {
            List<Bolig> BoligSolgt = db.GetAllBolig();
            DGV_Saelger_Bolig.DataSource = BoligSolgt.Where(b => b.SalgsPris > 1 && b.BoligId == SBoligId).ToList();
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            OpdaterSælger os = new OpdaterSælger(SId, SFname + " " + SLname, SBoligId, SEmail, STlfNr);
            os.Show();
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            DGVSælger.DataSource = db.GetAllSaelger();
            DGVSælger.ClearSelection();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Er du sikker på du gerne vil slette Sælgeren. Den tilknyttede bolig vil også blive slettet", "Advarsel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                db.HardDeleteSaelgerFromDB(SBoligId);
                db.HardDeleteBoligFromDB(SBoligId);
            }
            else
            {
            }
        }
    }
}
