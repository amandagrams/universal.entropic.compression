using menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Menu
{
    class AliceDecodeFibonacci : Page
    {
        public AliceDecodeFibonacci(MenuProgram menu)
           : base("Decode Alice29.txt with Fibonacci Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding Alice29.txt with EFibonacci Encode");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
