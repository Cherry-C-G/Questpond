using System;
using System.IO;
namespace ReadingAndWritingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(@"d:\data.txt", "Hello world");
            string content = File.ReadAllText(@"d:\data.txt");
            Console.WriteLine(content);
        }
    }
}
