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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            {
                titleImage.BackColor = Color.Transparent;
            }
        }

        // navigates to difficulty
        private void playImage_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        // exits program
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Welcome to Tic Tac Toe Adventures!\n\n" +
                "Game Mechanics:\n" +
                "1. The game is played depending on selected difficulty.\n" +
                "2. Players take turns marking squares on the grid: \n" +
                "   - Player 1: O\n" +
                "   - Player 2: X\n" +
                "3. The objective is to align 3 marks in a row in Easy and 4 marks in a row in Intermediate and Hard .\n" +
                "4. If all squares are filled and neither player achieves 3-4 in a row, the game ends in a draw.\n\n" +
                "Good luck and enjoy the game!",
                "Game Mechanics",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
