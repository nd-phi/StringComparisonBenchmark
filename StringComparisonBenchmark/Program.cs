// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;

Console.WriteLine("Hello, World!");
var benchamrk = new BenchmarkDemo();

var _ = BenchmarkRunner.Run<BenchmarkDemo>();

Console.WriteLine("EqualsOperator1: {0}", benchamrk.EqualsOperator1());
Console.WriteLine("EqualsOperator2: {0}", benchamrk.EqualsOperator2());
Console.WriteLine("StringEquals1: {0}", benchamrk.StringEquals1());
Console.WriteLine("StringEquals2: {0}", benchamrk.StringEquals2());
Console.WriteLine("StringEqualsIgnoreCase1: {0}", benchamrk.StringEqualsIgnoreCase1());
Console.WriteLine("StringEqualsIgnoreCase2: {0}", benchamrk.StringEqualsIgnoreCase2());

[MemoryDiagnoser]
public class BenchmarkDemo
{
    private string String1 = "ABCD";
    private string String2 = "ABCD";
    private string String3 = "abCD";

    [Benchmark]
    public bool EqualsOperator1()
    {
        return String1 == "ABCD";
    }

    [Benchmark]
    public bool EqualsOperator2()
    {
        return String1 == "abCD";
    }

    [Benchmark]
    public bool StringEquals1()
    {
        return String1.Equals("ABCD");
    }

    [Benchmark]
    public bool StringEquals2()
    {
        return String1.Equals("abCD");
    }

    [Benchmark]
    public bool StringEqualsIgnoreCase1()
    {
        return String1.Equals(String2, StringComparison.OrdinalIgnoreCase);
    }

    [Benchmark]
    public bool StringEqualsIgnoreCase2()
    {
        return String1.Equals(String3, StringComparison.OrdinalIgnoreCase);
    }
}
