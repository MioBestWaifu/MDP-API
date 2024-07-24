using System.ComponentModel.DataAnnotations;

namespace MDP.Models.Information
{
    public class News
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public List<Image> Images { get; set; }
        public DateTime Date { get; set; }
    }
}
