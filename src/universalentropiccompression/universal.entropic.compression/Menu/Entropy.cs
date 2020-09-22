using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class Entropy : MenuPage
    {
        public Entropy(MenuProgram menu)
          : base("Entropy Calc", menu,
                new Option("Alice29.txt", () => menu.NavigateTo<AliceEntropyCal>()),
                new Option("sum", () => menu.NavigateTo<SumEntropyCal>()))
        {
        }
    }
}
