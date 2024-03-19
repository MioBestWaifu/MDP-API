using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;

namespace MDP.Models.Accessory
{
    public class Accessory 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public static Accessory FromQuery(MySqlDataReader reader)
        {
            Accessory toReturn = new Accessory();
            toReturn.Name = reader.GetString("name");
            toReturn.Id = reader.GetInt32("id");
            return toReturn;
        } 
    }
}
