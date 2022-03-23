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

        static Dictionary<string, Smells> people = new Dictionary<string, Smells>();

        static void Main(string[] args)
        {
            while (true)
            {
                string name = GetName();
                double avg = GetAvg(name);
                Smells level = GetSmell(name,avg);
                AddPeople(name, level);
                Table();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static string GetName()
        {
            string name;
            Console.WriteLine("Zadej jméno smraďocha: ");
            name = Console.ReadLine();
            return name;
        }

        private static void AddPeople(string name, Smells level)
        {
            Console.WriteLine($"{name} {level}.");
            people.Add(name, level);
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

        private static Smells GetSmell(string name, double avg)
        {
            int rounded = (int)Math.Round(avg);

            if (rounded % 7 == 0 || name.ToUpper() == "JANUS RADULUS")
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
            Console.WriteLine("Tabulka smraďochů:\n---------------");
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
        }
    }
}
