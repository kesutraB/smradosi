using System;
using System.Collections.Generic;
using System.IO;

namespace SmellLevels
{
    internal class Program
    {
        enum Smells
        {
            OnionRings,     //0
            HorseAss,       //1
            HoboToughLife,  //2
            NoSmell         //3
        }

        static Dictionary<string, Smells> people = new Dictionary<string, Smells>();
        const string FilePath = "c:\\temp\\SmellTable.txt";

        static void Main(string[] args)
        {
            PrintSavedTable(people);

            while (true)
            {
                int sum = 0;

                string name = GetName();

                var Exit = FExit(name);
                if(Exit){continue;}

                var Save = FSave(name);
                if (Save){continue;}

                var Duplicate = FDuplicate(name);
                if(Duplicate){continue;}

                double avg = GetAvg(name,sum);

                Smells level = GetSmell(name,avg);

                AddPeople(name, level);

                PrintTable();

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static string GetName()
        {
            Console.Write("\nZadej jméno smraďocha: ");
            return Console.ReadLine();
        }

        private static double GetAvg(string name, int sum)
        {
            int i;
            double avg;
            for (i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ') { continue; }
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

        private static void AddPeople(string name, Smells level)
        {
            people.Add(name, level);
        }

        private static bool FSave(string text)
        {
            if(File.Exists(FilePath)){File.Delete(FilePath);}
            if (text.Equals(Texts.SaveWord, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var person in people)
                {
                    File.AppendAllText(FilePath, $"{person.Key} - {(int)person.Value}\n");
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

        private static bool FDuplicate(string name)
        {
            if (people.ContainsKey(name))
            {
                Console.WriteLine("\nTento smraďoch byl už ohodnocen!!!\n");
                return true;
            }

            return false;
        }

        private static void PrintSavedTable(Dictionary<string, Smells> people)
        {
            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    if(line.Length == 0){return;}

                    string SavedName = line.Split(Texts.Dash)[0];
                    Smells SavedSmells = (Smells)Enum.Parse((typeof(Smells)),(line.Split(Texts.Dash)[1]));
                    people.Add(SavedName, SavedSmells);

                }
            }
            if (File.Exists(FilePath))
            {
                if (new FileInfo(FilePath).Length != 0) { PrintTable(); }
            }
        }

        private static void PrintTable()
        {
            Console.WriteLine("\nTabulka smraďochů:\n-------------------");
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
