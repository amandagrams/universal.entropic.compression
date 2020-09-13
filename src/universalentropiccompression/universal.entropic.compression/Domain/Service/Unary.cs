using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Contracts.Services;

namespace universal.entropic.compression.Domain.Service
{
    public class Unary : IBaseEncode, IBaseDecode
    {
        public StringBuilder ResultSymbol { get; set; }
        public Unary(int encoder)
        {
            ResultSymbol = new StringBuilder();
            ResultSymbol.Append(encoder);
        }
       
        public StringBuilder Encode(int encodeValue)
        {

            for (int i = 0; i < encodeValue; i++) 
            {
                ResultSymbol.Append('1');
            }

            ResultSymbol.Append('0');

            return ResultSymbol;
        }

        public byte[] Decode(string File)
        {
            var file = File.Remove(0, 1);
            var countOne = 0;
            var tmpResult = new List<string>();

            foreach (var c in file) 
            {
                if (c == '1') 
                {
                    countOne++;
                }
                if (c == '0') 
                {
                    tmpResult.Add(countOne.ToString());
                    countOne = 0;
                }
            }

            return GetByteArray(tmpResult);
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
