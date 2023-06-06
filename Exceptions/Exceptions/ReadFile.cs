using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    public class ReadFile
    {
        public string File { get; }

        public ReadFile(string file)
        {
            File = file;


            Console.WriteLine("Opening file: " + file);
        }

        public string ReadNextLine()
        {
            Console.WriteLine("Reading line. . .");

            return "Line of file";
        }

        public void Close()
        {
            Console.WriteLine("Closing file.");
        }
    }
}