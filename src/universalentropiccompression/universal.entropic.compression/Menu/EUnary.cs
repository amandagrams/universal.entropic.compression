using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class EUnary : MenuPage
    {
        public EUnary(MenuProgram menu)
          : base("Unary", menu,
                 new Option("Alice29.txt", () => menu.NavigateTo<AliceEncodeUnary>()),
                 new Option("sum", () => menu.NavigateTo<SumEncodeUnary>()))
        {
        }
    }
}
