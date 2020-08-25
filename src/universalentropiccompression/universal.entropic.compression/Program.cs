using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using universal.entropic.compression.Domain.Service;
using universal.entropic.compression.Utils;
using static universal.entropic.compression.Utils.Utils;

namespace universal.entropic.compression
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World Golomb!!!");

            //var golomb = new Golomb((int)GolombParm.K, (int)EncodingTypes.Golomb, (int)GolombParm.K);

            //create a buffer to output data
            //StringBuilder stringBuffer = new StringBuilder();
            //set the encoder
            //stringBuffer.Append((int)EncodingTypes.Golomb);
            //set the K of Golomb
            //stringBuffer.Append((int)GolombParm.K);

           

            //read file
           // var file = golomb.Read("");
            //golomb.Encode(6);

            Console.WriteLine(new Golomb((int)GolombParm.K, (int)EncodingTypes.Golomb, (int)GolombParm.K).Encode(3).ToString());
            Console.WriteLine(new Golomb((int)GolombParm.K, (int)EncodingTypes.Golomb, (int)GolombParm.K).Encode(6).ToString());
            Console.WriteLine(new Golomb((int)GolombParm.K, (int)EncodingTypes.Golomb, (int)GolombParm.K).Encode(17).ToString());
            Console.WriteLine(new Golomb((int)GolombParm.K, (int)EncodingTypes.Golomb, (int)GolombParm.K).Encode(97).ToString());

            //read a bit
            //foreach (char c in file)
            //{
            //    Console.WriteLine(c);

            //    //var x = c.ToAscii();
            //    //encode a bit


            //}

            //Console.WriteLine(stringBuffer);




            //return a bit
            //save encode bit to buffer

        }
    }
}
