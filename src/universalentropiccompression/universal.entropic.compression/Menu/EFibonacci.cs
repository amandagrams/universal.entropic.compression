using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class EFibonacci : MenuPage
    {
        public EFibonacci(MenuProgram menu)
        : base("Select File", menu,
               new Option("Alice29.txt", () => menu.NavigateTo<AliceEncodeFibonacci>()),
               new Option("sum", () => menu.NavigateTo<SumEncodeFibonacci>()))
        {
        }
    }
}
