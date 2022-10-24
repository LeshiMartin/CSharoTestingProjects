using BenchmarkDotNet.Attributes;

namespace BoxingBenchmarks;
[MemoryDiagnoser]
public class Benchmarks
{

    [Benchmark]
    public bool WithPrimitiveValue()
    {
        var value = true;
        return value;
    }

    [Benchmark]
    public bool WithoutPrimitiveValue()
    {
        IsBoolean value = true;
        return value;
    }

}


internal struct IsBoolean
{
    private readonly bool _value;
    public IsBoolean(bool value)
    {
        _value = value;
    }

    public static implicit operator IsBoolean(bool val) => new IsBoolean(val);
    public static implicit operator bool(IsBoolean boolean) => boolean._value;
}
