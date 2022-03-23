using System;

namespace SmellLevels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, sum = 0;
            double avg = 0;
            string name;

            Console.WriteLine("Zadej jméno: ");
            name = Console.ReadLine();
            for(i = 0; i < name.Length; i++)
            {
                sum += (int)name[i];
            }
            avg = sum / (double)name.Length;
            
            if (Math.Round(avg) %3 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Smrdí jako cibuláči.");
            }
            else if (Math.Round(avg) % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{name} Smrdí jako koňská řiť.");
            }
            else if (Math.Round(avg) % 7 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{name} Smrdí jako bolavá noha bezdomovce.");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} Nesmrdí vůbec.");
            }
        }
    }
}
