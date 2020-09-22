using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class AliceEntropyCal : Page
    {
        public AliceEntropyCal(MenuProgram menu)
         : base("Entropy Calc Alice29.txt file", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Entropy Calc Alice29.txt file");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
