using BenchmarkDotNet.Attributes;
using System;

namespace Benchmarks
{
    [ClrJob, CoreJob]
    [MemoryDiagnoser, MarkdownExporter]
    public class EqualsIgnoreCaseVsToUpper
    {
        private string text1 = "Test";
        private string text2 = "tesT";

        [Benchmark]
        public bool EqualsOrdinalIgnoreCase()
        {
            return text1.Equals(text2, StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark]
        public bool EqualsInvariantCultureIgnoreCase()
        {
            return text1.Equals(text2, StringComparison.InvariantCultureIgnoreCase);
        }

        [Benchmark]
        public bool EqualsToUpper()
        {
            return text1.ToUpper().Equals(text2.ToUpper());
        }
    }
}
