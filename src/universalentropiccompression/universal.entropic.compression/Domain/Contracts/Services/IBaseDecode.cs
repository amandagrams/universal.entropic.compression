using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Domain.Contracts.Services
{
    public interface IBaseDecode 
    {
        byte[] Decode(string File);
        

    }
}
