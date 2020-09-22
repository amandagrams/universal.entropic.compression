using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class DUnary : MenuPage
    {
        public DUnary(MenuProgram menu)
         : base("Select File", menu,
                new Option("Alice29.txt", () => menu.NavigateTo<AliceDecodeUnary>()),
                new Option("sum", () => menu.NavigateTo<SumDecodeUnary>()))
        {
        }
    }
}
