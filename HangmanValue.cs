using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public static class HangmanValue
    {
        public static List<string> WordList { get; set; } = new List<string>() { "hand", "equable", "charge", "silver", "greasy" };

        public static string RandomWord()
        {
            Random random = new Random();
            int num = random.Next(WordList.Count);

            return WordList[num];
        }

        public static void Game()
        {
            List<char> wordChar = new List<char>();
            List<char> wordsCharGame = new List<char>();
            string word = RandomWord();
            int round = 0;

            foreach (char c in word)
            {
                wordChar.Add(c);
                wordsCharGame.Add('_');
            }

            while (!wordChar.SequenceEqual(wordsCharGame) && round < 9)
            {
                Console.Clear();
                
                foreach (char c in wordsCharGame)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                HangmanDrawer(round);

                //  +-----+
                // \o/    |
                //  |     |
                // / \    |

                Console.WriteLine();

                string input = Console.ReadLine();

                bool found = false;
                for (int i = 0; i < wordChar.Count; i++)
                {
                    if (wordChar[i] == InputChecker(input))
                    {
                        wordsCharGame[i] = InputChecker(input);
                        found = true;
                    }
                }

                if (!found)
                {
                    round++;
                }
            }
            Console.Clear();

            if (round >= 9)
            {
                Console.WriteLine("You LOST"+ " word is: "+ word);
            }
            else
            {
                Console.WriteLine("YOU WIN!@!@!@" + " word is: " + word);
            }
        }

        public static char InputChecker(string input)
        {
            try
            {
                return char.Parse(input);
            }
            catch (Exception)
            {
                return '\0';
            }
        }

        public static void HangmanDrawer(int i)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine("       +");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    break;
                case 2:
                    Console.WriteLine(" +-----+");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    break;
                case 3:
                    Console.WriteLine(" +-----+");
                    Console.WriteLine(" o     |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    break;
                case 4:
                    Console.WriteLine(" +-----+");
                    Console.WriteLine(" o     |");
                    Console.WriteLine(" |     |");
                    Console.WriteLine("       |");
                    break;
                case 5:
                    Console.WriteLine(" +-----+");
                    Console.WriteLine(" o     |");
                    Console.WriteLine(" |     |");
                    Console.WriteLine("/      |");
                    break;
                case 6:
                    Console.WriteLine(" +-----+");
                    Console.WriteLine(" o     |");
                    Console.WriteLine(" |     |");
                    Console.WriteLine("/ \\    |");
                    break;
                case 7:
                    Console.WriteLine(" +-----+");
                    Console.WriteLine(" o/    |");
                    Console.WriteLine(" |     |");
                    Console.WriteLine("/ \\    |");
                    break;
                case 8:
                    Console.WriteLine(" +-----+");
                    Console.WriteLine("\\o/    |");
                    Console.WriteLine(" |     |");
                    Console.WriteLine("/ \\    |");
                    break;
                case 9:
                    Console.WriteLine(" +-----+");
                    Console.WriteLine("\\o/    |");
                    Console.WriteLine(" |     |");
                    Console.WriteLine("/ \\    |");
                    Console.WriteLine("YOU LOST");
                    break;
            }
        }
    }
}
