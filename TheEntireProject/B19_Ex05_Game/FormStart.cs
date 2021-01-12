using System;
using System.Windows.Forms;
using System.Drawing;
using B19_Ex05_GameLogic;

namespace B19_Ex05_Game
{
    internal class FormStart : Form
    {
        private Button m_ButtonNumberOfChances = new Button();
        private Button m_ButtonStart = new Button();

        public FormStart()
        {
            this.ClientSize = new Size(300, 145);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initControls();
        }

        private void initControls()
        {
            m_ButtonStart.Text = "Start";
            m_ButtonStart.Location = new Point(this.ClientSize.Width - m_ButtonStart.Width - 10,
                this.ClientSize.Height - m_ButtonStart.Height - 10);

            m_ButtonNumberOfChances.Text = string.Format("Number of chances: {0}",
                Game.s_CurrentNumberOfGuesses);
            m_ButtonNumberOfChances.Width = this.ClientSize.Width - 20;
            m_ButtonNumberOfChances.Location = new Point(10, 10);

            this.Controls.AddRange(new Control[] { m_ButtonStart, m_ButtonNumberOfChances });

            m_ButtonStart.Click += new EventHandler(m_ButtonStart_Click);
            m_ButtonNumberOfChances.Click += new EventHandler(m_ButtonNumberOfChances_Click);
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GameUtils.s_NumberOfGuesses = Game.s_CurrentNumberOfGuesses;
            Form formGame = new FormGame();
            formGame.ShowDialog();
            this.Close();
        }

        private void m_ButtonNumberOfChances_Click(object sender, EventArgs e)
        {
            int minNumber = GameUtils.k_MinNumberOfGuesses;

            if (Game.s_CurrentNumberOfGuesses < GameUtils.k_MaxNumberOfGuesses)
            {
                Game.s_CurrentNumberOfGuesses++;
                m_ButtonNumberOfChances.Text = string.Format("Number of chances: {0}",
                    Game.s_CurrentNumberOfGuesses);
            }
            else
            {
                Game.s_CurrentNumberOfGuesses = minNumber;
                m_ButtonNumberOfChances.Text = string.Format("Number of chances: {0}", minNumber);
            }
        }
    }
}
