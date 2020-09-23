using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using universal.entropic.compression.Domain.Contracts.Services;
using universal.entropic.compression.Utils;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Domain.Service
{
    public class Golomb  
    {
        public int Divider { get; set; }
        public int Suffix { get; set; }
        public IEnumerable <int> Prefix { get; set; }
        public int StopBit { get; set; }
        public StringBuilder ResultSymbol { get; set; }
        List<string> resultBytes { get; set; }

        public Golomb(int divider, int encoder, int parm) 
        {
            Divider = divider;
            Suffix = (int)Math.Log2(Divider);
            StopBit = 1;
            resultBytes = new List<string>();
        }

        public byte[] Encoder(byte[] values)
        {

            foreach (byte value in values)
            {

                Encode(value);
            }

            return GetByteArray(resultBytes);
           
        }


        public List<string> Encode(int symbol)
        {
            var remainder = new int();
            var quotient = Math.DivRem(symbol, Divider, out remainder);

            Prefix = Enumerable.Repeat(0, quotient).Append(StopBit);

            Prefix.ToList().ForEach(delegate (int x)
            {
                resultBytes.Add(x.ToString());

            });

            var K = Math.Pow(2, Suffix);

            if (remainder < K)
            {
                var binaryRemainder = Convert.ToString(remainder, toBase: Suffix);


                if (binaryRemainder.Length < Suffix)
                {
                    var tratamento = Enumerable.Repeat(0, Suffix - 1);
                    tratamento.ToList().ForEach(delegate (int x) { resultBytes.Add(x.ToString()); });

                }

                resultBytes.Add(binaryRemainder);
            }
            else
            {
                var binaryRemainder = Convert.ToString(remainder + (int)K, toBase: Suffix);
                if (binaryRemainder.Length < Suffix)
                {
                    var tratamentos = Enumerable.Repeat(0, Suffix + 1 - ResultSymbol.Length);
                    tratamentos.ToList().ForEach(delegate (int x) { resultBytes.Add(x.ToString()); });
                }
            }

            return resultBytes;
        }

        public byte[] Decode(byte[] File)
        {
            var decodeString = new StringBuilder();
            var listStrings = new List<string>();
            var file = new StringBuilder();
            foreach (var item in File)
            {
                file.Append(item);
            }
                //var archive = file.Remove(0, 2);
                var q = new int();
                var stopBit = false;
                var b = (int)GolombParm.K;                
                var binaryValue = string.Empty;
                var suffix = (int)Math.Log2((int)GolombParm.K);
                var flagSuffix = (int)Math.Log2((int)GolombParm.K);

                foreach (var item in file.ToString())
                {
                   if(!stopBit && item == '0')
                   {
                        q += 1;
                        continue;
                   }
                   //StopBit
                   if (item == '1' && !stopBit)
                   {
                        stopBit = true;
                        continue;
                   }

                    if (stopBit && flagSuffix > 0) 
                    {
                        binaryValue += item;
                        flagSuffix -= 1;
                        continue;
                    }
                   
                   if (stopBit && flagSuffix == 0) 
                   {
                       if (binaryValue.Count() == suffix)
                       {
                           binaryValue = Convert.ToInt32(binaryValue, 2).ToString();
                           
                       }
                        var tmp = (q * b) + int.Parse(binaryValue);
                        listStrings.Add(tmp.ToString());                      
                        binaryValue = string.Empty;
                        flagSuffix = suffix;
                        stopBit = false;
                        q = 1;
                        tmp = 0;
                        continue;
                   }
                    
            }
            return GetByteArray(listStrings);
        }        
        public bool isValid(string File) 
        {
            if (isGolombEncodeFile(File[0]))
            {

                if (isValidKValue(File[1]))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("This file does not have a valid K value");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("This file was not encoded with the Golomb algorithm");
                return false;
            }

        }
        public bool isGolombEncodeFile(char value) 
        {
            if (value.ToInt() == (int)EncodingTypes.Golomb) 
            {
                return true;
            }
            return false;
        }

        public bool isValidKValue(char value) 
        {
            if (value.ToInt() == (int) GolombParm.K)
            {
                return true;
            }
            return false;
        }

        public byte[] GetByteArray(List<string> values) 
        {
            Byte[] buffer = new Byte[values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                buffer[i] = Convert.ToByte(values[i]);
            }
            return buffer;
        }


    }
}
