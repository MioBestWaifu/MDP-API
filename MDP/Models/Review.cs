namespace MDP.Models
{
    using System;

    public class Review
    {
        public User User { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }
    }
}
