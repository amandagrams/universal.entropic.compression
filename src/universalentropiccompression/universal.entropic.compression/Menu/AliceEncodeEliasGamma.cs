using menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class AliceEncodeEliasGamma : Page
    {
        public AliceEncodeEliasGamma(MenuProgram menu)
           : base("Encoding Alice29.txt with Elias Gamma Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encoding Alice29.txt with Elias Gamma Encode");

            Output.WriteLine("");

            var documents = new Documents();

            var eliasGamma = new EliasGamma();

            documents.WriteByte(FilesEncoded.EliasGammaEncodeAlice, eliasGamma.Encoder(documents.ReadAllBytes(Utils.Utils.Archive.Alice29File, true)), true, Documents.Information.EliasGamma);

            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.EliasGammaEncodeAlice.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
