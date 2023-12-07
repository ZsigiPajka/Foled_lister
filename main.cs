

public class MainLister
{
    public static void Main(string[] args)
    {
        while(true){
            Console.WriteLine("Please provide a folder or a json with folder information: ");
            string path = Console.ReadLine()!.Trim();
            if(path.Equals("exit"))break;
            FileProcessor processor  = new(path);
            bool result;
            if(path.Split('.').Last() == "json"){
               result = processor.FromJson();
            }else{
                result = processor.ProcessPath();
            }
            if(!result){
                Console.WriteLine("Error reading from path.");
                continue;
            }
            processor.ListExtensions();
            processor.ListDir();
            Console.WriteLine("\nSave to JSON ?");
            string answer = Console.ReadLine()!.Trim();
            bool answered = false;
            while(!answered){
                if(answer.Equals("y") || answer.Equals("yes")){
                    Console.WriteLine("Please provide the JSON file location:");
                    string json = Console.ReadLine()!.Trim();
                    if(json.Split('.').Last() != "json"){
                        Console.WriteLine("File path must end with .json");
                        continue;
                    }
                    processor.toJson(json);
                    answered = true;
                }
                if(answer.Equals("n") || answer.Equals("no")){
                    answered = true;
                }
            }
        }
    }

    
}