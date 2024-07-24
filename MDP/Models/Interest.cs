using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MDP.Models
{

    public class Interest 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<string> TargetDemographics { get; set; } = new List<string>();
        public bool Selected { get; set; } = false;

    }
}
