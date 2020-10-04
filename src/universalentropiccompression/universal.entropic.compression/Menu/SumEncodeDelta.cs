using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class SumEncodeDelta : Page
    {
        public SumEncodeDelta(MenuProgram menu)
         : base("Encode sum with Delta Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encode sum with Delta Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var delta = new Delta();

            documents.WriteByte(FilesEncoded.DeltaEncodeSum, delta.Encoder(documents.ReadAllBytes(Utils.Utils.Archive.SumFile, true)), true, Documents.Information.Delta);

            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.DeltaEncodeSum.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
