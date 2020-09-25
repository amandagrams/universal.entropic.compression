using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

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
            Output.WriteLine("");

            var documents = new Documents();

            var unary = new Unary();

            documents.WriteByte(FilesEncoded.UnaryEncodeAlice, unary.Encode(documents.ReadAllBytes(Utils.Utils.Archive.Alice29File, true)), true, Documents.Information.Unary);

            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.UnaryEncodeAlice.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
