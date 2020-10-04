using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class AliceEncodeDelta : Page
    {
        public AliceEncodeDelta(MenuProgram menu)
           : base("Encoding Alice29.txt with Delta Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding Alice29.txt with Delta Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var delta = new Delta();

            documents.WriteByte(FilesEncoded.DeltaEncodeAlice, delta.Encoder(documents.ReadAllBytes(Utils.Utils.Archive.Alice29File, true)), true, Documents.Information.Delta);

            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.DeltaEncodeAlice.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
