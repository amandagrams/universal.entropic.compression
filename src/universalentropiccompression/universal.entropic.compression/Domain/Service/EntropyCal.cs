using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace universal.entropic.compression.Domain.Service
{
    class EntropyCal
    {
        public double EntropyValue(string message)
        {
            Dictionary<char, int> K = message.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            double EntropyValue = 0;
            foreach (var character in K)
            {
                double PR = character.Value / (double)message.Length;
                EntropyValue -= PR * Math.Log(PR, 2);
            }
            return EntropyValue;
        }

        public double EntropyBits(string message)
        {
            Dictionary<char, int> K = message.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            double EntropyValue = 0;
            foreach (var character in K)
            {
                double PR = character.Value / (double)message.Length;
                EntropyValue -= PR * Math.Log(PR, 2);
            }
            return Math.Ceiling(EntropyValue) * message.Length;
        }
    }
}
