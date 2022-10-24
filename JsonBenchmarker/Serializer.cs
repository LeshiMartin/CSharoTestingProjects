using BenchmarkDotNet.Attributes;
using JsonBenchmarker.RootObjectDir;
using Newtonsoft.Json;

namespace JsonBenchmarker;

[MemoryDiagnoser(true)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Serializer
{

    private readonly string _formVersionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FormVersionSerializerTest.json");
    private readonly string _rootObjectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SerializerTest.json");

    [Benchmark(Baseline = true)]
    public FormVersion? PlainJsonDeserialize()
    {
        var str = File.ReadAllText(_formVersionPath);
        return JsonConvert.DeserializeObject<FormVersion>(str);
    }

    [Benchmark]
    public FormVersion? JsonDeserializeFromStream()
    {
        using var str = new FileStream(_formVersionPath, FileMode.Open, FileAccess.Read);
        using var reader = new StreamReader(str);
        using JsonReader jsonReader = new JsonTextReader(reader);
        var serializer = new JsonSerializer();
        return serializer.Deserialize<FormVersion>(jsonReader);
    }

    [Benchmark]
    public Rootobject? PlainRootObjectJsonDeserialize()
    {
        var str = File.ReadAllText(_rootObjectPath);
        return JsonConvert.DeserializeObject<Rootobject?>(str);
    }

    [Benchmark]
    public Rootobject? JsonDeserializeRootObjectFromStream()
    {
        using var str = new FileStream(_rootObjectPath, FileMode.Open, FileAccess.Read);
        using var reader = new StreamReader(str);
        using JsonReader jsonReader = new JsonTextReader(reader);
        var serializer = new JsonSerializer();
        return serializer.Deserialize<Rootobject>(jsonReader);
    }

    [Benchmark]
    public FormVersion? JsonDeserializeJsonNet()
    {
        var str = File.ReadAllText(_formVersionPath);
        return System.Text.Json.JsonSerializer.Deserialize<FormVersion>(str);
    }

    [Benchmark]
    public Rootobject? JsonDeserializeRootObjectJsonNet()
    {
        var str = File.ReadAllText(_rootObjectPath);
        return System.Text.Json.JsonSerializer.Deserialize<Rootobject>(str);
    }


    [Benchmark]
    public Rootobject? JsonDeserializeRootObjectJsonNetFromStream()
    {
        using var str = new FileStream(_rootObjectPath, FileMode.Open, FileAccess.Read);
        return System.Text.Json.JsonSerializer.Deserialize<Rootobject>(str);
    }
}