using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Domain.Contracts.Services
{
    public interface IDocuments
    {
       byte[] ReadAllBytes(string path, bool EncodeDecode);
      
        void WriteByte(string path, byte[] value, bool EncodeDecode, byte[] info);
        void WriteText(string path, string value);


    }
}
