using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class EDelta : MenuPage
    {
        public EDelta(MenuProgram menu)
         : base("Select File", menu,
                new Option("Alice29.txt", () => menu.NavigateTo<AliceEncodeDelta>()),
                new Option("sum", () => menu.NavigateTo<SumEncodeDelta>()))
        {
        }
    }
}
