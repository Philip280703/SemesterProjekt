using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SemesterProjekt.Models;
using SemesterProjekt.DataAccess;
using SemesterProjekt.Forms;
using SemesterProjekt;

namespace SemesterProjekt.Forms
{
    public partial class NewBoligForm : Form
    {
        DbHandler dbHandler;
        public NewBoligForm(List<int> MIdList)
        {
            InitializeComponent();
            comboBox3.DataSource = MIdList;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyValidator myValidator = new MyValidator();
            DbHandler db = new DbHandler();
            string Adresse;
            if (myValidator.ValidateAdDress(AdresseTextbox.Text))
            {
                Adresse = AdresseTextbox.Text;
            }
            else
            {
                throw new Exception("Non valid Adresse");
            }

            int postNr;
            if (myValidator.ValidateZipcode(int.Parse(comboBox1.Text)))
            {
                postNr = int.Parse(comboBox1.Text);
            }
            else
            {
                throw new Exception("Postnummer not validated propperly");
            }

            int udbudspris;
            if (myValidator.ValidatePriceOfHouse(int.Parse(UdbudsprisTextbox.Text)))
            {
                udbudspris = int.Parse(UdbudsprisTextbox.Text);
            }
            else
            {
                throw new Exception("UdbudsPris is false");
            }

            int kvadratmeter;
            if (myValidator.ValidateSquareMeter(int.Parse(KvadratmeterTextbox.Text)))
            {
                kvadratmeter = int.Parse(KvadratmeterTextbox.Text);
            }
            else
            {
                throw new Exception("Kvadratmeter is false");
            }

            string boligtype;
            if (myValidator.ValidateHouseType(comboBox2.Text))
            {
                boligtype = comboBox2.Text;
            }
            else
            {
                throw new Exception("Housetype not valid");
            }

            int maeglerid = int.Parse(comboBox3.Text);
           
           

            string fornavn;
            if (myValidator.ValidateFirstname(textBox1.Text))
            {   
                fornavn = textBox1.Text;
            }
            else
            {
                throw new Exception("fornavn not valid");
            }

            string efternavn;
            if (myValidator.ValidateLastname(textBox2.Text))
            {
                efternavn = textBox2.Text;
            }
            else { throw new Exception("Lastname not valid"); }

            string email;
            if (myValidator.ValidateEmail(textBox3.Text))
            { email = textBox3.Text; }
            else { throw new Exception("Email not valid"); }

            int tlfnr;
            if(myValidator.ValidatePhonenumber(int.Parse(textBox4.Text)))
            {
                tlfnr = int.Parse(textBox4.Text);
            }
            else
            {
                throw new Exception("Telefonnummer not valid");
            }

            db.CreateBolig(new Bolig { Adresse = Adresse, PostNr = postNr, UdbudsPris = udbudspris, Kvadratmeter = kvadratmeter, BoligType = boligtype, MaeglerId = maeglerid});
            
            db.CreateSaelger(new Saelger { SFname = fornavn, SLname = efternavn, SEmail = email, STlfNr = tlfnr });

            MessageBox.Show("Bolig er nu sat til salg");
            this.Hide();
        }
    }
}
