using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Domain.Contracts.Services
{
    public interface IFile
    {
        string Read(string Path);
        void Write(string Path);
    }
}
