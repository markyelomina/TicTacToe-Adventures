using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe 
{
    public partial class easyForm : Form
    {
        private TimerManager timerManager;
        private ScoreManager scoreManager;

        static private string turnNow = "ekis";

        private winCondition WinCondition = new winCondition();
        private int[,] board = new int[3, 3];


        public easyForm()
        {
            try
            {
                InitializeComponent();
                {

                    scoreManager = new ScoreManager();
                    timerManager = new TimerManager(10, () =>
                    {
                        MessageBox.Show("Time's up! Switching turn.");
                        switchTurn();
                    }, timerLabel);

                    slotBoxImage1.Click += HandleSlotBoxClick;
                    slotBoxImage2.Click += HandleSlotBoxClick;
                    slotBoxImage3.Click += HandleSlotBoxClick;
                    slotBoxImage4.Click += HandleSlotBoxClick;
                    slotBoxImage5.Click += HandleSlotBoxClick;
                    slotBoxImage6.Click += HandleSlotBoxClick;
                    slotBoxImage7.Click += HandleSlotBoxClick;
                    slotBoxImage8.Click += HandleSlotBoxClick;
                    slotBoxImage9.Click += HandleSlotBoxClick;
                    switchTurn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}");
            }

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void backImage_Click(object sender, EventArgs e)
        {
            timerManager.StopTimer();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        // gets image
        private Bitmap getImage()
        {
            string projectDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\"));
            string filePath = Path.Combine(projectDirectory, "Resources", $"{turnNow}.png");
            Bitmap bm = new Bitmap(filePath);

            return bm;
        }

        // switches turn
        private void switchTurn()
        {
            if (turnNow == "circle")
            {
                turnNow = "ekis";
            }

            else
            {
                turnNow = "circle";
            }

            // shows current player's turn
            string projectDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\"));
            string filePath = Path.Combine(projectDirectory, "Resources", $"{turnNow}.png");
            Bitmap bm = new Bitmap(filePath);
            turnImage.Image = bm;

            timerManager.StartTimer();
        }
        private void UpdateScoreLabels()
        {
            int circleScore = scoreManager.GetScore("circle");
            int ekisScore = scoreManager.GetScore("ekis");

            labelCircleScore.Text = $"O: {circleScore}";
            labelEkisScore.Text = $"X: {ekisScore}";
        }

        // slotboximage #1-9, marks on click/changes on click
        private void slotBoxImage1_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage1.Image = turn;
        }

        private void slotBoxImage2_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage2.Image = turn;
        }

        private void slotBoxImage3_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage3.Image = turn;
        }

        private void slotBoxImage4_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage4.Image = turn;
        }

        private void slotBoxImage5_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage5.Image = turn;
        }

        private void slotBoxImage6_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage6.Image = turn;
        }

        private void slotBoxImage7_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage7.Image = turn;
        }

        private void slotBoxImage8_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage8.Image = turn;
        }

        private void slotBoxImage9_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage9.Image = turn;
        }

        private void HandleSlotBoxClick(object sender, EventArgs e)
        {
            try
            {
                PictureBox clickedSlot = sender as PictureBox;
                if (clickedSlot != null)
                {
                    int row = -1;
                    int col = -1;

                    if (clickedSlot == slotBoxImage1) { row = 0; col = 0; }
                    else if (clickedSlot == slotBoxImage2) { row = 0; col = 1; }
                    else if (clickedSlot == slotBoxImage3) { row = 0; col = 2; }
                    else if (clickedSlot == slotBoxImage4) { row = 1; col = 0; }
                    else if (clickedSlot == slotBoxImage5) { row = 1; col = 1; }
                    else if (clickedSlot == slotBoxImage6) { row = 1; col = 2; }
                    else if (clickedSlot == slotBoxImage7) { row = 2; col = 0; }
                    else if (clickedSlot == slotBoxImage8) { row = 2; col = 1; }
                    else if (clickedSlot == slotBoxImage9) { row = 2; col = 2; }

                    if (board[row, col] != 0)
                    {
                        MessageBox.Show("    This slot is already filled!");
                        return;
                    }

                    int player = turnNow == "circle" ? 1 : 2;
                    board[row, col] = player;

                    Bitmap turn = getImage();
                    clickedSlot.Image = turn;
                    timerManager.StopTimer();

                    int winner = WinCondition.checkWinner(board);
                    if (winner != 0)
                    {
                        string winnerPlayer = winner == 1 ? "Circle" : "X";
                        MessageBox.Show($"        {winnerPlayer} wins!");

                        scoreManager.IncrementScore(turnNow); // Update score
                        UpdateScoreLabels();

                        ResetBoard();
                    }
                    else if (WinCondition.BoardFull(board))
                    {
                        MessageBox.Show("     It's a draw");
                        ResetBoard();
                    }
                    else
                    {
                        switchTurn();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error handling slot click: {ex.Message}");
            }
        }

        private void ResetBoard()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = 0;
                    }
                }
                slotBoxImage1.Image = null;
                slotBoxImage2.Image = null;
                slotBoxImage3.Image = null;
                slotBoxImage4.Image = null;
                slotBoxImage5.Image = null;
                slotBoxImage6.Image = null;
                slotBoxImage7.Image = null;
                slotBoxImage8.Image = null;
                slotBoxImage9.Image = null;


                turnNow = "circle";
                string projectDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\"));
                string filePath = Path.Combine(projectDirectory, "Resources", $"{turnNow}.png");
                Bitmap bm = new Bitmap(filePath);

                turnImage.Image = bm;
                timerManager.StartTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting the board: {ex.Message}");
            }

        }
    }
}
