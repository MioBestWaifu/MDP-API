using System.ComponentModel.DataAnnotations;

namespace MDP.Models.Information
{
    public class CompanyNews
    {
        public int Id { get; set; }
        [Required]
        public News News { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
