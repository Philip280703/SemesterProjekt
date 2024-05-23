using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SemesterProjekt.DataAccess;
using SemesterProjekt.Models;

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
        int STlfNr;
        public KundeForm()
        {
            db = new DbHandler();
            InitializeComponent();
            DGVKunde.DataSource = db.GetAllKunder();
        }
    }
}
