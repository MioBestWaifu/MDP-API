using System.ComponentModel.DataAnnotations;

namespace MDP.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(3, MinimumLength = 3)]
        public string Code { get; set; }
    }
}
