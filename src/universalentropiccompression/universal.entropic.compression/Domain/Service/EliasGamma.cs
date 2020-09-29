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

            //Elias Gamma Information
            var byteList = bytes.ToList();
            byteList.Insert(0, 1);
            byteList.Insert(1, 0);

           return byteList.ToArray();

        }

        public void Decoder(byte[] bytes, string path)
        {

            using (FileStream fileStream = File.Create(path))
            {
                var fileContent = new StringBuilder();
                //skip 2 bytes about file encode
                bytes = bytes.Skip(2).ToArray();

                var bits = new BitArray(bytes);
                var bools = new bool[bits.Length];
                bits.CopyTo(bools, 0);

                int n = 0, i = 0;
                bool countUnary = true;
                var leftOverBinary = new StringBuilder();

                foreach (var b in bools)
                {

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

