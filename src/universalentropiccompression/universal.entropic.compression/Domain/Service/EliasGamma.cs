using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using universal.entropic.compression.Domain.Contracts.Services;

namespace universal.entropic.compression.Domain.Service
{
    public class EliasGamma
    {
        public List<string> ResultSymbol { get; set; }
        public EliasGamma()
        {
            ResultSymbol = new List<string>();

        }

        public byte[] Decode(byte[] File)
        {
            var fileContent = new List<string>();
            

            var bits = new BitArray(File);
            var values = new bool[bits.Length];
            bits.CopyTo(values, 0);

            int n = 0, i = 0;
            bool countUnary = true;
            var leftOverBinary = new StringBuilder();

            foreach (var val in values)
            {
                if (countUnary)
                {
                    if (val)
                        n++;
                    else
                        countUnary = false;

                    continue;
                }

                if (i <= n)
                {
                    leftOverBinary.Append(val ? "1" : "0");
                    i++;

                    if (i == n)
                    {
                        var leftOver = Convert.ToInt32(leftOverBinary.ToString(), 2);
                        var asc = (int)Math.Pow(2, n) + leftOver;
                        fileContent.Add(((char)asc).ToString());

                        i = 0;
                        n = 0;
                        countUnary = true;
                        leftOverBinary = new StringBuilder();
                    }

                }
            }

            return GetByteArray(fileContent);
        }



        public int DecodeEliasGamma(string s)
        {
            int len = getHeadZerosCount(s);

            if (len <= 0)
            {
                return 0;
            }
            s = s.Substring(len);

            String binary = s.Substring(0, len + 1);

            int n = binaryStringToInt(binary);

            return n;
        }

        private List<string> DecimalList(List<string> list) 
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = ConvertBinaryToDecimal(list[i]);
            }
            return list;
        }
        private  string ConvertBinaryToDecimal(string a)
        {
            double str = 0;
            char[] arr = a.ToCharArray();
            int i = arr.Length - 1;
            foreach (char c in arr)
            {
                str = str + Math.Pow(2, i) * Convert.ToDouble(c.ToString());
                i--;
            }
            return str.ToString();
        }

        public byte[] Encoder(byte[] values)
        {
            var bools = new List<bool>();

            foreach (var value in values)
            {
                int pow = (int)(Math.Log(value) / Math.Log(2));
                var biggestPow = (int)Math.Pow(2, pow);

                var codeword = new StringBuilder();

                for (int i = 0; i < pow; i++)
                    bools.Add(false);     

                bools.Add(true);

                var leftOver = value - biggestPow;
               

                var binaryString = Convert.ToString(leftOver, 2).PadLeft(pow, '0');
                foreach (var bit in binaryString)
                    bools.Add(bit == '1');               
            }

            var bytes = new byte[(int)Math.Ceiling(bools.Count / 8d)];

            var bits = new BitArray(bools.ToArray());
            bits.CopyTo(bytes, 0);           

            var byteList = bytes.ToList();
            byteList.Insert(0, 1);
            byteList.Insert(1, 0);

           return byteList.ToArray();

        }

        public String intToBinaryString(int n)
        {
            String s = "";
            while (n > 0)
            {
                if ((n & 1) == 0)
                {
                    s = "0" + s;
                }
                else
                {
                    s = "1" + s;
                }
                n = n >> 1;
            }
            return s;
        }
        public String addHeadZeros(String s)
        {
            int n = s.Count();
            String s1 = s;
            for (int i = 0; i < n - 1; i++)
            {
                s1 = "0" + s1;
            }
            return s1;

        }

        public int getHeadZerosCount(String s)
        {
            char zero = '0';
            char um = '1';
            int n = 0;
            foreach (char c in s)
            {
                if (c == zero)
                {
                    n++;
                }
                else if (c == um)
                {
                    return n;
                }
            }
            return n;
        }
        public int binaryStringToInt(String binary)
        {
            return Convert.ToInt32(binary, 2);

        }
        public byte[] GetByteArray(List<string> values)
        {            
            Byte[] buffer = new Byte[values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                buffer[i] = Convert.ToByte(Convert.ToInt16(values[i]));
            }
            return buffer;
        }
        private static byte ConvertBoolArrayToByte(bool[] source)
        {
            byte result = 0;
           
            int index = 8 - source.Length;

           
            foreach (bool b in source)
            {
               
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }

        private static bool[] ConvertByteToBoolArray(byte b)
        {
           
            bool[] result = new bool[8];

           
            for (int i = 0; i < 8; i++)
                result[i] = (b & (1 << i)) == 0 ? false : true;

            
            Array.Reverse(result);

            return result;
        }

        public void Decoder(byte[] bytes)
        {           

            using (FileStream fileStream = File.Create(Utils.Utils.FilesDecoded.EliasGammaDecodeAlice))
            {
                var fileContent = new StringBuilder();
                bytes = bytes.Skip(2).ToArray();

                var bits = new BitArray(bytes);
                var bools = new bool[bits.Length];
                bits.CopyTo(bools, 0);

                int n = 0, i = 0;
                bool countUnary = true;
                var leftOverBinary = new StringBuilder();

                foreach (var b in bools)
                {
                    //var byteChar = Convert.ToChar(b);
                    if (countUnary)
                    {
                        if (!b)
                            n++;
                        else
                            countUnary = false;

                        continue;
                    }

                    if (i <= n)
                    {
                        leftOverBinary.Append(b ? "1" : "0");
                        i++;

                        if (i == n)
                        {
                            var leftOver = Convert.ToInt32(leftOverBinary.ToString(), 2);
                            var asc = (int)Math.Pow(2, n) + leftOver;
                            fileContent.Append(((char)asc).ToString());

                            i = 0;
                            n = 0;
                            countUnary = true;
                            leftOverBinary = new StringBuilder();
                        }
                    }
                }

                var contentBytes = Encoding.ASCII.GetBytes(fileContent.ToString());
                var readOnlySpan = new ReadOnlySpan<byte>(contentBytes);

                fileStream.Write(readOnlySpan);
            }
        }
    }
}

