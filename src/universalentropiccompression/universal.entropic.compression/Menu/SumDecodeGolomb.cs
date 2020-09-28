using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using universal.entropic.compression.Menu.Encoder;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class SumDecodeGolomb : Page
    {
        public SumDecodeGolomb(MenuProgram menu)
          : base("Decode sum with Golomb", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Decoding sum with Golomb");
            Output.WriteLine("");

            var documents = new Documents();

            var golomb = new Golomb();
            documents.WriteText(Utils.Utils.FilesDecoded.GolombDecodeSum, Encoding.ASCII.GetString(golomb.Decode(documents.ReadAllBytes(Utils.Utils.FilesEncoded.GolombEncodeSum, false))));


            Output.WriteLine(System.ConsoleColor.Green, "View the file decoded in: " + Utils.Utils.FilesDecoded.GolombDecodeSum.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
