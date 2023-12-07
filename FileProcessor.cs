
using Newtonsoft.Json;


class FileProcessor{
    private  List<string> _extensions = [];
    private string _path;
    private SingleFolder _root = new();

    public FileProcessor(string path){
        _path = path;
    }


    public bool FromJson(){
        try{
            var json = System.IO.File.ReadAllText(_path);
            JsonConverter[] converters = { new JsonFolderConverter()};
            _root= JsonConvert.DeserializeObject<SingleFolder>(json, new JsonSerializerSettings() { Converters = converters })!;
            _root.ProcessJson(_extensions);
            return true;
        } catch ( Exception){
            Console.WriteLine("Error reading JSON. ");
            return false;
        }

    }

    public void toJson(string json){
            string jsonString = JsonConvert.SerializeObject(_root, Formatting.Indented);
            File.WriteAllText(json, jsonString);
    }

    public bool ProcessPath(){
         if(File.Exists(_path))
            {
               Console.WriteLine("{0} is a file, not a directory.", _path);
               return false;
            }
            else if(Directory.Exists(_path))
            {
                _root = new SingleFolder(_path);
                _root.ProcessPath(_path, _extensions);
                return true;
    
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", _path);
                return false;
            }
    }

    public void ListDir(){
         Console.WriteLine();            
        _root.PrintInfo(0);
    }

    public void ListExtensions(){
        Console.Write("\nExtensions found in folder: ");
        string last = _extensions.Last(); 
                _extensions.ForEach((item => 
                {
                    if(item.Equals(last)){
                        Console.Write(item);
                    }else{
                        Console.Write(item + ", ");
                    }
                }
                ));
    }
}
