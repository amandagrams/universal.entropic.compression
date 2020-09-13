using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using universal.entropic.compression.Domain.Contracts.Services;

namespace universal.entropic.compression.Domain.Service
{
    public class Fibonacci : IBaseEncode
    {

        // To limit on the largest Fibonacci number to be used
        public static int Limit = 30;
        public List<int> FibonacciNumbers { get; set; }
        public StringBuilder ResultSymbol { get; set; }

        public Fibonacci(int encoder)
        {
            FibonacciNumbers = CreateList<int>(Limit);
            ResultSymbol = new StringBuilder();
            ResultSymbol.Append(encoder);

        }

        public StringBuilder Encode(int encodeValue)
        {

            var index = largestFiboLessOrEqual(encodeValue);

            var codeWord = new char[index+2];

            var i = index;

            while (encodeValue != 0) 
            {
                codeWord[i] = '1';
                encodeValue = encodeValue - FibonacciNumbers[i];
                i = i - 1;

                while (i >= 0 && FibonacciNumbers[i] > encodeValue)
                {
                    codeWord[i] = '0';
                    i = i - 1;
                }
            }

            //additional '1' bit 
            codeWord[index + 1] = '1';
            

            //return pointer to codeword 
            var codeWords = new String(codeWord);
            return ResultSymbol.Append(codeWords);
        }

        public byte[] Decode(string File)
        {
            //Remove bits controle
            var file = File.Remove(0, 1);

            var listFibonacciNumbers = GenerateFibonacciNumbersToDecode();

            var tmpResult = new List<int>();
            var result = new List<string>();

            var count = 0;
            var stopBit = false;
            var oldCode = new char();
            foreach (var code in file) 
            {
                if (code == '0') 
                {
                    count++;
                    oldCode = code;
                    continue;
                }
                    
                if (code == '1' && oldCode != code)
                {
                    tmpResult.Add(listFibonacciNumbers[count]);                   
                }

                if (oldCode == code && code == '1')
                {
                    result.Add(tmpResult.ToList().Sum().ToString());
                    tmpResult.Clear();
                    oldCode = '0';
                    count = 0;
                    continue;
                }
               
                count++;
                oldCode = code;

            }            

            return GetByteArray(result);
        }

        public int largestFiboLessOrEqual(int n) 
        {
            FibonacciNumbers[0] = 1;  // Fib[0] stores 2nd Fibonacci No. 
            FibonacciNumbers[1] = 2;  // Fib[1] stores 3rd Fibonacci No. 

            // Keep Generating remaining numbers while previously 
            // generated number is smaller 
            int i;
            for (i = 2; FibonacciNumbers[i - 1] <= n; i++)
                FibonacciNumbers[i] = FibonacciNumbers[i - 1] + FibonacciNumbers[i - 2];

            // Return index of the largest fibonacci number 
            // smaller than or equal to n. Note that the above 
            // loop stopped when fib[i-1] became larger. 
            return (i - 2);
        }

        private static List<T> CreateList<T>(int capacity)
        {
            return Enumerable.Repeat(default(T), capacity).ToList();
        }

        public byte[] GetByteArray(List<string> values)
        {
            Byte[] buffer = new Byte[values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                buffer[i] = Convert.ToByte(Convert.ToInt16(values[i]));
            }
            return buffer;
        }

        public static int getFibonacciNumbers(int n)
        {
            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
        public List<int> GenerateFibonacciNumbersToDecode() 
        {
            var f = new List<int>();
            for (int i = 0; i < Limit; i++)
            {
                f.Add(getFibonacciNumbers(i));
            }
            f.Remove(0);
            f.Remove(1);
            return f;
        }
    }
}
