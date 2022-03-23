using System;
using System.Collections.Generic;

namespace SmellLevels
{
    internal class Program
    {
        enum Smells
        {
            OnionRings,
            HorseAss,
            HoboToughLife,
            NoSmell,
        }

        static void Main(string[] args)
        {
            Dictionary<string, Smells> table = new Dictionary<string, Smells>();

            string name = GetName();
            double avg = GetAvg(name);
            Smells level = GetSmell(avg);
            switch (level)
            {
                case Smells.NoSmell:
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Texts.NoSmell);
                }
                    break;

                case Smells.OnionRings:
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Texts.OnionRings);
                }
                    break;

                case Smells.HorseAss:
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(Texts.HorseAss);
                }
                    break;

                case Smells.HoboToughLife:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Texts.HoboToughLife);
                }
                    break;
            }
            Console.ResetColor();
        }

        private static string GetName()
        {
            string name;
            Console.WriteLine("Zadej jméno: ");
            name = Console.ReadLine();
            return name;
        }

        private static double GetAvg(string name)
        {
            int i, sum = 0;
            double avg;
            for (i = 0; i < name.Length; i++)
            {
                sum += (int)name[i];
            }

            avg = sum / (double)name.Length;
            return avg;
        }

        private static Smells GetSmell(double avg)
        {
            int rounded = (int)Math.Round(avg);

            if (rounded % 3 == 0)
            {
                return Smells.OnionRings;
            }

            if (rounded % 5 == 0)
            {
                return Smells.HorseAss;
            }

            if (rounded % 7 == 0)
            {
                return Smells.HoboToughLife;
            }

            return Smells.NoSmell;
        }
    }
}
