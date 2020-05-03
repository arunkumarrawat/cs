using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SharpCompress.Archive;
using SharpCompress.Archive.Zip;
using SharpCompress.Common;

namespace zip
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("zip [compress folder] [destination file path]");
                Console.WriteLine("unzip [destination file path] [compress folder]");
                return;
            }

            using (var archive = ZipArchive.Create())
            {
                archive.AddAllFromDirectory(args[0]);
                archive.SaveTo(args[1], CompressionType.LZMA);
            }
        }
    }
}
