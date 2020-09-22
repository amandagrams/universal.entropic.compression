using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using universal.entropic.compression.Domain.Contracts.Services;
using System.Globalization;
using System.IO.Compression;

namespace universal.entropic.compression.Domain.Service
{
    public class Files : IFiles
    {
        public  byte[] ReadAllBytes(string path, bool EncodeDecode)
        {
            if (!File.Exists(path)) 
            {
                if (EncodeDecode)
                {
                    return File.ReadAllBytes(path);
                }
                else
                {
                    return ParseBytesd(File.ReadAllBytes(path));
                }
            }
            return null;                       
        }

        public void Write(string path, byte[] value, bool EncodeDecode, byte[] info)
        {

            if (!File.Exists(path))
            {
                if (EncodeDecode)
                {
                    File.WriteAllBytes(path,ParseBytesc(value,info));
                }
                else
                {
                     File.WriteAllBytes(path,value);
                }
            }
        }
        public byte[] ParseBytesc(byte[] data, byte[] info)
        {
            MemoryStream output = new MemoryStream();
            output.Write(info, 0, info.Length);
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(data, 0, data.Length);
            }

            return output.ToArray();
        }
        public byte[] ParseBytesd(byte[] datain)
        {
            var liste = new List<byte>(datain);
            liste.RemoveRange(0, 2);
            byte[] newstream = liste.ToArray();

            MemoryStream input = new MemoryStream(newstream);
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
            {
                dstream.CopyTo(output);
            }
            return output.ToArray();
        }

    }
}
