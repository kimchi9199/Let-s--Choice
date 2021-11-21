using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Group_10
{
    public partial class ScreenStart : Form
    {
         
        public ScreenStart()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart1_Click(object sender, EventArgs e)
        {
            
            Start start = new Start();
            start.Show();
            this.Hide();
        }

       
    }
}
