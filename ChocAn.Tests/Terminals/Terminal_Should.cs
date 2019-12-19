using Xunit;
using System;
using ChocAn.TerminalEmulator;
using ChocAn.Manager;

namespace ChocAn.Tests.TerminalEmulator
{
    public class Terminal_Should
    {
        public readonly Terminal terminal;

        public Terminal_Should()
        {
            terminal = new Terminal(new ChocAnManager());
        }

        [Fact]
        public void PromptWithBreadcrumbs()
        {
            terminal.BreadcrumbPrompt();
        }
    }
}
