using Newtonsoft.Json;

public abstract class Data{
    [JsonProperty(Order = 1)]
    public string Name{get; set;} = string.Empty;
    [JsonProperty(Order = 2)]
    public string DataType { get; set; } = string.Empty;
    public abstract void PrintInfo(int depth);

    public abstract void ProcessJson(List<string> extensions );
}