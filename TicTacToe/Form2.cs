using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // back command
        private void backImage_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        // navigates to gameplay (only easy for now)
        private void easyImage_Click(object sender, EventArgs e)
        {
            easyForm f3 = new easyForm();
            f3.Show();
            this.Hide();
        }

        private void intermediateImage_Click(object sender, EventArgs e)
        {
            intermediateForm f4 = new intermediateForm();
            f4.Show();
            this.Hide();
        }

        private void hardImage_Click(object sender, EventArgs e)
        {
            hardForm f5 = new hardForm();
            f5.Show();
            this.Hide();
        }

        // exit program - when exit is clicked
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
