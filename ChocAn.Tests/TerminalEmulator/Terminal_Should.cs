using Xunit;
using System;
using ChocAn.TerminalEmulator;

namespace ChocAn.Tests.TerminalEmulator
{
    public class Terminal_Should
    {
        public readonly Terminal terminal;

        public Terminal_Should()
        {
            terminal = new Terminal();
        }

        [Fact]
        public void PromptWithBreadcrumbs()
        {
            terminal.BreadcrumbPrompt();
        }
    }
}
