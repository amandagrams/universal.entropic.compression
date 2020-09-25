using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;

namespace universal.entropic.compression.Menu
{
    class SumDecodeUnary : Page
    {
        public SumDecodeUnary(MenuProgram menu)
          : base("Decode sum with Unary Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding sum with Unary Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var unary = new Unary();
            documents.WriteText(Utils.Utils.FilesDecoded.UnaryDecodeSum, Encoding.ASCII.GetString(unary.Decode(documents.ReadAllBytes(Utils.Utils.FilesEncoded.UnaryEncodeSum, false))));
            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.UnaryDecodeSum.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
