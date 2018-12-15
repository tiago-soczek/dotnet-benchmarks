using BenchmarkDotNet.Running;
using Benchmarks;

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<EqualsIgnoreCaseVsToUpper>();
        }
    }
}
