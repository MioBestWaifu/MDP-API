using MDP.Models.Works;
using System.ComponentModel.DataAnnotations;

namespace MDP.Models.Information
{
    public class WorkNews
    {
        public int Id { get; set; }
        [Required]
        public News News { get; set; }
        [Required]
        public int ArtifactId { get; set; }
    }
}
