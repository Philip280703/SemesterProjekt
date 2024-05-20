using SemesterProjekt.DataAccess;
using SemesterProjekt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemesterProjekt.Forms
{
    public partial class Form2 : Form
    {
        DbHandler db;
        public Form2()
        {
            InitializeComponent();
            db = new DbHandler();
            dataGridView1.DataSource = db.GetAllBolig();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Bolig> filter = db.Searchbar(textBox1.Text);
            dataGridView1.DataSource = filter;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string combobox = comboBox1.Text;
            if (combobox == "BoligType")
            {
                dataGridView1.DataSource = db.GetAllBolig();
            }
            else
            {
                List<Bolig> filter = db.GetAllBolig();
                dataGridView1.DataSource = filter.Where(b => b.BoligType == combobox).ToList();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string combobox = comboBox2.Text;
            if (combobox == "PostNr")
            {
                dataGridView1.DataSource = db.GetAllBolig();
            }
            else
            {
                int num1 = int.Parse(combobox.Split("-")[0]);
                int num2 = int.Parse(combobox.Split("-")[1]);
                List<Bolig> filter = db.GetAllBolig();
                dataGridView1.DataSource = filter.Where(b => b.PostNr >= num1 && b.PostNr <= num2).ToList();
            }


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string combobox = comboBox3.Text;
            if (combobox == "Pris")
            {
                dataGridView1.DataSource = db.GetAllBolig();
            }
            else
            {
                int num1 = int.Parse(combobox.Split("-")[0]);
                int num2 = int.Parse(combobox.Split("-")[1]);
                List<Bolig> filter = db.GetAllBolig();
                dataGridView1.DataSource = filter.Where(b => b.UdbudsPris >= num1 && b.UdbudsPris <= num2).ToList();
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DbHandler db = new DbHandler();
            int row = e.RowIndex;
            DataGridViewRow data = dataGridView1.Rows[row];            
            int maegleId = (int)data.Cells["MaeglerId"].Value;
            string Adressse = (string)data.Cells["Adresse"].Value;
            EjendomsMaegler em = db.GetSingleEjendomsMaegler(maegleId);
            textBox2.Text = em.MFname + " " + em.MLname;
            textBox3.Text = "" + em.MTlfNr;
            textBox4.Text = em.MEmail;
        }
    }
}
