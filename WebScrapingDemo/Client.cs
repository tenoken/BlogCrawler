using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebScrapingDemo;

namespace WebScrapingDemo
{
    public partial class Client : Form
    {

        public Client(MainForm mainForm)
        {           
            InitializeComponent();

            this.IsMdiContainer = true;
            this.BackColor = Color.LightPink;

            MainForm form1 = mainForm;
            form1.MdiParent = this;

            form1.Show();
        }
    }
}
