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
        public List<string> ResultSymbol { get; set; }
        public Unary()
        {
            ResultSymbol = new List<string>();
        }

        public byte[] Encode(byte[] values)
        {
            var bools = new List<bool>();

            foreach (var c in values)
            {

                for (int i = 0; i < c; i++)
                {
                    bools.Add(false);

                }
                bools.Add(true);
            }

            BitArray bits = new BitArray(bools.ToArray());
            byte[] bytes = new byte[bits.Length / 8 + (bits.Length % 8 == 0 ? 0 : 1)];
            bits.CopyTo(bytes, 0);

            return bytes;
		}

        public byte[] Decode(byte[] File)
        {
            var bits = new BitArray(File);
            var bools = new bool[bits.Length];
            bits.CopyTo(bools, 0);

            var bytesToSave = new List<byte>();

            byte n = 0;

            foreach (var b in bools)
            {
                if (!b)
                    n++;
                else
                {
                    bytesToSave.Add(n);
                    n = 0;
                }
            }
            return bytesToSave.ToArray();
        }
	}
}
