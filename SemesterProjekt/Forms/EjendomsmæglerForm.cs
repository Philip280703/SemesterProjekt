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

        //Variabler der kan/skal gemmes
        int row;
        int MæglerId;
        string MFname;
        string MLname;
        bool MAktiv;
        string MEmail;
        int MTlfNr;
        int Afdeling; 
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

            List<Bolig> Boliger = db.GetAllBolig();
            Dgv_Boliger.DataSource = Boliger.Where(b => b.MaeglerId == MæglerId).ToList();
        }
    }
}
