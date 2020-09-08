using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using universal.entropic.compression.Domain.Contracts.Services;

namespace universal.entropic.compression.Domain.Service
{
    public class EliasGamma : IBaseEncode
    {
        public StringBuilder ResultSymbol { get; set; }
        public EliasGamma(int encoder)
        {
            ResultSymbol = new StringBuilder();
            ResultSymbol.Append(encoder);
        }

        public byte[] Decode(string File)
        {
            //Remove bits controle
            var file = File.Remove(0, 1);
            var stopBit = false;
            var countZeros = 1;
            var binary = new  StringBuilder();
            var listStrings = new List<string>();

            foreach (var item in file)
            {
                if (!stopBit && item == '0')
                {
                    countZeros += 1;
                    continue;
                }
                if (!stopBit && item == '1')
                {
                    stopBit = true;
                    binary.Append(item.ToString());
                    continue;
                }
                if (stopBit && countZeros != 1)
                {
                    binary.Append(item);
                    countZeros--;
                    if (stopBit && countZeros == 1)
                    {
                        var tmp = int.Parse(binary.ToString());
                        listStrings.Add(tmp.ToString());
                        stopBit = false;
                        countZeros = 1;
                        binary.Clear();
                        continue;
                    }
                    continue;
                }
                
                
            }
            return GetByteArray(DecimalList(listStrings));
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

        public StringBuilder Encode(int encodeValue)
        {
            var s = intToBinaryString(encodeValue);
            s = addHeadZeros(s);
            ResultSymbol.Append(s);
            return ResultSymbol;

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
    }
}
