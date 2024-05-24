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
    public partial class Newkunde : Form
    {
        public Newkunde()
        {
            InitializeComponent();
        }

        private void buttonVidere_Click(object sender, EventArgs e)
        {
            DbHandler db = new DbHandler();
            MyValidator validator = new MyValidator();

            string fornavn;
            if (validator.ValidateFirstname(textBoxFornavn.Text))
            {
                fornavn = textBoxFornavn.Text;
            }
            else
            {
                throw new Exception("Firstname not validated");
            }

            string efternavn;
            if (validator.ValidateLastname(textBoxEfternavn.Text))
            {
                efternavn = textBoxEfternavn.Text;
            }
            else
            {
                throw new Exception("Lastname not validated");
            }

            string email;
            if (validator.ValidateEmail(textBoxEmail.Text))
            {
                email = textBoxEmail.Text;
            }
            else
            {
                throw new Exception("Email not validated");
            }

            //int tlf;
            //if (validator.ValidatePhonenumber(int.Parse (textBoxTlf.Text))
            //{
            //    tlf = int.Parse(textBoxTlf.Text);
            //}
            

            //DbHandler db = new DbHandler();
            //MyValidator validator = new MyValidator();

            //string fornavn;
            //if (validator.ValidateFirstname(textBoxFornavn.Text))
            //{
            //    fornavn = textBoxFornavn.Text;
            //}
            //else
            //{
            //    throw new Exception("Firstname not validated");
            //}

            //string efternavn;
            //if (validator.ValidateLastname(textBoxEfternavn.Text))
            //{
            //    efternavn = textBoxEfternavn.Text;
            //}
            //else { throw new Exception("Lastname not valid"); }

            //string email;
            //if (validator.ValidateEmail(textBoxEmail.Text))
            //{
            //    email = textBoxEmail.Text;
            //}
            //else { throw new Exception("Email not valid"); }

            //int tlf;
            //if (validator.ValidatePhonenumber(int.Parse(textBoxTlf.Text)))
            //{
            //    tlf = int.Parse(textBoxTlf.Text);
            //}
            //else
            //{
            //    throw new Exception("Phonenumber not valid");
            //}

            //int afdeling = int.Parse(comboBoxAfdeling.Text);


            //db.CreateMaegler(new EjendomsMaegler { MFname = fornavn, MLname = efternavn, MEmail = email, MTlfNr = tlf, Afdeling = afdeling, MAktiv = true });

            //MessageBox.Show("Nye ejendomsmæglerne er nu oprettet");
            //this.Hide();
        }


    }
}
