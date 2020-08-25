using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using universal.entropic.compression.Domain.Contracts.Services;
using universal.entropic.compression.Utils;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression.Domain.Service
{
    public class Golomb : IBaseEncode
    {
        public int Divider { get; set; }
        public int Suffix { get; set; }
        public IEnumerable <int> Prefix { get; set; }
        public int StopBit { get; set; }
        public StringBuilder ResultSymbol { get; set; }

        public Golomb(int divider, int encoder, int parm) 
        {
            Divider = divider;
            Suffix = (int)Math.Log2(Divider);
            StopBit = 1;
            ResultSymbol = new StringBuilder();
            ResultSymbol.Append(encoder).Append(parm);            
        }


        public StringBuilder Encode(int symbol)
        {
            var remainder = new int();
            var quotient = Math.DivRem(symbol,Divider,out remainder);

            Prefix = Enumerable.Repeat(0, quotient).Append(StopBit);
            
            Prefix.ToList().ForEach(delegate (int x)
            {
                ResultSymbol.Append(x);
               
            });

            var K = Math.Pow(2, Suffix);


            if (remainder < K)
            {
                var binaryRemainder = Convert.ToString(remainder, toBase: Suffix);            
                
                
                if (binaryRemainder.Length < Suffix)
                {
                    var tratamento = Enumerable.Repeat(0, Suffix - 1);
                    tratamento.ToList().ForEach(delegate (int x) { ResultSymbol.Append(x); });
                    
                }

                ResultSymbol.Append(binaryRemainder);
            }
            else 
            {
                var binaryRemainder = Convert.ToString(remainder + (int)K, toBase: Suffix);
                //ResultSymbol.Append(Convert.ToString(remainder + (int)K, toBase: Suffix));
                if (binaryRemainder.Length < Suffix)
                {
                    var tratamentos = Enumerable.Repeat(0, Suffix + 1 - ResultSymbol.Length);
                    tratamentos.ToList().ForEach(delegate (int x) { ResultSymbol.Append(x); });
                }
            }

           return ResultSymbol;
        }

        public string Read(string Path)
        {
            var read = "97";
            return read;
            
        }
        public void Write(string Path)
        {
           
            throw new NotImplementedException();
        }

    }
}
