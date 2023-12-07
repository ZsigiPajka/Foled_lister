using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JsonFolderConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(Data));
    }



    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);
        if (jo["DataType"]!.Value<string>() == "file")
            return jo.ToObject<SingleFile>(serializer);

        if (jo["DataType"]!.Value<string>() == "folder")
            return jo.ToObject<SingleFolder>(serializer);

        return null;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override bool CanWrite
    {
        get { return false; }
    }


}