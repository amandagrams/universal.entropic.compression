using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class SumEncodeEliasGamma : Page
    {
        public SumEncodeEliasGamma(MenuProgram menu)
        : base("Encode sum with Elias Gamma Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encode sum with Elias Gamma Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var eliasGamma = new EliasGamma();

            documents.WriteByte(FilesEncoded.EliasGammaEncodeSum, eliasGamma.Encoder(documents.ReadAllBytes(Utils.Utils.Archive.SumFile, true)), true, Documents.Information.EliasGamma);

            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.EliasGammaEncodeSum.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
