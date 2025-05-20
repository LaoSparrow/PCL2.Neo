using System.Text.Json;

namespace PCL.Neo.Core.Models.Config;


public abstract class JsonConfigBase<T> where T : JsonConfigBase<T>
{
    public void SaveTo(string path) => File.WriteAllText(path,
        JsonSerializer.Serialize((object)this, new JsonSerializerOptions { WriteIndented = true }));
    public static T? LoadFrom(string path) => JsonSerializer.Deserialize<T>(File.ReadAllText(path));
}