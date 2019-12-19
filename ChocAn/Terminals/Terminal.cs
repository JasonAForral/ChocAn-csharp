using System;
using System.Collections.Generic;
using System.Linq;
using ChocAn.Manager;

namespace ChocAn.TerminalEmulator
{
    public class Terminal
    {
        private readonly Stack<string> breadcrumbs;

        private readonly ChocAnManager manager;

        public Terminal(Manager.ChocAnManager manager)
        {
            this.manager = manager;
            breadcrumbs = new Stack<string>();
            
        }

        public void BreadcrumbPrompt()
        {
            string[] array = breadcrumbs.ToArray();
            Array.Reverse(array);
            foreach (string n in array)
            {
                Console.Write(n + " > ");
            }
        }

        public void Start()
        {
            breadcrumbs.Push("Terminal");
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.Write(@"
CHOOOSE!!!
 1 - a
 2 - b
 3 - seven
");
                BreadcrumbPrompt();
                consoleKeyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("\nAYYY!!");
                        break;
                    case ConsoleKey.B:
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("\nBAYYY!!");
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        Console.WriteLine("\nseven");
                        break;
                    default:
                        Console.WriteLine();
                        continue;
                }

                _ = manager;

                string last = $"{consoleKeyInfo.KeyChar}";
                if (breadcrumbs.Peek().Equals(last))
                    breadcrumbs.Pop();
                else
                    breadcrumbs.Push(last);

            } while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }
    }
}
