using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class EGolomb : MenuPage
    {
        public EGolomb(MenuProgram menu)
         : base("Select File", menu,
                new Option("Alice29.txt", () => menu.NavigateTo<AliceEncodeGolomb>()),
                new Option("sum", () => menu.NavigateTo<SumEncodeGolomb>()))
        {
        }
    }
}
