using menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Menu
{
    class DoCrc8 : Page
    {
        public DoCrc8(MenuProgram menu)
          : base("Apply crc 8 and hamming parity bits", menu)
        {
        }
        public override void Display()
        {
            base.Display();           
            Output.WriteLine("");
            var crc8 = new Crc8();
            var hamming = new Hamming();
            Output.WriteLine("Apply crc8 and hamming to Alice29 encoded with Golomb");
            //Read a file
            var byteList = File.ReadAllBytes(Utils.Utils.FilesEncoded.GolombEncodeAlice).ToList();
            var newBytesFile = byteList.Take(2).ToList();            
            //Applay crc-8 to 2 first bytes
            newBytesFile.Add(crc8.CRC_8(byteList.Take(2).ToArray()));
            foreach (var item in byteList.Skip(2).ToList())
            {
                
                byte x = item;
                byte nibble1 = (byte)(x & 0x0F);
                byte nibble2 = (byte)((x & 0xF0) >> 4);
                newBytesFile.Add(nibble1);
                var hammingEncode = hamming.hammingEncode(new byte[] { item });
                newBytesFile.Add(hammingEncode.First());
                newBytesFile.Add(nibble2);
                newBytesFile.Add(hammingEncode.Skip(1).First());

            }
            File.WriteAllBytes(Utils.Utils.FilesEncoded.Crc8HammingEncodeGolombAlice, newBytesFile.ToArray());
            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.Crc8HammingEncodeGolombAlice.ToString());
            newBytesFile.Clear();
            byteList.Clear();

            Output.WriteLine("");
            Output.WriteLine("");
           
            

            Output.WriteLine("Apply crc8 and hamming to Alice29 encoded with Fibonacci");
            //Read a file
             byteList = File.ReadAllBytes(Utils.Utils.FilesEncoded.FibonacciEncodeAlice).ToList();
             newBytesFile = byteList.Take(2).ToList();
            //Applay crc-8 to 2 first bytes
            newBytesFile.Add(crc8.CRC_8(byteList.Take(2).ToArray()));
            foreach (var item in byteList.Skip(2).ToList())
            {

                byte x = item;
                byte nibble1 = (byte)(x & 0x0F);
                byte nibble2 = (byte)((x & 0xF0) >> 4);
                newBytesFile.Add(nibble1);
                var hammingEncode = hamming.hammingEncode(new byte[] { item });
                newBytesFile.Add(hammingEncode.First());
                newBytesFile.Add(nibble2);
                newBytesFile.Add(hammingEncode.Skip(1).First());

            }
            File.WriteAllBytes(Utils.Utils.FilesEncoded.Crc8HammingEncodeFibonacciAlice, newBytesFile.ToArray());
            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.Crc8HammingEncodeFibonacciAlice.ToString());
            newBytesFile.Clear();
            byteList.Clear();
            Output.WriteLine("");
            Output.WriteLine("");


            Output.WriteLine("Apply crc8 and hamming to Alice29 encoded with Elias Gamma");
            //Read a file
            byteList = File.ReadAllBytes(Utils.Utils.FilesEncoded.EliasGammaEncodeAlice).ToList();
            newBytesFile = byteList.Take(2).ToList();
            //Applay crc-8 to 2 first bytes
            newBytesFile.Add(crc8.CRC_8(byteList.Take(2).ToArray()));
            foreach (var item in byteList.Skip(2).ToList())
            {

                byte x = item;
                byte nibble1 = (byte)(x & 0x0F);
                byte nibble2 = (byte)((x & 0xF0) >> 4);
                newBytesFile.Add(nibble1);
                var hammingEncode = hamming.hammingEncode(new byte[] { item });
                newBytesFile.Add(hammingEncode.First());
                newBytesFile.Add(nibble2);
                newBytesFile.Add(hammingEncode.Skip(1).First());

            }
            File.WriteAllBytes(Utils.Utils.FilesEncoded.Crc8HammingEncodeEliasGammaAlice, newBytesFile.ToArray());
            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.Crc8HammingEncodeEliasGammaAlice.ToString());
            newBytesFile.Clear();
            byteList.Clear();
            Output.WriteLine("");
            Output.WriteLine("");

            Output.WriteLine("Apply crc8 and hamming to Alice29 encoded with Unary");
            //Read a file
            byteList = File.ReadAllBytes(Utils.Utils.FilesEncoded.UnaryEncodeAlice).ToList();
            newBytesFile = byteList.Take(2).ToList();
            //Applay crc-8 to 2 first bytes
            newBytesFile.Add(crc8.CRC_8(byteList.Take(2).ToArray()));
            foreach (var item in byteList.Skip(2).ToList())
            {

                byte x = item;
                byte nibble1 = (byte)(x & 0x0F);
                byte nibble2 = (byte)((x & 0xF0) >> 4);
                newBytesFile.Add(nibble1);
                var hammingEncode = hamming.hammingEncode(new byte[] { item });
                newBytesFile.Add(hammingEncode.First());
                newBytesFile.Add(nibble2);
                newBytesFile.Add(hammingEncode.Skip(1).First());

            }
            File.WriteAllBytes(Utils.Utils.FilesEncoded.Crc8HammingEncodeUnaryAlice, newBytesFile.ToArray());
            Output.WriteLine(System.ConsoleColor.Green, "View the file encoded in: " + Utils.Utils.FilesEncoded.Crc8HammingEncodeUnaryAlice.ToString());
            newBytesFile.Clear();
            byteList.Clear();
            Output.WriteLine("");
            Output.WriteLine("");






            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
