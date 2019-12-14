using System;
using System.Collections.Generic;
using System.Text;

namespace ChocAn.TerminalEmulator
{
    public class Terminal
    {
        private readonly Stack<string> breadcrumbs;

        public Terminal()
        {
            breadcrumbs = new Stack<string>();
            breadcrumbs.Push("Terminal");
        }

        public void BreadcrumbPrompt()
        {
            foreach (string n in breadcrumbs)
            {
                Console.Write(n + " > ");
            }
        }

        public void Start()
        {
            BreadcrumbPrompt();
        }
    }
}
