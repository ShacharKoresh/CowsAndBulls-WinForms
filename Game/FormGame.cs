using System;
using System.Windows.Forms;
using System.Drawing;
using B19_Ex05_GameLogic;
using System.Text;
using System.Collections.Generic;

namespace B19_Ex05_Game
{
    internal class FormGame : Form
    {
        internal const int k_BigSquareEdge = 42;
        private const int k_SmallSquareEdge = 14;
        private const int k_ArrowWidth = 42;
        private const int k_ArrowHeight = 21;
        private static int s_CurrentLeft = 10;
        private static int s_CurrentTop = 10;
        internal static Button[] s_ComputerGuess;
        internal static Button[,] s_UserGuess;
        internal static Button[,] s_Result;
        private static bool[] s_WasPressed = new[] { false, false, false, false };

        public FormGame()
        {
            int formHeight = ((GameUtils.s_NumberOfGuesses + 1) * k_BigSquareEdge) + 25
                + ((GameUtils.s_NumberOfGuesses) * 6) + 25;

            this.ClientSize = new Size(300, formHeight);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
            s_ComputerGuess = new Button[GameUtils.k_LengthPins];
            s_UserGuess = new Button[Game.s_CurrentNumberOfGuesses, (GameUtils.k_LengthPins + 1)];
            s_Result = new Button[Game.s_CurrentNumberOfGuesses, GameUtils.k_LengthPins];
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initControls();
        }

        private void initControls()
        {
            FormColor.s_Pressed = new Color[(GameUtils.k_LengthPins)];

            for (int i = 0; i < s_ComputerGuess.Length; i++)
            {
                createComputerGuessRow(i);
            }

            s_CurrentLeft = 10;
            s_CurrentTop = s_CurrentTop + (k_BigSquareEdge + 25);
            for (int i = 0; i < Game.s_CurrentNumberOfGuesses; i++)
            {
                for (int j = 0; j < GameUtils.k_LengthPins; j++)
                {
                    createUserGuessRow(i, j);
                    s_UserGuess[i, j].Click += new EventHandler(m_UserGuess_Click);
                }

                enableCurrentRow();
                createArrow(i);
                s_UserGuess[i, GameUtils.k_LengthPins].Click += new EventHandler(m_UserGuessArrow_Click);
                for (int j = 0; j < GameUtils.k_LengthPins; j++)
                {
                    createResultRow(i, j);
                }
                
                s_CurrentLeft = 10;
                s_CurrentTop = s_CurrentTop + (k_BigSquareEdge + 8);
            }
        }

        private void createComputerGuessRow(int i_Index)
        {
            Button currentButton = new Button();

            currentButton.BackColor = Color.Black;
            currentButton.Width = k_BigSquareEdge;
            currentButton.Height = k_BigSquareEdge;
            currentButton.Location = new Point(s_CurrentLeft, s_CurrentTop);
            s_ComputerGuess[i_Index] = currentButton;
            s_CurrentLeft += (5 + k_BigSquareEdge);
            this.Controls.AddRange(new Control[] { s_ComputerGuess[i_Index] });
        }

        private void createUserGuessRow(int i_RowIndex, int i_ColumnIndex)
        {
            Button currentButton = new Button();

            currentButton.Width = k_BigSquareEdge;
            currentButton.Height = k_BigSquareEdge;
            currentButton.Location = new Point(s_CurrentLeft, s_CurrentTop);
            currentButton.Enabled = false;
            s_UserGuess[i_RowIndex, i_ColumnIndex] = currentButton;
            s_CurrentLeft += (5 + k_BigSquareEdge);
            this.Controls.AddRange(new Control[] { s_UserGuess[i_RowIndex, i_ColumnIndex] });
        }

        private void createArrow(int i_RowIndex)
        {
            Button arrow = new Button();

            arrow.Width = k_ArrowWidth;
            arrow.Height = k_ArrowHeight;
            arrow.Text = "-->>";
            arrow.Enabled = false;
            arrow.Location = new Point(s_CurrentLeft, (s_CurrentTop + (k_BigSquareEdge / 4)));
            s_UserGuess[i_RowIndex, GameUtils.k_LengthPins] = arrow;
            s_CurrentLeft += (10 + k_BigSquareEdge);
            this.Controls.AddRange(new Control[] { arrow });
        }

