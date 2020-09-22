using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class SumEncodeGolomb : Page
    {
        public SumEncodeGolomb(MenuProgram menu)
            : base("Encode sum with Golomb Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encode sum with Golomb Encode");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
