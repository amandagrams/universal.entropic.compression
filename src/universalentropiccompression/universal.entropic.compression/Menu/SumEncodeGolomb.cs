using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class SumEncodeGolomb : Page
    {
        public SumEncodeGolomb(MenuProgram menu)
            : base("Encode sum with Golomb", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encode sum with Golomb");
            Output.WriteLine("");

            var documents = new Documents();

            var golomb = new Golomb((int)GolombParm.K, (int)EncodingTypes.Golomb, (int)GolombParm.K);

            documents.WriteByte(FilesEncoded.GolombEncodeSum, golomb.Encoder(documents.ReadAllBytes(Utils.Utils.Archive.SumFile, true)), true, Documents.Information.Golomb);

            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.GolombEncodeSum.ToString());

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
