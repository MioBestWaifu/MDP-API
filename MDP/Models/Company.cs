namespace MDP.Models
{
    using System;
    using System.Collections.Generic;

    public class Company
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string CardImgUrl { get; set; }
        public string MainImgUrl { get; set; }
        public List<string> OtherImgUrls { get; set; } = new List<string>();
        public string Country { get; set; }
        public string Role { get; set; }
        public DateTime FoundingDate { get; set; }
        public double AverageRating { get; set; }
    }
}
