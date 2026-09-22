using System.Text;
using BenchmarkDotNet.Attributes;

namespace AcademyScheduleAnalyzer.Benchmarks;

[MemoryDiagnoser]
public class StringBenchmark
{
    private const string Text = "Academy Schedule Analyzer";

    [Params(100, 1000, 10000, 100000)]
    public int Iterations;

    [Benchmark(Baseline = true)]
    public string StringConcatenation()
    {
        string result = string.Empty;

        for (int index = 0; index < Iterations; index++)
        {
            result += Text;
        }

        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder result = new StringBuilder();

        for (int index = 0; index < Iterations; index++)
        {
            result.Append(Text);
        }

        return result.ToString();
    }
}
