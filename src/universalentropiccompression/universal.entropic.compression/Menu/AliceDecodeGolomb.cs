using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class AliceDecodeGolomb : Page
    {
        public AliceDecodeGolomb(MenuProgram menu)
           : base("Decoding Alice29.txt with Golomb Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding Alice29.txt with Golomb Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var golomb = new Golomb((int)GolombParm.K, (int)EncodingTypes.Golomb, (int)GolombParm.K);
            documents.WriteText(Utils.Utils.FilesDecoded.GolombDecodeAlice, Encoding.ASCII.GetString(golomb.Decode(documents.ReadAllBytes(Utils.Utils.FilesEncoded.GolombEncodeAlice, false))));
            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.GolombDecodeAlice.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
