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
            Console.WriteLine("9) Encode with Fibonacci- Alice29.txt");
            Console.WriteLine("10) Decode with Fibonacci- Alice29.txt");
            Console.WriteLine("11) Encode with Fibonacci- sum");
            Console.WriteLine("12) Decode with Fibonacci- sum.cod");
            Console.WriteLine("13) Encode with Unary- Alice29.txt");
            Console.WriteLine("14) Decode with Unary- Alice.cod");
            Console.WriteLine("15) Encode with Unary- sum");
            Console.WriteLine("16) Decode with Unary- sum.cod");
            Console.WriteLine("17) Exit");
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
                    return true;
                case "9":
                    FibonacciEncode(Archive.alice29);
                    return true;
                case "10":
                    FibonacciDecode(Archive.alice29);
                    return true;
                case "11":
                    FibonacciEncode(Archive.sum);
                    return true;
                case "12":
                    FibonacciDecode(Archive.sum);
                    return true;
                case "13":
                    UnaryEncode(Archive.alice29);
                    return true;
                case "14":
                    UnaryDecode(Archive.alice29);
                    return true;
                case "15":
                    UnaryEncode(Archive.sum);
                    return true;
                case "16":
                    UnaryDecode(Archive.sum);
                    return true;
                case "17":
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

        private static void FibonacciEncode(Archive archive) 
        {
            var file = new Files();
            Encoding ascii = Encoding.ASCII;
            Byte[] asciiEncodedBytes = ascii.GetBytes(file.ReadAllBytes(GetFileEncoding(archive)));
            var fibo = new Fibonacci((int)EncodingTypes.Fibonacci);
            Console.WriteLine("Encoded to " + GetDescription(EncodingTypes.Fibonacci));
            foreach (Byte b in asciiEncodedBytes)
                fibo.Encode(b);

            file.Write(GetDirectoryFileEncodingWrite(archive), fibo.ResultSymbol.ToString());
            DisplayResult("Encode ok, view the file on " + GetDirectoryFileEncodingWrite(archive));
        }

        private static void FibonacciDecode(Archive archive)
        {
            var file = new Files();
            Console.WriteLine("Decoded to " + GetDescription(EncodingTypes.Fibonacci));
            var fibo = new Fibonacci((int)EncodingTypes.Fibonacci);
            var fiboDecode = fibo.Decode(file.ReadAllBytes(GetDirectoryFileEncodingWrite(archive)));
            var strDecode = Encoding.ASCII.GetString(fiboDecode);
            file.Write(GetDirectoryFileEncodingWriteDecoded(archive), strDecode);
            DisplayResult("Decode ok, view the file on " + GetDirectoryFileEncodingWriteDecoded(archive));
        }
        private static void UnaryEncode(Archive archive)
        {
            var file = new Files();
            Encoding ascii = Encoding.ASCII;
            Byte[] asciiEncodedBytes = ascii.GetBytes(file.ReadAllBytes(GetFileEncoding(archive)));
            var unary = new Unary((int)EncodingTypes.Unaria);
            Console.WriteLine("Encoded to " + GetDescription(EncodingTypes.Unaria));
            foreach (Byte b in asciiEncodedBytes)
                unary.Encode(b);

            file.Write(GetDirectoryFileEncodingWrite(archive), unary.ResultSymbol.ToString());
            DisplayResult("Encode ok, view the file on " + GetDirectoryFileEncodingWrite(archive));
        }

        private static void UnaryDecode(Archive archive)
        {
            var file = new Files();
            Console.WriteLine("Decoded to " + GetDescription(EncodingTypes.Unaria));
            var unary = new Unary((int)EncodingTypes.Unaria);
            var unaryDecode = unary.Decode(file.ReadAllBytes(GetDirectoryFileEncodingWrite(archive)));
            var strDecode = Encoding.ASCII.GetString(unaryDecode);
            file.Write(GetDirectoryFileEncodingWriteDecoded(archive), strDecode);
            DisplayResult("Decode ok, view the file on " + GetDirectoryFileEncodingWriteDecoded(archive));
        }
    }
}
