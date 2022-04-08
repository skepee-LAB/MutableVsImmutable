using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MutableImmutable
{
    class Program
    {
        static void Main(string[] args)
        {
            var words= File.ReadAllLines(@"D:\words.txt");

            Console.WriteLine($"The list contains {words.Length} words.");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            string result = ConcatenateWordsImmutable(words);

            stopwatch.Stop();
            Console.WriteLine($"Concatenation via Immutable type in {stopwatch.ElapsedMilliseconds} ms.");


            stopwatch.Start();
            result = ConcatenateWordsMutable(words);

            stopwatch.Stop();
            Console.WriteLine($"Concatenation via Mutable type in {stopwatch.ElapsedMilliseconds} ms.");
        }

        private static string ConcatenateWordsMutable(string[] words)
        {
            var resultMutable = new StringBuilder();

            foreach (string item in words)
            {
                resultMutable.Append(item).Append(",");
            }

            return resultMutable.ToString();
        }

        private static string ConcatenateWordsImmutable(string[] words)
        {
            string resultImmutable = string.Empty;

            foreach (string item in words)
            {
                resultImmutable += item + ",";
            }

            return resultImmutable;
        }
    }
}
