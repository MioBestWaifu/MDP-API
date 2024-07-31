using MDP.Models.Accessory;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MDP.Models
{

    public class Interest 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Demographic> TargetDemographics { get; set; } = new List<Demographic>();
        public bool Selected { get; set; } = false;

    }
}
