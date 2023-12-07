using Newtonsoft.Json;

public class SingleFile : Data{
    
    [JsonProperty(Order = 3)]
    public string Extension {get; set;} = string.Empty;

    public SingleFile(string fileName){
      string [] fullName = fileName.Split('\\').Last().Split('.');
      Name = string.Join("",fullName[..^1]);
      Extension = '.' + fullName.Last();
      DataType = "file";
   }
   public SingleFile(){}

    public override void PrintInfo(int depth)
    {
        for(int i = 0; i<depth; i++)
            Console.Write("   ");
         Console.WriteLine("|   " + Name + '.' + Extension);
    }

    public override void ProcessJson(List<string> extensions)
    {
        if(!extensions.Contains(Extension)){
            extensions.Add(Extension);
        }
    }
}