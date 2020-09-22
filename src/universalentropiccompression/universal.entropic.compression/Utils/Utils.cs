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

        public enum Archive
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

        public static string GetFileEncoding(Archive archive)
        {
            return GetDirectoryFileEncodingRead() + GetDescription(archive);
        }
        public static string GetDirectoryFileEncodingWrite(Archive archive) =>
             Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + @"\" + FolderArchiveOutputName + @"\"+ archive + @".cod";

        public static string GetDirectoryFileEncodingWriteDecoded(Archive archive) =>
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
