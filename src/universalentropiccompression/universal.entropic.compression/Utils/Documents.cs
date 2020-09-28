using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using universal.entropic.compression.Domain.Contracts.Services;
using System.Globalization;
using System.IO.Compression;

namespace universal.entropic.compression.Domain.Service
{
    public  class Documents : IDocuments
    {
        public  byte[] ReadAllBytes(string path, bool EncodeDecode)
        {
          
                if (EncodeDecode)
                {
                    return File.ReadAllBytes(path);
                }
                else
                {
                    var result = ParseBytesd2(File.ReadAllBytes(path));
                    return result;
                }
                              
        }

        public void WriteByte(string path, byte[] value, bool EncodeDecode, byte[] info)
        {

           
                if (EncodeDecode)
                {
                    var teste = ParseBytesc2(value, info);
                    File.WriteAllBytes(path, teste);
                }
                else
                {
                     File.WriteAllBytes(path,value);
                }
           
        }

        public void WriteText(string path, string  value)
        {

                File.WriteAllText(path, value);
           
        }
        public string ReadText(string path)
        {

            return File.ReadAllText(path);

        }

        public class Information 
        {
            public static byte[] Golomb = new byte[2] { Convert.ToByte(0), Convert.ToByte(4) };
            public static byte[] EliasGamma = new byte[2] { Convert.ToByte(1), Convert.ToByte(0)};
            public static byte[] Fibonacci = new byte[2] { Convert.ToByte(2), Convert.ToByte(0)};
            public static byte[] Unary = new byte[2] { Convert.ToByte(3), Convert.ToByte(0)};
            public static byte[] Delta = new byte[2] { Convert.ToByte(4), Convert.ToByte(0)};
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

        public byte[] ParseBytesc2(byte[] data, byte[] info)
        {
            MemoryStream output = new MemoryStream();
            output.Write(info, 0, info.Length);
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(data, 0, data.Length);
            }

            return output.ToArray();
        }
        public byte[] ParseBytesd2(byte[] datain)
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
