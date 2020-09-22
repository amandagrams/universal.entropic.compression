using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Domain.Contracts.Services
{
    public interface IFiles
    {
       byte[] ReadAllBytes(string path, bool EncodeDecode);
       void Write(string path, byte[] value, bool EncodeDecode, byte[] info);
    }
}
