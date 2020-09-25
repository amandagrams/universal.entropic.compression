using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;

namespace universal.entropic.compression.Menu
{
    class AliceDecodeUnary : Page
    {
        public AliceDecodeUnary(MenuProgram menu)
            : base("Encoding Alice29.txt with Unary Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding Alice29.txt with Unary Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var unary = new Unary();
            documents.WriteText(Utils.Utils.FilesDecoded.UnaryDecodeAlice, Encoding.ASCII.GetString(unary.Decode(documents.ReadAllBytes(Utils.Utils.FilesEncoded.UnaryEncodeAlice, false))));
            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.UnaryDecodeAlice.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
