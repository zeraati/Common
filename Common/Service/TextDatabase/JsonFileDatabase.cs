namespace Common.Service.TextDatabase;
public class JsonFileDatabase<TData>(string fileName)
{
    public List<TData> Data = [];
    private readonly string _fileName = fileName + ".json";

    public async Task Save()
    {
        var data = Data.ToJson(nullIgnore: true);
        await File.WriteAllTextAsync(_fileName, data);
    }
    public async Task Add(TData data)
    {
        Data.Add(data);
        await Save();
    }

    public async Task Read()
    {
        if (!File.Exists(_fileName)) return;

        var jsonData = await File.ReadAllTextAsync(_fileName);
        if (!string.IsNullOrEmpty(jsonData))
        {
            Data = Util.Json.Deserialize<List<TData>>(jsonData)!;
        }
    }
}