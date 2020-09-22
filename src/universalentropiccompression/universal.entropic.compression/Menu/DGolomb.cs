using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class DGolomb : MenuPage
    {
        public DGolomb(MenuProgram menu)
         : base("Select File", menu,
                new Option("Alice29.txt", () => menu.NavigateTo<AliceDecodeGolomb>()),
                new Option("sum", () => menu.NavigateTo<SumDecodeGolomb>()))
        {
        }
    }
}
