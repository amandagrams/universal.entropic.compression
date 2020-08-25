using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace universal.entropic.compression.Utils
{
    public class Utils
    {
        public const int MAX_LINES_BUFFER = 100000;
        public static class FilesPath
        {
            public const string Alice29 = @"C:\Users\amanda\Documents\GitHub\universal.entropic.compression\src\universalentropiccompression\universal.entropic.compression\Files\alice29.txt";
            public const string Sum = @"C:\Users\amanda\Documents\GitHub\universal.entropic.compression\src\universalentropiccompression\universal.entropic.compression\Files\sum";
            public const string TesteFile = @"C:\Users\amanda\Documents\GitHub\universal.entropic.compression\src\universalentropiccompression\universal.entropic.compression\Files\teste.txt";
        }

        public enum EncodingTypes
        {
            [Description("Golomb")]
            Golomb = 0,
            [Description("Elias-Gamma")]
            EliasGamma = 1,
            [Description("Fibonacci")]
            Fibonacci = 2,
            [Description("Unária")]
            Unaria = 3,
            [Description("Delta")]
            Delta = 4
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
    }
}
