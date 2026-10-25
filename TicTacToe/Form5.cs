using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class hardForm : Form
    {
        private TimerManager timerManager;
        private ScoreManager scoreManager;

        static private string turnNow = "ekis";
        private int[,] board = new int[7, 7];
        private winConditions2 WinCondition;

        public hardForm()
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

                    WinCondition = new winConditions2(size: 7, winLength: 4);
                    switchTurn();

                    PictureBox[] slotImages = new PictureBox[]
                    {
                    slotBoxImage1, slotBoxImage2, slotBoxImage3, slotBoxImage4, slotBoxImage5,
                    slotBoxImage6, slotBoxImage7, slotBoxImage8, slotBoxImage9, slotBoxImage10,
                    slotBoxImage11, slotBoxImage12, slotBoxImage13, slotBoxImage14, slotBoxImage15,
                    slotBoxImage16, slotBoxImage17, slotBoxImage18, slotBoxImage19, slotBoxImage20,
                    slotBoxImage21, slotBoxImage22, slotBoxImage23, slotBoxImage24, slotBoxImage25,
                    slotBoxImage26, slotBoxImage27, slotBoxImage28, slotBoxImage29, slotBoxImage30,
                    slotBoxImage31, slotBoxImage32, slotBoxImage33, slotBoxImage34, slotBoxImage35,
                    slotBoxImage36, slotBoxImage37, slotBoxImage38, slotBoxImage39, slotBoxImage40,
                    slotBoxImage41, slotBoxImage42, slotBoxImage43, slotBoxImage44, slotBoxImage45,
                    slotBoxImage46, slotBoxImage47, slotBoxImage48, slotBoxImage49
                    };


                    foreach (var slot in slotImages)
                    {
                        slot.Click += HandleSlotBoxClick;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}");
            }

        }

        private void hardForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void HandleSlotBoxClick(object sender, EventArgs e)
        {
            try
            {
                PictureBox clickedSlot = sender as PictureBox;
                if (clickedSlot != null)
                {
                    int index = Array.IndexOf(new PictureBox[]
                    {
                    slotBoxImage1, slotBoxImage2, slotBoxImage3, slotBoxImage4, slotBoxImage5,
                    slotBoxImage6, slotBoxImage7, slotBoxImage8, slotBoxImage9, slotBoxImage10,
                    slotBoxImage11, slotBoxImage12, slotBoxImage13, slotBoxImage14, slotBoxImage15,
                    slotBoxImage16, slotBoxImage17, slotBoxImage18, slotBoxImage19, slotBoxImage20,
                    slotBoxImage21, slotBoxImage22, slotBoxImage23, slotBoxImage24, slotBoxImage25,
                    slotBoxImage26, slotBoxImage27, slotBoxImage28, slotBoxImage29, slotBoxImage30,
                    slotBoxImage31, slotBoxImage32, slotBoxImage33, slotBoxImage34, slotBoxImage35,
                    slotBoxImage36, slotBoxImage37, slotBoxImage38, slotBoxImage39, slotBoxImage40,
                    slotBoxImage41, slotBoxImage42, slotBoxImage43, slotBoxImage44, slotBoxImage45,
                    slotBoxImage46, slotBoxImage47, slotBoxImage48, slotBoxImage49
                    }, clickedSlot);

                    int row = index / 7;
                    int col = index % 7;

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
                Array.Clear(board, 0, board.Length);

                PictureBox[] slotImages = new PictureBox[]
                {
                slotBoxImage1, slotBoxImage2, slotBoxImage3, slotBoxImage4, slotBoxImage5,
                slotBoxImage6, slotBoxImage7, slotBoxImage8, slotBoxImage9, slotBoxImage10,
                slotBoxImage11, slotBoxImage12, slotBoxImage13, slotBoxImage14, slotBoxImage15,
                slotBoxImage16, slotBoxImage17, slotBoxImage18, slotBoxImage19, slotBoxImage20,
                slotBoxImage21, slotBoxImage22, slotBoxImage23, slotBoxImage24, slotBoxImage25,
                slotBoxImage26, slotBoxImage27, slotBoxImage28, slotBoxImage29, slotBoxImage30,
                slotBoxImage31, slotBoxImage32, slotBoxImage33, slotBoxImage34, slotBoxImage35,
                slotBoxImage36, slotBoxImage37, slotBoxImage38, slotBoxImage39, slotBoxImage40,
                slotBoxImage41, slotBoxImage42, slotBoxImage43, slotBoxImage44, slotBoxImage45,
                slotBoxImage46, slotBoxImage47, slotBoxImage48, slotBoxImage49
                };

                foreach (var slotImage in slotImages)
                {
                    slotImage.Image = null;
                }

                turnNow = "circle";
                string projectDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\"));
                string filePath = Path.Combine(projectDirectory, "Resources", $"{turnNow}.png");
                Bitmap bm = new Bitmap(filePath);

                turnImage.Image = bm;
                timerManager.StartTimer(); //restart timer
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting board: {ex.Message}");
            }

        }


        // slot boxes
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

        private void slotBoxImage10_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage10.Image = turn;
        }

        private void slotBoxImage11_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage11.Image = turn;
        }

        private void slotBoxImage12_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage12.Image = turn;
        }

        private void slotBoxImage13_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage13.Image = turn;
        }

        private void slotBoxImage14_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage14.Image = turn;
        }

        private void slotBoxImage15_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage15.Image = turn;
        }

        private void slotBoxImage16_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage16.Image = turn;
        }

        private void slotBoxImage17_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage17.Image = turn;
        }

        private void slotBoxImage18_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage18.Image = turn;
        }

        private void slotBoxImage19_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage19.Image = turn;
        }

        private void slotBoxImage20_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage20.Image = turn;
        }

        private void slotBoxImage21_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage21.Image = turn;
        }

        private void slotBoxImage22_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage22.Image = turn;
        }

        private void slotBoxImage23_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage23.Image = turn;
        }

        private void slotBoxImage24_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage24.Image = turn;
        }

        private void slotBoxImage25_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage25.Image = turn;
        }

        private void slotBoxImage26_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage26.Image = turn;
        }

        private void slotBoxImage27_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage27.Image = turn;
        }

        private void slotBoxImage28_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage28.Image = turn;
        }

        private void slotBoxImage29_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage29.Image = turn;
        }

        private void slotBoxImage30_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage30.Image = turn;
        }

        private void slotBoxImage31_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage31.Image = turn;
        }

        private void slotBoxImage32_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage32.Image = turn;
        }

        private void slotBoxImage33_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage33.Image = turn;
        }

        private void slotBoxImage34_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage34.Image = turn;
        }

        private void slotBoxImage35_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage35.Image = turn;
        }

        private void slotBoxImage36_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage36.Image = turn;
        }

        private void slotBoxImage37_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage37.Image = turn;
        }

        private void slotBoxImage38_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage38.Image = turn;
        }

        private void slotBoxImage39_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage39.Image = turn;
        }

        private void slotBoxImage40_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage40.Image = turn;
        }

        private void slotBoxImage41_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage41.Image = turn;
        }

        private void slotBoxImage42_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage42.Image = turn;
        }

        private void slotBoxImage43_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage43.Image = turn;
        }

        private void slotBoxImage44_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage44.Image = turn;
        }

        private void slotBoxImage45_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage45.Image = turn;
        }

        private void slotBoxImage46_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage46.Image = turn;
        }

        private void slotBoxImage47_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage47.Image = turn;
        }

        private void slotBoxImage48_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage48.Image = turn;
        }

        private void slotBoxImage49_Click(object sender, EventArgs e)
        {
            Bitmap turn = getImage();

            slotBoxImage49.Image = turn;
        }
    }
}
