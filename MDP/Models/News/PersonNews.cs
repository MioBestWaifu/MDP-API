using MDP.Models.Artifacts;
using System.ComponentModel.DataAnnotations;

namespace MDP.Models.News
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
