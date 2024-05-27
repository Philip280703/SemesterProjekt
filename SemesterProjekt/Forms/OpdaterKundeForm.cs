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
    public partial class OpdaterKundeform : Form
    {
        
        public OpdaterKundeform(string KFname, string KLname, string KEmail, int KTlfNr)
        {
            InitializeComponent();
            txt_kundefornavn.Text = KFname;
            txt_kundeefternavn.Text = KLname;
            txt_Kundeemail.Text = KEmail;
            Txt_kundeTlfNr.Text = "" + KTlfNr; 
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {


        }

        private void btn_tilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
