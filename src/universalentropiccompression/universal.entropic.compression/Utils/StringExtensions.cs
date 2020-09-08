using System;
using System.Collections.Generic;
using System.Text;

namespace universal.entropic.compression.Utils
{
    public static class StringExtensions
    {
        public static string ToBinary(this string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string ToBinary(this char data)
        {
            return Convert.ToString(data, 2).PadLeft(8, '0');

        }

        public static int ToInt(this char data)
        {
            return int.Parse(data.ToString()); 
        }


        
    }
}
