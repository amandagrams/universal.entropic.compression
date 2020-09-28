using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class SumEncodeFibonacci : Page
    {
        public SumEncodeFibonacci(MenuProgram menu)
             : base("Encode sum with Fibonacci Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encode sum with Fibonacci Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var fibonacci = new Fibonacci();

            documents.WriteByte(FilesEncoded.FibonacciEncodeSum, fibonacci.Encode(documents.ReadText(Utils.Utils.Archive.SumFile)), true, Documents.Information.Fibonacci);

            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.FibonacciEncodeSum.ToString());

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
