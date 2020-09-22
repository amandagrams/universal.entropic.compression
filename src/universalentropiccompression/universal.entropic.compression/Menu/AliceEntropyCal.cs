using menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static System.Net.Mime.MediaTypeNames;

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
            var file = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Archives\\alice29.txt");
            var entropy = new EntropyCal();
            Output.WriteLine("The Entropy value is: " + entropy.EntropyValue(file).ToString());
            Output.WriteLine("The Entropy bits is: " + entropy.EntropyBits(file).ToString());
            Output.WriteLine("");
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
