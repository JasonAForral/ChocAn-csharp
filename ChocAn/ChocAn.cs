using System;
using ChocAn.Manager;
using ChocAn.TerminalEmulator;

namespace ChocAn
{
    class ChocAn
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            new Terminal(new ChocAnManager()).Start();
        }
    }
}

