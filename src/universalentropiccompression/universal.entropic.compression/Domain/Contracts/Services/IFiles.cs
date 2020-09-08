using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Domain.Contracts.Services
{
    public interface IFiles
    {
       string ReadAllBytes(string path);
        void Write(string path, string value);
    }
}
