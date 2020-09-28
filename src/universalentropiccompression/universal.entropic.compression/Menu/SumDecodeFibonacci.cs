using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;

namespace universal.entropic.compression.Menu
{
    class SumDecodeFibonacci : Page
    {
        public SumDecodeFibonacci(MenuProgram menu)
         : base("Decode sum with fibonacci Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding sum with fibonacci Encode");
            
            Output.WriteLine("");

            var documents = new Documents();

            var fibonacci = new Fibonacci();
            documents.WriteText(Utils.Utils.FilesDecoded.FibonacciDecodeSum, fibonacci.Decode(documents.ReadAllBytes(Utils.Utils.FilesEncoded.FibonacciEncodeSum, false)));

            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.FibonacciDecodeSum.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
