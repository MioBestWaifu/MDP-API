using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;

namespace MDP.Models.Accessory
{
    public abstract class Accessory 
    {
        public int Id { get; set; }
        public Name Name { get; set; }
    }
}
