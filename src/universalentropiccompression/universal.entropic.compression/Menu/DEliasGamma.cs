using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class DEliasGamma : MenuPage
    {
        public DEliasGamma(MenuProgram menu)
        : base("Select File", menu,
               new Option("Alice29.txt", () => menu.NavigateTo<AliceDecodeEliasGamma>()),
               new Option("sum", () => menu.NavigateTo<SumDecodeEliasGamma>()))
        {
        }
    }
}
