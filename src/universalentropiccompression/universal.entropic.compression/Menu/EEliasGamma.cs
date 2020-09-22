using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class EEliasGamma : MenuPage
    {
        public EEliasGamma(MenuProgram menu)
        : base("Select File", menu,
               new Option("Alice29.txt", () => menu.NavigateTo<AliceEncodeEliasGamma>()),
               new Option("sum", () => menu.NavigateTo<SumEncodeEliasGamma>()))
        {
        }
    }
}
