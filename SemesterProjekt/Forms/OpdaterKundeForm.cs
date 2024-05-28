using SemesterProjekt.DataAccess;
using SemesterProjekt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemesterProjekt.Forms
{
    public partial class OpdaterKundeform : Form
    {
        int tlfnr;
        int kId;

        public OpdaterKundeform(string KFname, string KLname, string KEmail, int KTlfNr, int KId)
        {
            InitializeComponent();
            txt_kundefornavn.Text = KFname;
            txt_kundeefternavn.Text = KLname;
            txt_Kundeemail.Text = KEmail;
            Txt_kundeTlfNr.Text = "" + KTlfNr; 
            this.kId = KId;
            
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            DbHandler db = new DbHandler();
            MyValidator validator = new MyValidator();
            // validere input ud fra myvalidator
            if (validator.ValidatePhonenumber(int.Parse(Txt_kundeTlfNr.Text)))
            {
                // Hvis det nye telefonnummer ikke er lig det tidligere så opdateres telefonnummeret
                if (int.Parse(Txt_kundeTlfNr.Text) != tlfnr)
                {
                    db.UpdateSaelger(new Models.Saelger { STlfNr = tlfnr }, int.Parse(Txt_kundeTlfNr.Text));
                    MessageBox.Show("Tlf Nr er opdateret", "Success", MessageBoxButtons.OK);
                }
                // hvis det er lig med så rettes tlfnr ikke og en messagebox popper op
                else
                {
                    MessageBox.Show("Tlf Nr er det samme som originalt", "Error", MessageBoxButtons.OK);
                }
            }
            // Hvis input er forkert aka string ikke kan konveteres til en int, så vises denne besked
            else
            {
                MessageBox.Show("Invalid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_NytTlfNr.Text = "";
            }

        }

        private void btn_tilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
