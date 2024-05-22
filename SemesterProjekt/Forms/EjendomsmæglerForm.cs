using SemesterProjekt.DataAccess;
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

namespace SemesterProjekt.Forms
{
    public partial class EjendomsmæglerForm : Form
    {
        DbHandler db;

        //Variabler der kan/skal gemmes (Mægler)
        int row;
        int MæglerId;
        string MFname;
        string MLname;
        bool MAktiv;
        string MEmail;
        int MTlfNr;
        int Afdeling;

        //Variabler der skal gemmes (Sælger)
        int SId;
        string SFname;
        string SLname;
        int SBoligId;
        string SEmail;
        int STlfNr;



        public EjendomsmæglerForm()
        {
            InitializeComponent();
            db = new DbHandler();
            Dgv_Mægler.DataSource = db.GetAllEjendomsMaegler();
            Dgv_Mægler.ClearSelection();
        }

        private void Dgv_Mægler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            db = new DbHandler();
            row = e.RowIndex;
            try
            {
                DataGridViewRow data = Dgv_Mægler.Rows[row];
                MæglerId = (int)data.Cells["MId"].Value;
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
            Dgv_Aktive_Boliger.DataSource = Boliger.Where(b => b.MaeglerId == MæglerId && b.SalgsPris < 1).ToList();
            Dgv_Aktive_Boliger.ClearSelection();

            //Viser alle inaktive boliger i inaktiv DGV
            Dgv_Inaktive_Boliger.DataSource = Boliger.Where(b => b.MaeglerId == MæglerId && b.SalgsPris > 1).ToList();
            Dgv_Inaktive_Boliger.ClearSelection();
        }

        private void Dgv_Aktive_Boliger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            db = new DbHandler(); 
            row = e.RowIndex;
            try
            {
                DataGridViewRow Data = Dgv_Aktive_Boliger.Rows[row];
                SId = (int)Data.Cells["SId"].Value;
                SFname = (string)Data.Cells["SFname"].Value;
                SLname = (string)Data.Cells["SLname"].Value;
                SBoligId = (int)Data.Cells["SBoligId"].Value;
                SEmail = (string)Data.Cells["SEmail"].Value;
                STlfNr = (int)Data.Cells["STlfNr"].Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            TxtBox_Sælger_Navn.Text = SFname + " " + SLname;
            TxtBox_Sælger_Email.Text = SEmail;
            TxtBox_Sælger_TlfNr.Text = "" + STlfNr; 
        }
    }
}
