// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers.ClrPrivate;
using System.Text;

var summary = BenchmarkRunner.Run<MemoryBenchmarkerDemo>();


[MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class MemoryBenchmarkerDemo
{
    string[] words = File.ReadAllLines(@"D:\words.txt");

    [Benchmark]
    public string ConcatStringsUsingMutableType()
    {
        var resultMutable = new StringBuilder();

        foreach (string item in words)
        {
            resultMutable.Append(item).Append(",");
        }

        return resultMutable.ToString();
    }
    [Benchmark]
    public string ConcatStringsUsingImmutableType()
    {
        string resultImmutable = string.Empty;

        foreach (string item in words)
        {
            resultImmutable += item + ",";
        }

        return resultImmutable;
    }
}