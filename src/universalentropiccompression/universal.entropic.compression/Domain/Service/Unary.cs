using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using universal.entropic.compression.Domain.Contracts.Services;

namespace universal.entropic.compression.Domain.Service
{
    public class Unary 
    {
		UnicodeEncoding unicode = new UnicodeEncoding();
		public List<string> ResultSymbol { get; set; }
        public Unary()
        {
            ResultSymbol = new List<string>();
        }

        public byte[] Encode(byte[] values)
        {
			var bools = new List<bool>();
			
			foreach (var value in values)
			{
				var valueByte = value;
				var count = 0;

				while (count < valueByte)
				{
					bools.Add(false);  
					count++;
				}
				bools.Add(true); 
			}

			var convertBoolsInBytes = new byte[(int)Math.Ceiling(bools.Count / 8d)];
			var bits = new BitArray(bools.ToArray());
			bits.CopyTo(convertBoolsInBytes, 0);

			return convertBoolsInBytes;
		}

        public byte[] Decode(byte[] File)
        {
            var bits = new BitArray(File);
            var bools = new bool[bits.Length];
            bits.CopyTo(bools, 0);

            var bytesToSave = new List<byte>();

            byte x = 0;

            foreach (var b in bools)
            {
                if (!b)
                    x++;
                else
                {
                    bytesToSave.Add(x);
                    x = 0;
                }
            }
            return bytesToSave.ToArray();
        }
	}
}
