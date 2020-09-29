using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class CRC8 : MenuPage
    {
        public CRC8(MenuProgram menu)
            : base("TGA - Teoria da Informação", menu,
           new Option("CRC8 + Hamming", () => menu.NavigateTo<DoCrc8>()))
        {
        }
    }
}
