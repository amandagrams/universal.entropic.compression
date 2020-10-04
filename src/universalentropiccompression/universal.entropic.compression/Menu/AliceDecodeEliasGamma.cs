using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;

namespace universal.entropic.compression.Menu
{
    class AliceDecodeEliasGamma : Page
    {
        public AliceDecodeEliasGamma(MenuProgram menu)
           : base("Decode Alice29.txt with Elias Gamma Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding Alice29.txt with Elias Gamma Encode");
            Output.WriteLine("");

            var documents = new Documents();
            var eliasGamma = new EliasGamma();
            eliasGamma.Decoder(documents.ReadAllBytes(Utils.Utils.FilesEncoded.EliasGammaEncodeAlice, false), Utils.Utils.FilesDecoded.EliasGammaDecodeAlice) ;
            
            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.EliasGammaDecodeAlice.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
