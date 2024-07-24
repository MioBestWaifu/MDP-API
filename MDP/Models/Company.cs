namespace MDP.Models
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;

    public class Company
    {
        public int Id { get; set; }
        public Name ShortName { get; set; }
        public Name FullName { get; set; }
        public Image CardImgUrl { get; set; }
        public Image MainImgUrl { get; set; }
        public List<Image>? OtherImages { get; set; }
        public Country Country { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime FoundingDate { get; set; }
        public double AverageRating { get; set; }
}
