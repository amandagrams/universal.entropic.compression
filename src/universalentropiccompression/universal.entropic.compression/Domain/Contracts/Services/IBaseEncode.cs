using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Domain.Contracts.Services
{
    public interface IBaseEncode 
    {
        StringBuilder Encode(int encodeValue);
    }
}
