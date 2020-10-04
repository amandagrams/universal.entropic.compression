using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;

namespace universal.entropic.compression.Menu
{
    class AliceDecodeDelta : Page
    {
        public AliceDecodeDelta(MenuProgram menu)
           : base("Decode Alice29.txt with Delta Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding Alice29.txt with Delta Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var delta = new Delta();
            documents.WriteText(Utils.Utils.FilesDecoded.DeltaDecodeAlice, Encoding.ASCII.GetString(delta.Decode(documents.ReadAllBytes(Utils.Utils.FilesEncoded.DeltaEncodeAlice, false))));
            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.DeltaDecodeAlice.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
