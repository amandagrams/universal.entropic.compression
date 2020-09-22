using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class DDelta : MenuPage
    {
        public DDelta(MenuProgram menu)
         : base("Select File", menu,
                new Option("Alice29.txt", () => menu.NavigateTo<AliceDecodeDelta>()),
                new Option("sum", () => menu.NavigateTo<SumEncodeDelta>()))
        {
        }
    }
}
