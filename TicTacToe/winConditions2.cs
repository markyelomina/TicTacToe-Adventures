using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // for 5x5 and 7x7 grid
    internal class winConditions2
    {
        private int[,] board;
        private int gridSize;
        private int winConditionLength;
        public winConditions2(int size = 3, int winLength = 4)
        {
            gridSize = size;
            winConditionLength = winLength;
            board = new int[gridSize, gridSize];
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
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize - winConditionLength + 1; j++)
                    {
                        // Check row
                        if (board[i, j] != 0 && CheckWinningSequence(board, i, j, 0, 1))
                            return board[i, j];

                        // Check column
                        if (board[j, i] != 0 && CheckWinningSequence(board, j, i, 1, 0))
                            return board[j, i];
                    }
                }

                // diagonals
                for (int i = 0; i < gridSize - winConditionLength + 1; i++)
                {
                    for (int j = 0; j < gridSize - winConditionLength + 1; j++)
                    {
                        // Check down-right diagonal
                        if (board[i, j] != 0 && CheckWinningSequence(board, i, j, 1, 1))
                            return board[i, j];

                        // Check down-left diagonal
                        if (board[i, j + winConditionLength - 1] != 0 && CheckWinningSequence(board, i, j + winConditionLength - 1, 1, -1))
                            return board[i, j + winConditionLength - 1];
                    }
                }

                // check for square wins
                for (int i = 0; i <= gridSize - 2; i++)
                {
                    for (int j = 0; j <= gridSize - 2; j++)
                    {
                        if (board[i, j] != 0 && CheckSquareWin(board, i, j))
                        {
                            return board[i, j];
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking winner: {ex.Message}");
                return 0;
            }

        }

        // check board full
        public bool BoardFull(int[,] board)
        {
            try
            {
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if board is full: {ex.Message}");
                return false;
            }

        }
        public void ResetBoard()
        {
            try
            {
                board = new int[gridSize, gridSize];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting board: {ex.Message}");
            }

        }

        private bool CheckWinningSequence(int[,] board, int startRow, int startCol, int rowDir, int colDir)
        {
            try
            {
                int player = board[startRow, startCol];
                for (int i = 1; i < winConditionLength; i++)
                {
                    int row = startRow + i * rowDir;
                    int col = startCol + i * colDir;
                    if (row < 0 || col < 0 || row >= gridSize || col >= gridSize || board[row, col] != player)
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking winning sequence: {ex.Message}");
                return false;
            }

        }

        private bool CheckSquareWin(int[,] board, int startRow, int startCol)
        {
            try
            {
                if (startRow + 1 >= gridSize || startCol + 1 >= gridSize)
                    return false;

                int player = board[startRow, startCol];

                if (player != 0 &&
                    board[startRow, startCol] == player &&
                    board[startRow, startCol + 1] == player &&
                    board[startRow + 1, startCol] == player &&
                    board[startRow + 1, startCol + 1] == player)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking square: {ex.Message}");
                return false;
            }
        }
    }
}
