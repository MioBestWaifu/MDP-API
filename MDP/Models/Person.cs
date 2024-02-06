namespace MDP.Models
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<string> Nicknames { get; set; }
        public string CardImgUrl { get; set; }
        public string MainImgUrl { get; set; }
        public List<string> OtherImgUrls { get; set; }
        public string Country { get; set; }
        public List<string> Roles { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public double AverageRating { get; set; }
        public string Gender { get; set; }
    }
}
