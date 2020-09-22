using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class AliceDecodeEliasGamma : Page
    {
        public AliceDecodeEliasGamma(MenuProgram menu)
           : base("Decode Alice29.txt with Elias Gamma Encode", menu)
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
