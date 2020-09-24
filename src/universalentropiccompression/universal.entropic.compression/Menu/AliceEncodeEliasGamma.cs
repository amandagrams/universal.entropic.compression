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

            //var teste = new Teste();
            //var encode = teste.Encoder(File.ReadAllBytes(Archive.Alice29File), (int)EncodingTypes.EliasGamma);

            //File.WriteAllBytes(FilesEncoded.EliasGammaEncodeAlice,encode);

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
