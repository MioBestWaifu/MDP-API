using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;

namespace MDP.Models.Accessory
{
    public class Accessory 
    {
        public int Id { get; set; }
        [ValidateNever]
        public string Name { get; set; }
        //Could have used AccessoryType as the discriminator on this thing. 
    }
}
