using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;

namespace universal.entropic.compression.Menu
{
    class SumDecodeDelta : Page
    {
        public SumDecodeDelta(MenuProgram menu)
       : base("Decode sum with delta Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding sum with delta Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var delta = new Delta();
            documents.WriteText(Utils.Utils.FilesDecoded.DeltaDecodeSum, Encoding.ASCII.GetString(delta.Decode(documents.ReadAllBytes(Utils.Utils.FilesEncoded.DeltaEncodeSum, false))));
            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.DeltaDecodeSum.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
