﻿using SemesterProjekt.DataAccess;
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
    public partial class InfoBolig : Form
    {
        DbHandler db;
        AdvanceInfoBolig aib;
        Homepage hp;
        InfoBolig ib;

        public InfoBolig()
        {
            InitializeComponent();
            db = new DbHandler();
            dataGridView1.DataSource = db.GetAllBolig();

            // Formaterer de columns med de givende titler med formatet "N0"
            // som betyder Tusinde seperator uden tal til højre for 0
            this.dataGridView1.Columns["UdbudsPris"].DefaultCellStyle.Format = "N0";
            this.dataGridView1.Columns["SalgsPris"].DefaultCellStyle.Format = "N0";
            this.dataGridView1.Columns["KvmPris"].DefaultCellStyle.Format = "N0";
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Henter info omkring ejendomsmægler som er koblet til bolig
            DbHandler db = new DbHandler();
            int row = e.RowIndex;
            DataGridViewRow data = dataGridView1.Rows[row];
            int maeglerId = (int)data.Cells["MaeglerId"].Value;
            string Adressse = (string)data.Cells["Adresse"].Value;
            EjendomsMaegler em = db.GetSingleEjendomsMaegler(maeglerId);
            textBox2.Text = em.MFname + " " + em.MLname;
            textBox3.Text = "" + em.MTlfNr;
            textBox4.Text = em.MEmail;

            // Henter info omkring Sælger som er tilkoblet Bolig
            int BoligId = (int)data.Cells["BoligId"].Value;
            Saelger sa = db.GetSingleSaelgerBasedOfBoligId(BoligId);
            textBox7.Text = sa.SFname + " " + sa.SLname;
            textBox6.Text = "" + sa.STlfNr;
            textBox5.Text = sa.SEmail;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdvanceInfoBolig aib = new AdvanceInfoBolig();
            aib.Show();
        }

       
    }
}
