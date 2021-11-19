using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Running;
//https://www.infoworld.com/article/3573782/how-to-benchmark-csharp-code-using-benchmarkdotnet.html

namespace StringBenchmark
{
    class Program
    {
        static void Main(string[] args) {
            BenchmarkRunner.Run<BenchmarkStringConcatenation>();
            Console.ReadKey();
        }
    }
    [RankColumn]
    [MemoryDiagnoser]
    public class BenchmarkStringConcatenation
    {
        [Benchmark]
        public void StringCatenation() {
            string myString = string.Empty;
            for (int i = 0; i < 1000; i++) {
                myString += "Hello";
            }
        }
        [Benchmark]
        public void StringBuilder() {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < 1000; i++) {
                stringBuilder.Append("Hello");
            }

            var targetString = stringBuilder.ToString();
        }
    }
}
