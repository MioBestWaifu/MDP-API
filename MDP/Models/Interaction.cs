namespace MDP.Models
{
    using System;

    public class Interaction
    {
        public User User { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
        public DateTime? DateInteractionMade { get; set; }
    }
}
