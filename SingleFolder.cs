
using Newtonsoft.Json;

public class SingleFolder : Data{
   [JsonProperty(Order = 3)]
   public List<Data> Content {get; set;} = [];
   public SingleFolder(string name){
      Name = name.Split('\\').Last();
      DataType = "folder";
   }
   public SingleFolder(){}


public void  ProcessPath(string targetDirectory, List<string> extensions)
    {
        string[] fileEntries = Directory.GetFileSystemEntries(targetDirectory, "*", SearchOption.TopDirectoryOnly);
        foreach(string entry in fileEntries){
            SingleFolder folder = new SingleFolder(entry);
            if(Directory.Exists(entry)){
               Content.Add(folder);
            folder.ProcessPath(entry, extensions);
            }else if(File.Exists(entry)){
                SingleFile file = new SingleFile(entry);
                Content.Add(file);
                if(!extensions.Contains(file.Extension)){
                     extensions.Add(file.Extension);
                }
            }
        }

            
    }


    public override void PrintInfo(int depth)
    {
       foreach(Data item in Content){
         if(item is SingleFile){
            item.PrintInfo(depth);
         }else{
            for(int i = 0; i<depth; i++)
               Console.Write("   ");
            Console.Write("|---" + item.Name + '\n');
            item.PrintInfo(depth+1);
         }
       }
    }

    public override void ProcessJson(List<string> extensions)
    {
        foreach(Data item in Content){
            item.ProcessJson(extensions);
         }
       }
    }


