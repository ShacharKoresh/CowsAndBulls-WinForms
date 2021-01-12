using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace B19_Ex05_GameLogic
{
    public class GameUtils
    {
        public const char k_MinLetter = 'A';
        public const char k_MaxLetter = 'H';
        public const int k_MinNumberOfGuesses = 4;
        public const int k_MaxNumberOfGuesses = 10;
        public const int k_LengthPins = 4;
        public static string s_ComputerGuess;
        public static int s_NumberOfGuesses;
        public static Random s_Random = new Random();

        public static void GetComputerGuess()
        {
            StringBuilder stringBuilder = new StringBuilder();
            HashSet<char> randomLettersSet = new HashSet<char>();
            char letter;

            letter = (char)s_Random.Next(k_MinLetter, k_MaxLetter);
            while (randomLettersSet.Count < k_LengthPins)
            {
                if (!randomLettersSet.Contains(letter))
                {
                    randomLettersSet.Add(letter);
                    stringBuilder.Append(letter);
                }

                letter = (char)s_Random.Next(k_MinLetter, k_MaxLetter);
            }

            s_ComputerGuess = stringBuilder.ToString();
        }

        public static string GetResultString(string i_UserGuess)
        {
            int countV = 0, countX = 0;
            char userCharacter, computerCharacter;

            for (int i = 0; i < k_LengthPins; i ++)
            {
                userCharacter = i_UserGuess[i];
                computerCharacter = s_ComputerGuess[i];
                if (userCharacter == computerCharacter)
                {
                    countV++;
                }
                else if (s_ComputerGuess.Contains(userCharacter.ToString()))
                {
                    countX++;
                }
            }

            return createString(countV, countX);
        }

        private static string createString(int i_CountV, int i_CountX)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < i_CountV; i++)
            {
                result.Append('V');
            }

            for (int i = 0; i < i_CountX; i++)
            {
                result.Append('X');
            }

            return result.ToString();
        }
    }
}
