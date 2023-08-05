using System.Text.Json;

namespace JsonFile
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            string path = @"C:\Test\Serialized.json";

            Serializing(path);

            Deserializing(path);

        }

        public static void Serializing(string file)
        {
            Users user1 = new Users(1, "Eduardo");
            Users user2 = new Users(2, "Another user");

            string json1 = JsonSerializer.Serialize(user1);
            string json2 = JsonSerializer.Serialize(user2);

            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine(json1);
            writer.WriteLine(json2);
            writer.Close();
        }

        public static void Deserializing(string file)
        {
            StreamReader reader = new StreamReader(file);
            string text_line;

            var list = new List<Users>();

            while ((text_line = reader.ReadLine()) != null)
            {
                Users? users = JsonSerializer.Deserialize<Users>(text_line);
                list.Add(new Users(users.Id, users.Name));

            }

            UserQuery(list);
        }

        public static void UserQuery(List<Users> list)
        {
            //Manual LINQ
            //var query = from user in list
            //            where user.Name == "Luiz"
            //            select user;

            //LINQ with lambda
            var query = list.Where(user => user.Name.Equals("Eduardo"));

            foreach (var item in query)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }

        }
    }

}
