using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class SumEncodeUnary : Page
    {
        public SumEncodeUnary(MenuProgram menu)
           : base("Encode sum with Unary Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encode sum with Unary Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var unary = new Unary();

            documents.WriteByte(FilesEncoded.UnaryEncodeSum, unary.Encode(documents.ReadAllBytes(Utils.Utils.Archive.SumFile, true)), true, Documents.Information.Unary);

            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.UnaryEncodeSum.ToString());
            Output.WriteLine("");
            Output.WriteLine("");
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
