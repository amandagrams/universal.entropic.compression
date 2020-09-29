using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace universal.entropic.compression.Utils
{
    public class Utils
    {
        public const string FolderArchiveName = "Archive";
        public const string FolderArchiveOutputName = "output";
       

        public class Archive 
        {
            public static string Alice29File = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Archives\\alice29.txt".ToString();
            public static string SumFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Archives\\sum".ToString();

        }
        public class FilesEncoded
        {
            public static string GolombEncodeAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Golomb\\Alice29.cod".ToString();
            public static string GolombEncodeSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Golomb\\sum.cod".ToString();
            public static string EliasGammaEncodeAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\EliasGamma\\Alice29.cod".ToString();
            public static string EliasGammaEncodeSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\EliasGamma\\sum.cod".ToString();
            public static string UnaryEncodeAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Unary\\Alice29.cod".ToString();
            public static string UnaryEncodeSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Unary\\sum.cod".ToString();
            public static string FibonacciEncodeAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Fibonacci\\Alice29.cod".ToString();
            public static string FibonacciEncodeSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Fibonacci\\sum.cod".ToString();
            public static string Crc8HammingEncodeGolombAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Golomb\\Alice29.ecc".ToString();
            public static string Crc8HammingEncodeEliasGammaAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\EliasGamma\\Alice29.ecc".ToString();
            public static string Crc8HammingEncodeUnaryAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Unary\\Alice29.ecc".ToString();
            public static string Crc8HammingEncodeFibonacciAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Fibonacci\\Alice29.ecc".ToString();
            public static string Crc8HammingEncodeFibonacciSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Fibonacci\\sum.ecc".ToString();
            public static string Crc8HammingEncodeGolombSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Golomb\\sum.ecc".ToString();
            public static string Crc8HammingEncodeUnarySum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Unary\\sum.ecc".ToString();

        }

        public class FilesDecoded
        {
            public static string GolombDecodeAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Golomb\\Alice29.dec".ToString();
            public static string GolombDecodeSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Golomb\\sum.dec".ToString();
            public static string UnaryDecodeAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Unary\\Alice29.dec".ToString();
            public static string UnaryDecodeSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Unary\\sum.dec".ToString();
            public static string EliasGammaDecodeAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\EliasGamma\\Alice29.dec".ToString();
            public static string EliasGammaDecodeSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\EliasGamma\\sum.dec".ToString();
            public static string FibonacciDecodeAlice = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Fibonacci\\Alice29.dec".ToString();
            public static string FibonacciDecodeSum = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\output\\Fibonacci\\sum.dec".ToString();

        }
        public enum EncodingTypes
        {
            [Description("Golomb")]
            Golomb = 04,
            [Description("Elias-Gamma")]
            EliasGamma = 10,
            [Description("Fibonacci")]
            Fibonacci = 20,
            [Description("Unária")]
            Unaria = 30,
            [Description("Delta")]
            Delta = 40
        }

        public enum Archives
        {
            [Description("alice29.txt")]
            alice29 = 0,
            [Description("sum")]
            sum = 1,
            [Description("teste.txt")]
            teste = 2
        }
        public enum GolombParm
        {
            [Description("GolombK")]
            K = 4
        }
        public enum Result
        {
            Success,
            Error
        }

        public static string GetDirectoryFileEncodingRead() =>
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\" + FolderArchiveName + @"\";

        public static string GetFileEncoding(Archives archive)
        {
            return GetDirectoryFileEncodingRead() + GetDescription(archive);
        }
        public static string GetDirectoryFileEncodingWrite(Archives archive) =>
             Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + @"\" + FolderArchiveOutputName + @"\"+ archive + @".cod";

        public static string GetDirectoryFileEncodingWriteDecoded(Archives archive) =>
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + @"\" + FolderArchiveOutputName + @"\" + GetDescription(archive);


        public static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
