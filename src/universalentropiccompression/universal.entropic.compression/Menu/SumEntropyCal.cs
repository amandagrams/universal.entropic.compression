using menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using universal.entropic.compression.Domain.Service;

namespace universal.entropic.compression.Menu
{
    class SumEntropyCal : Page
    {
        public SumEntropyCal(MenuProgram menu)
           : base("Entropy Calc sum file", menu)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("");
            Output.WriteLine("Entropy Calc sum file");
            Output.WriteLine("");
            var file = File.ReadAllText(path: Utils.Utils.Archive.SumFile);
            var entropy = new EntropyCal();
            Output.WriteLine("The Entropy value is: " + entropy.EntropyValue(file).ToString());
            Output.WriteLine("The Entropy bits is: " + entropy.EntropyBits(file).ToString());
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
