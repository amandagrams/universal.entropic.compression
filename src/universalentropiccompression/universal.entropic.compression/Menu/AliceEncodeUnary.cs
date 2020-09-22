using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class AliceEncodeUnary : Page
    {
        public AliceEncodeUnary(MenuProgram menu)
            : base("Alice29.txt", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encoding Alice29.txt with Unary Encode");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
