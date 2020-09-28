using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class AliceEncodeFibonacci : Page
    {
        public AliceEncodeFibonacci(MenuProgram menu)
           : base("Encoding Alice29.txt with Fibonacci Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encoding Alice29.txt with Fibonacci Encode");
            Output.WriteLine("");

            var documents = new Documents();

            
            var fibonacci = new Fibonacci();

            documents.WriteByte(FilesEncoded.FibonacciEncodeAlice, fibonacci.Encode(documents.ReadText(Utils.Utils.Archive.Alice29File)), true, Documents.Information.Fibonacci);
            Output.WriteLine("");
            Output.WriteLine("");


            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.FibonacciEncodeAlice.ToString());
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
