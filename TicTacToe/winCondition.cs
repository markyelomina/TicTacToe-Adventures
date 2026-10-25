using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class winCondition
    {
        private int[,] board;

        public winCondition()
        {
            board = new int[3, 3];
        }
        public bool UpdateBoard(int row, int col, int player)
        {
            if (board[row, col] != 0)
            {
                return false;
            }
            board[row, col] = player;
            return true;
        }
        public int checkWinner(int[,] board)
        {
            try
            {
                // rows
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                        return board[i, 0];
                }
                // columns
                for (int i = 0; i < 3; i++)
                {
                    if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                        return board[0, i];
                }
                // diagonals
                if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                    return board[0, 0];
                else if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                    return board[0, 2];

                return 0;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error checking the winner: {ex.Message}");
                return 0;
            }

        }

        // check board full
        public bool BoardFull(int[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void ResetBoard()
        {
            try
            {
                board = new int[3, 3];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting the board: {ex.Message}");
            }

        }

    }
}
