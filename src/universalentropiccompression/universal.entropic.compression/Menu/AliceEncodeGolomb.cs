using menu;
using universal.entropic.compression.Utils;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class AliceEncodeGolomb : Page
    {
        public AliceEncodeGolomb(MenuProgram menu)
           : base("Encoding Alice29.txt with Golomb Encode", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Encoding Alice29.txt with Golomb Encode");
            Output.WriteLine("");

            var documents = new Documents();

            var golomb = new Golomb();
            
            documents.WriteByte(FilesEncoded.GolombEncodeAlice, golomb.Encoder(documents.ReadAllBytes(Utils.Utils.Archive.Alice29File, true)), true, Documents.Information.Golomb);

            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.GolombEncodeAlice.ToString());
            Output.WriteLine("");
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
