using menu;
using System.IO;

using universal.entropic.compression.Domain.Service;

namespace universal.entropic.compression.Menu
{
    class AliceEntropyCal : Page
    {
        public AliceEntropyCal(MenuProgram menu)
         : base("Entropy Calc Alice29.txt file", menu)
        {
        }

        public override void Display()
        {
            base.Display();
            Output.WriteLine("");
            Output.WriteLine("Entropy Calc Alice29.txt file");
            Output.WriteLine("");
            var file = File.ReadAllText(path: Utils.Utils.Archive.Alice29File);
            var entropy = new EntropyCal();
            Output.WriteLine("The Entropy value is: " + entropy.EntropyValue(file).ToString());
            Output.WriteLine("The Entropy bits is: " + entropy.EntropyBits(file).ToString());
            Output.WriteLine("");
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