        private void createResultRow(int i_RowIndex, int i_ColumnIndex)
        {
            Button currentResultButton = new Button();

            currentResultButton.Width = k_SmallSquareEdge;
            currentResultButton.Height = k_SmallSquareEdge;
            if (i_ColumnIndex == 0)
            {
                currentResultButton.Location = new Point(s_CurrentLeft, s_CurrentTop + 5);
            }
            else if (i_ColumnIndex == 1)
            {
                currentResultButton.Location = new Point(s_CurrentLeft + k_SmallSquareEdge + 5, s_CurrentTop + 5);
            }
            else if (i_ColumnIndex == 2)
            {
                currentResultButton.Location = new Point(s_CurrentLeft, s_CurrentTop + k_SmallSquareEdge + 8);
            }
            else if (i_ColumnIndex == 3)
            {
                currentResultButton.Location = new Point(s_CurrentLeft + k_SmallSquareEdge + 5,
                    s_CurrentTop + k_SmallSquareEdge + 8);
            }

            currentResultButton.Enabled = false;
            s_Result[i_RowIndex, i_ColumnIndex] = currentResultButton;
            this.Controls.AddRange(new Control[] { s_Result[i_RowIndex, i_ColumnIndex] });
        }

        private void m_UserGuess_Click(object sender, EventArgs e)
        {
            bool enableArrow = false;
            FormColor formColor = new FormColor();
            formColor.Sender = (Button)sender;
            formColor.SenderColumn = getSenderColumn((Button)sender);
            formColor.ShowDialog();

            if (((Button)sender).Left == s_UserGuess[0,0].Left)
            {
                s_WasPressed[0] = true;
            }
            else if (((Button)sender).Left == s_UserGuess[0, 1].Left)
            {
                s_WasPressed[1] = true;
            }
            else if (((Button)sender).Left == s_UserGuess[0, 2].Left)
            {
                s_WasPressed[2] = true;
            }
            else if (((Button)sender).Left == s_UserGuess[0, 3].Left)
            {
                s_WasPressed[3] = true;
            }

            enableArrow = s_WasPressed[0] && s_WasPressed[1] && s_WasPressed[2] && s_WasPressed[3];
            if (enableArrow)
            {
                s_UserGuess[Game.s_CurrentGuess - 1, GameUtils.k_LengthPins].Enabled = true;
            }
        }

        private void m_UserGuessArrow_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String result;

            FormColor.s_Pressed = new Color[(GameUtils.k_LengthPins)];
            unenableCurrentRow();
            ((Button)sender).Enabled = false;
            for (int j = 0; j < GameUtils.k_LengthPins; j++)
            {
                stringBuilder.Append
                    (Game.s_ColorToLetter[(s_UserGuess[Game.s_CurrentGuess - 1, j].BackColor)]);
            }

            result = GameUtils.GetResultString(stringBuilder.ToString());
            Game.CreateResultColorArray(result);
            for (int i = 0; i < s_WasPressed.Length; i++)
            {
                s_WasPressed[i] = false;
            }

            if (result == "VVVV" || Game.s_CurrentGuess == GameUtils.s_NumberOfGuesses)
            {
                Game.ColorComputerGuess();
                unenableAllRows();
            }
            else
            {
                Game.s_CurrentGuess++;
                enableCurrentRow();
            }
        }

        private void enableCurrentRow()
        {
            if (Game.s_CurrentGuess <= Game.s_CurrentNumberOfGuesses)
            {
                for (int j = 0; j < GameUtils.k_LengthPins; j++)
                {
                    s_UserGuess[Game.s_CurrentGuess - 1, j].Enabled = true;
                }
            }
        }

        private void unenableCurrentRow()
        {
            if (Game.s_CurrentGuess <= Game.s_CurrentNumberOfGuesses)
            {
                for (int j = 0; j < GameUtils.k_LengthPins; j++)
                {
                    s_UserGuess[Game.s_CurrentGuess - 1, j].Enabled = false;
                }
            }
        }

        private void unenableAllRows()
        {
            for (int i = 0; i < GameUtils.s_NumberOfGuesses; i++)
            {
                for (int j = 0; j < GameUtils.k_LengthPins; j++)
                {
                    s_UserGuess[i, j].Enabled = false;
                }
            }
        }

        private static int getSenderColumn(Button i_CurrentButton)
        {
            int senderColumn = 0;

            if (i_CurrentButton.Left == s_UserGuess[0, 0].Left)
            {
                senderColumn = 0;
            }
            else if (i_CurrentButton.Left == s_UserGuess[0, 1].Left)
            {
                senderColumn = 1;
            }
            else if (i_CurrentButton.Left == s_UserGuess[0, 2].Left)
            {
                senderColumn = 2;
            }
            else if (i_CurrentButton.Left == s_UserGuess[0, 3].Left)
            {
                senderColumn = 3;
            }

            return senderColumn;
        }
    }
}
