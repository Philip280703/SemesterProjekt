﻿using SemesterProjekt.DataAccess;
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
    public partial class Form2 : Form
    {
        DbHandler db;
        public Form2()
        {
            InitializeComponent();
            db = new DbHandler();
            dataGridView1.DataSource = db.GetAllBolig();
        }
    }
}
