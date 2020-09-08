using System;
using System.IO;
using System.Linq;
using System.Text;
using universal.entropic.compression.Domain.Service;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression
{
    class Program
    {
        static void Main(string[] args)
        {

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
  

        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Encode with Golomb - Alice29.txt");
            Console.WriteLine("2) Decode with Golomb - Alice29.cod");
            Console.WriteLine("3) Encode with Golomb - sum");
            Console.WriteLine("4) Decode with Golomb - sum.cod");
            Console.WriteLine("5) Encode with Elias Gamma - Alice29.txt");
            Console.WriteLine("6) Decode with Elias Gamma - Alice29.cod");
            Console.WriteLine("7) Encode with Elias Gamma - sum");
            Console.WriteLine("8) Decode with Elias Gamma - sum.cod");
            Console.WriteLine("7) Exit");
            Console.Write("\r\nSelect an option: ");

           

            switch (Console.ReadLine())
            {
                case "1":
                    GolombEncode(Archive.alice29);
                    return true;
                case "2":
                    GolombDecode(Archive.alice29);
                    return true;
                case "3":
                    GolombEncode(Archive.sum);
                    return true;
                case "4":
                    GolombDecode(Archive.sum);
                    return true;
                case "5":
                    EliasGammaEncode(Archive.alice29);
                    return true;
                case "6":
                    EliasGammaDecode(Archive.alice29);
                    return true;
                case "7":
                    EliasGammaEncode(Archive.sum);
                    return true;
                case "8":
                    EliasGammaDecode(Archive.sum);
                    return false;
                default:
                    return true;
            }
        }



        private static void DisplayResult(string message)
        {
            Console.WriteLine($"\r\nYour modified string is: {message}");
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }
        private static void GolombEncode(Archive archive)
        {
            var file = new Files();
            Encoding ascii = Encoding.ASCII;
            //var file = new Files();
            Byte[] asciiEncodedBytes = ascii.GetBytes(file.ReadAllBytes(GetFileEncoding(archive)));
            var golomb = new Golomb((int)GolombParm.K, (int)EncodingTypes.Golomb, (int)GolombParm.K);
            Console.WriteLine("Encoded to " + GetDescription(EncodingTypes.Golomb));

            foreach (Byte b in asciiEncodedBytes)
                golomb.Encode(b);

            file.Write(GetDirectoryFileEncodingWrite(archive), golomb.ResultSymbol.ToString());
            DisplayResult("Encode ok, view the file on " + GetDirectoryFileEncodingWrite(archive));
        }

        private static void GolombDecode(Archive archive)
        {
            var file = new Files();
            Console.WriteLine("Decoded to " + GetDescription(EncodingTypes.Golomb));
            var golombD = new Golomb((int)GolombParm.K, (int)EncodingTypes.Golomb, (int)GolombParm.K);
            var gololmbDecode = golombD.Decode(file.ReadAllBytes(GetDirectoryFileEncodingWrite(archive)));
            var strDecode = Encoding.ASCII.GetString(gololmbDecode);
            file.Write(GetDirectoryFileEncodingWriteDecoded(archive), strDecode);
            DisplayResult("Decode ok, view the file on " + GetDirectoryFileEncodingWriteDecoded(archive));
        }

        private static void EliasGammaEncode(Archive archive)
        {
            var file = new Files();
            Encoding ascii = Encoding.ASCII;
            Byte[] asciiEncodedBytes = ascii.GetBytes(file.ReadAllBytes(GetFileEncoding(archive)));
            var eliasGamma = new EliasGamma((int)EncodingTypes.EliasGamma);
            Console.WriteLine("Encoded to " + GetDescription(EncodingTypes.EliasGamma));
            foreach (Byte b in asciiEncodedBytes)
                eliasGamma.Encode(b);

            file.Write(GetDirectoryFileEncodingWrite(archive), eliasGamma.ResultSymbol.ToString());
            DisplayResult("Encode ok, view the file on " + GetDirectoryFileEncodingWrite(archive));
        }

        private static void EliasGammaDecode(Archive archive)
        {
            var file = new Files();
            Console.WriteLine("Decoded to " + GetDescription(EncodingTypes.EliasGamma));
            var eliasGamma = new EliasGamma((int)EncodingTypes.EliasGamma);
            var eliasGammaDecode = eliasGamma.Decode(file.ReadAllBytes(GetDirectoryFileEncodingWrite(archive)));
            var strDecode = Encoding.ASCII.GetString(eliasGammaDecode);
            file.Write(GetDirectoryFileEncodingWriteDecoded(archive), strDecode);
            DisplayResult("Decode ok, view the file on " + GetDirectoryFileEncodingWriteDecoded(archive));
        }
    }
}
