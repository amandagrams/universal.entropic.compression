using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class SumEntropyCal : Page
    {
        public SumEntropyCal(MenuProgram menu)
           : base("Entropy Calc sum file", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Entropy Calc sum file");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
