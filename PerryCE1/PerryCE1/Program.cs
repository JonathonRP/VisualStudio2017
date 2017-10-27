using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrettyConsole();

            var name = Input("Please Enter your full Name: ", ConsoleColor.Red).Split(' ');

            var firstName = $"First Name: {name.ElementAtOrDefault(0)}";
            var lastName = $"Last Name: ";
            var middleInitial = $"Middle Initial: {name.ElementAtOrDefault(1)}";
            var suffix = $"Suffix: {name.ElementAtOrDefault(3)}";

            var Exit = "Press any key to exit...";

            switch (name.Length)
            {
                case 1:
                    if (name.ElementAt(0) == "")
                    {
                        Console.Clear();
                        Main(null);
                        break;
                    }
                    else
                    {
                        Print(firstName, newline: true);
                        Print(Exit);
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    Print(firstName, newline: true);
                    Print(lastName + name.ElementAt(1), newline: true);
                    Print(Exit);
                    Console.ReadKey();
                    break;
                case 3:
                    Print(firstName, newline: true);
                    Print(middleInitial, newline: true);
                    Print(lastName + name.ElementAt(2), newline: true);
                    Print(Exit);
                    Console.ReadKey();
                    break;
                default:
                    Print(firstName, newline: true);
                    Print(middleInitial, newline: true);
                    Print(lastName + name.ElementAt(2), newline: true);
                    Print(suffix, newline: true);
                    Print(Exit);
                    Console.ReadKey();
                    break;
            }
        }
        static void PrettyConsole()
        {
            ConsoleColor defualt = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            Console.ForegroundColor = defualt;
            Console.Clear();
        }
        public static void Print(string prompt, ConsoleColor color = ConsoleColor.Black, bool newline = false)
        {
            Console.ForegroundColor = color;

            if (newline == true)
                Console.WriteLine(prompt);
            else
                Console.Write(prompt);
        }
        public static string Input(string prompt, ConsoleColor color = ConsoleColor.Black)
        {
            Print(prompt);
            Console.ForegroundColor = color;
            var responce = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
            return responce;
        }
    }
}
