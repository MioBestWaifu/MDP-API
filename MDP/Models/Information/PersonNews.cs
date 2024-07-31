using MDP.Models.Works;
using System.ComponentModel.DataAnnotations;

namespace MDP.Models.Information
{
    public class PersonNews
    {
        public int Id { get; set; }
        [Required]
        public News News { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
