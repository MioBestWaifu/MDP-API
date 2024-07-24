namespace MDP.Models
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public int Id { get; set; }
        public Name ShortName { get; set; }
        public Name FullName { get; set; }
        public List<Name>? Nicknames { get; set; }
        public Image CardImageUrl { get; set; }
        public Image MainImageUrl { get; set; }
        public List<Image>? OtherImageUrls { get; set; }
        public Country? Country { get; set; }
        public List<Role> Roles { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public double AverageRating { get; set; }
        public Gender Gender { get; set; }
    }
}
