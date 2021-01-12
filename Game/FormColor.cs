using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using B19_Ex05_GameLogic;

namespace B19_Ex05_Game
{
    internal class FormColor : Form
    {
        private const int k_NumberOfRows = 2;
        private const int k_NumberOfColumns = 4;
        private static int s_CurrentLeft = 10;
        private static int s_CurrentTop = 10;
        internal static Color[] s_Pressed;
        private Button[,] m_ColorsButtons;
        private Color[,] m_Colors;
        private Button m_Sender;
        private int m_SenderColumn= 0;

        public FormColor()
        {
            this.Size = new Size((FormGame.k_BigSquareEdge * k_NumberOfColumns) + 50,
                (FormGame.k_BigSquareEdge * k_NumberOfRows) + 60);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(270, 220);
            this.Text = "Pick A Color:";
            m_ColorsButtons = new Button[k_NumberOfRows, k_NumberOfColumns];
            m_Colors = new[,] { { Color.Purple, Color.Red, Color.LawnGreen, Color.Cyan },
                                { Color.DarkBlue, Color.Yellow, Color.Maroon, Color.White } };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initControls();
        }

        private void initControls()
        {
            for (int i = 0; i < k_NumberOfRows; i++)
            {
                for (int j = 0; j < k_NumberOfColumns; j++)
                {
                    Button colorButton = new Button();

                    colorButton.Width = FormGame.k_BigSquareEdge;
                    colorButton.Height = FormGame.k_BigSquareEdge;
                    colorButton.Location = new Point(s_CurrentLeft, s_CurrentTop);
                    colorButton.BackColor = m_Colors[i, j];
                    for (int k = 0; k < GameUtils.k_LengthPins; k++)
                    {
                        if ((colorButton.BackColor) == s_Pressed[k])
                        {
                            colorButton.Enabled = false;
                        }
                    }
                    
                    m_ColorsButtons[i, j] = colorButton;
                    s_CurrentLeft += (5 + FormGame.k_BigSquareEdge);
                    this.Controls.AddRange(new Control[] { colorButton });
                    m_ColorsButtons[i, j].Click += new EventHandler(m_ColorsButtons_Click);
                }

                s_CurrentLeft = 10;
                s_CurrentTop += FormGame.k_BigSquareEdge + 5;
            }

            s_CurrentLeft = 10;
            s_CurrentTop = 10;
        }

        private void m_ColorsButtons_Click(object sender, EventArgs e)
        {
            s_Pressed[m_SenderColumn] = (((Button)sender).BackColor);
            m_Sender.BackColor = ((Button)sender).BackColor;
            this.Close();
        }

        public Button Sender
        {
            get
            {
                return m_Sender;
            }
            set
            {
                m_Sender = value;
            }
        }

        public int SenderColumn
        {
            get
            {
                return m_SenderColumn;
            }
            set
            {
                m_SenderColumn = value;
            }
        }
    }
}
