using PCL.Neo.Core.Models.Config;
using System.Text.Json.Serialization;

namespace PCL.Neo.Tests.Core.Models.Config;

public class TestConfig : JsonConfigBase<TestConfig>
{
    public string Test1 { get; set; } = "value1";
    [JsonPropertyName("rename_test2")] public string Test2 { get; set; } = "value2";
}

public class JsonConfigBaseTest
{
    [Test]
    public void SaveTest()
    {
        new TestConfig().SaveTo("./test1.json");
    }

    [Test]
    public void SaveLoadTest()
    {
        var a = new TestConfig { Test2 = "dummy" };
        a.SaveTo("./test2.json");
        var b = TestConfig.LoadFrom("./test2.json");
        Assert.That(b, Is.Not.Null);
        Assert.That(b.Test1, Is.EqualTo(a.Test1));
        Assert.That(b.Test2, Is.EqualTo(a.Test2)); ;
    }
}