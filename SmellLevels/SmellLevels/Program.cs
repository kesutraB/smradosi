using System;
using System.Collections.Generic;
using System.IO;

namespace SmellLevels
{
    internal class Program
    {
        enum Smells
        {
            OnionRings,
            HorseAss,
            HoboToughLife,
            NoSmell
        }

        static Dictionary<string, Smells> people = new Dictionary<string, Smells>();
        const string SavePath = "c:\\temp\\SmellTable.txt";

        static void Main(string[] args)
        {
            while (true)
            {
                int sum = 0;
                string name = GetName();

                var Exit = FExit(name);
                if(Exit){continue;}
                var Save = FSave(name);
                if (Save){continue;}

                double avg = GetAvg(name,sum);
                Smells level = GetSmell(name,avg);
                AddPeople(name, level);

                Table();

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static bool FSave(string text)
        {
            if (text.Equals(Texts.SaveWord, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var person in people)
                {
                    File.AppendAllText(SavePath, $"{person.Key} {person.Value}\n");
                }

                Console.WriteLine("Uloženo");
                return true;
            }

            return false;
        }

        private static bool FExit(string text)
        {
            if (text.Equals(Texts.ExitWord, StringComparison.InvariantCultureIgnoreCase))
            {
                Environment.Exit(0);
                return true;
            }

            return false;
        }

        private static void AddPeople(string name, Smells level)
        {
            people.Add(name, level);
        }

        private static string GetName()
        {
            Console.Write("Zadej jméno smraďocha: ");
            return Console.ReadLine();
        }

        private static double GetAvg(string name, int sum)
        {
            int i;
            double avg;
            for (i = 0; i < name.Length; i++)
            {
                if(name[i] == ' '){continue;}
                sum += (int)name[i];
            }

            avg = sum / (double)name.Length;
            return avg;
        }

        private static Smells GetSmell(string name, double avg)
        {
            int rounded = (int)Math.Round(avg);
            if (rounded % 7 == 0 || name.ToUpper() == "JANUS RADULUS" || name.ToUpper() == "MAGDALÉNA HRIŠKOVÁ")
            {
                return Smells.HoboToughLife;
            }

            if (rounded % 5 == 0)
            {
                return Smells.HorseAss;
            }

            if (rounded % 3 == 0)
            {
                return Smells.OnionRings;
            }

            return Smells.NoSmell;
        }

        private static void Table()
        {
            Console.WriteLine("Tabulka smraďochů:\n-------------------");
            foreach (KeyValuePair<string, Smells> person in people)
            {
                Console.Write($"{person.Key}\t");
                switch (person.Value)
                {
                    case Smells.NoSmell:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Texts.NoSmell);
                    }
                        break;

                    case Smells.OnionRings:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
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
        }
    }
}
