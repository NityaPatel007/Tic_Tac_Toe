                //NITYA PATEL 8868046
                //ASSIGNMENT 1 - TIC TAC TOE GAME                 
using System;
using System.Windows.Forms;

namespace NpatelAssignment1
{
    public partial class Form1 : Form
    {
        private char[,] board = new char[3, 3];
        private char currentPlayer = 'X';
        private bool gameOver = false;
        private PictureBox[,] pictureBoxes = new PictureBox[3, 3];
        private PictureBox lastClickedPictureBox = null;

        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            
            pictureBoxes[0, 0] = pictureBox1;
            pictureBoxes[0, 1] = pictureBox2;
            pictureBoxes[0, 2] = pictureBox3;
            pictureBoxes[1, 0] = pictureBox4;
            pictureBoxes[1, 1] = pictureBox5;
            pictureBoxes[1, 2] = pictureBox6;
            pictureBoxes[2, 0] = pictureBox7;
            pictureBoxes[2, 1] = pictureBox8;
            pictureBoxes[2, 2] = pictureBox9;

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Image = null;
                pictureBox.Tag = "";
            }
        }

        public void PictureBox_Click(object sender, EventArgs e)
        {
            if (gameOver) return;

            PictureBox pictureBox = (PictureBox)sender;

            int row = -1, col = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (pictureBox == pictureBoxes[i, j])
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
                if (row != -1) break;
            }

            if (row != -1 && col != -1 && board[row, col] == '\0')
            {
                board[row, col] = currentPlayer;
                pictureBox.Image = (currentPlayer == 'X') ? Properties.Resources.x_png_33 : Properties.Resources.o;
                lastClickedPictureBox = pictureBox;

                CheckForWin();
                CheckForDraw();
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }

        //win condition
        public void CheckForWin()
        {
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
                {
                    ShowWinner(currentPlayer);
                    ResetGame();
                    return;
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
                {
                    ShowWinner(currentPlayer);
                    ResetGame();
                    return;
                }
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            {
                ShowWinner(currentPlayer);
                ResetGame();
                return;
            }

            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            {
                ShowWinner(currentPlayer);
                ResetGame();
                return;
            }
        }
        //check draw
        public void CheckForDraw()
        {
            bool isDraw = true;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == '\0')
                    {
                        isDraw = false;
                        break;
                    }
                }
                if (!isDraw) break;
            }

            if (isDraw && !gameOver)
            {
                ShowDraw();
                ResetGame();
            }
        }
        //winner
        public void ShowWinner(char winner)
        {
            MessageBox.Show($"{winner} wins!");
            gameOver = true;
            ResetGame();
        }

        //draw condition
        public void ShowDraw()
        {
            MessageBox.Show("It's a draw!");
            gameOver = true;
            ResetGame();
        }

        public void ResetGame()
        {
            currentPlayer = 'O';
           
            if (lastClickedPictureBox != null)
            {
                lastClickedPictureBox.Image = null;
                lastClickedPictureBox.Tag = "";
                lastClickedPictureBox = null;
            }

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = '\0';
                }
            }

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Image = null;
                pictureBox.Tag = "";
            }

            gameOver = false;


        }
    }
}