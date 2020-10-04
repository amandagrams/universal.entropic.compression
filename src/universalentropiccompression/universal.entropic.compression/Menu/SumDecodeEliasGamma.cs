using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;

namespace universal.entropic.compression.Menu
{
    class SumDecodeEliasGamma : Page
    {
        public SumDecodeEliasGamma(MenuProgram menu)
        : base("Decode sum with elias gamma Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding sum with elias gamma Encode");
            Output.WriteLine("Decoding Alice29.txt with Elias Gamma Encode");
            Output.WriteLine("");

            var documents = new Documents();
            var eliasGamma = new EliasGamma();
            eliasGamma.Decoder(documents.ReadAllBytes(Utils.Utils.FilesEncoded.EliasGammaEncodeSum, false), Utils.Utils.FilesDecoded.EliasGammaDecodeSum);

            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.EliasGammaDecodeSum.ToString());
            Output.WriteLine("");
            Output.WriteLine("");


            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
