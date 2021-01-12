using System;
using B19_Ex05_GameLogic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace B19_Ex05_Game
{
    internal class Game
    {
        internal static int s_CurrentGuess = 1;
        internal static int s_CurrentNumberOfGuesses = GameUtils.k_MinNumberOfGuesses;
        internal static Dictionary<char, Color> s_LetterToColor = new Dictionary<char, Color>()
            {
                { 'A', Color.Purple }, {'B', Color.Red }, {'C', Color.LawnGreen },
                { 'D', Color.Cyan }, { 'E', Color.DarkBlue }, { 'F', Color.Yellow },
                { 'G', Color.Maroon }, { 'H', Color.White }
            };
        internal static Dictionary<Color, char> s_ColorToLetter = new Dictionary<Color, char>()
            {
                { Color.Purple, 'A' }, { Color.Red, 'B' }, { Color.LawnGreen, 'C' },
                { Color.Cyan, 'D' }, { Color.DarkBlue, 'E' }, { Color.Yellow, 'F' },
                { Color.Maroon, 'G' }, { Color.White, 'H' }
            };
        internal static Dictionary<char, Color> s_ResultToColor = new Dictionary<char, Color>()
        {
                { 'V', Color.Black }, { 'X', Color.Yellow }
        };

        internal static void Start()
        {
            GameUtils.GetComputerGuess();
            FormStart form = new FormStart();
            form.ShowDialog();
        }

        internal static void CreateResultColorArray(string i_Result)
        {
            for (int j = 0; j < i_Result.Length; j++)
            {
                FormGame.s_Result[s_CurrentGuess - 1, j].BackColor = s_ResultToColor[i_Result[j]];
            }
        }

        internal static void ColorComputerGuess()
        {
            for (int i = 0; i < FormGame.s_ComputerGuess.Length; i++)
            {
                FormGame.s_ComputerGuess[i].BackColor = s_LetterToColor[GameUtils.s_ComputerGuess[i]];
            }
        }
    }
}