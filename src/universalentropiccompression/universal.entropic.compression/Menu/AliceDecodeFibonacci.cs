using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;

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

            Output.WriteLine("Decoding Alice29.txt with Fibonacci Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var fibonacci = new Fibonacci();
            documents.WriteText(Utils.Utils.FilesDecoded.FibonacciDecodeAlice, fibonacci.Decode(documents.ReadAllBytes(Utils.Utils.FilesEncoded.FibonacciEncodeAlice, false)));

            
            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.FibonacciDecodeAlice.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
