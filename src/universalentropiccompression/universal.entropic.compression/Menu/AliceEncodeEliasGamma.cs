using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class AliceEncodeEliasGamma : Page
    {
        public AliceEncodeEliasGamma(MenuProgram menu)
           : base("Encoding Alice29.txt with Elias Gamma Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding Alice29.txt with Elias Gamma Encode");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
