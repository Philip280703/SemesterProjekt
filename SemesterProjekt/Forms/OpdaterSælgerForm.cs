using SemesterProjekt.DataAccess;
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
    public partial class OpdaterSælgerForm : Form
    {
        int tlfnr;
        

        public OpdaterSælgerForm(int sælgerId, string SælgerNavn, int BoligId, string SælgerEmail, int SælgerTlfNr)
        {
            InitializeComponent();
            Txt_BoligId.Text = "" + BoligId;
            Txt_SælgerEmail.Text = SælgerEmail;
            Txt_SælgerNavn.Text = SælgerNavn;
            Txt_SælgerTlfNr.Text = "" + SælgerTlfNr;
            Txt_SælgerId.Text = "" + sælgerId;
        }

        //Opdater Sælgeren
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            DbHandler db = new DbHandler();
            MyValidator validator = new MyValidator();

            // validere input ud fra myvalidator
            if (validator.ValidatePhonenumber(int.Parse(Txt_SælgerTlfNr.Text)))
            {
                // Hvis det nye telefonnummer ikke er lig det tidligere så opdateres telefonnummeret
                if (int.Parse(Txt_SælgerTlfNr.Text) != tlfnr)
                {
                    db.UpdateSaelger(new Models.Saelger { STlfNr = tlfnr }, int.Parse(Txt_SælgerId.Text));
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
    }
}
