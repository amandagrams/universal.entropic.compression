using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Domain.Contracts.Services;

namespace universal.entropic.compression.Domain.Service
{
    public class Delta 
    {
        public byte[] Encoder(byte[] file)
        {
            
            byte last = 0;
            byte original;
            int i;
            for (i = 0; i < file.Length; i++)
            {
                original = file[i];
                file[i] -= last;
                last = original;
            }

            byte[] shiftRight = new byte[file.Length + 2];
            for (i = 0; i < file.Length; i++)
            {
                shiftRight[(i + 2) % shiftRight.Length] = file[i];
            }

            shiftRight[0] = 4; 
            shiftRight[1] = 0;

            var result = shiftRight;

            return result;
        }

        public byte[] Decode(byte[] file)
        {
          
            byte[] arqBytes = file;
            byte[] decoded = new byte[file.Length - 2];  

            byte last = 0;
            int count = 0;
            for (int i = 2; i < file.Length; i++) 
            {
                file[i] += last;
                last = file[i];
                decoded[count++] = last;
            }

            return decoded;
        }
    }
}
