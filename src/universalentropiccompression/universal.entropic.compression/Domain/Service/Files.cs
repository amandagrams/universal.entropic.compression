using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using universal.entropic.compression.Domain.Contracts.Services;
using System.Globalization;

namespace universal.entropic.compression.Domain.Service
{
    public class Files : IFiles
    {
        public  string ReadAllBytes(string path)
        {
            string readText =  File.ReadAllText(path);
            return readText;
        }

        public void Write(string path, string value)
        {
            if (!File.Exists(path))
            {
                string createText = value + Environment.NewLine;
                File.WriteAllText(path, createText);
            }

        }
    }
}
