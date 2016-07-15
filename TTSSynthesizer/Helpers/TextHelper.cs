using System;
using System.IO;
using System.Text;

namespace TTSSynthesizer
{
    public static class TextHelper
    {
        public static String LoadTextFile(String path)
        {
            return File.ReadAllText(path, Encoding.Default);
        }
    }
}