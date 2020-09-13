using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Contracts.Services;

namespace universal.entropic.compression.Domain.Service
{
    public class Delta 
    {
        public StringBuilder ResultSymbol { get; set; }
        public Delta(int encoder)
        {
            ResultSymbol = new StringBuilder();
            ResultSymbol.Append(encoder);
        }
        public StringBuilder Encode(byte[] buffer,int length)
        {
            byte last = 0;
            for (int i = 0; i < length; i++)
            {
                var current = buffer[i];
                buffer[i] = (byte)(current - last);
                last = current;
            }

            ResultSymbol.Append(last);
            return ResultSymbol;
        }
    }
}
