using MDP.Models.Works;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MDP.Models.Companies
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public Name ShortName { get; set; }
        public Name FullName { get; set; }
        public string Description { get; set; }
        public Image CardImage { get; set; }
        public Image MainImage { get; set; }
        public List<Image>? OtherImages { get; set; }
        //This is required while Person's is not because it does not make sense for a company to be anonymous.
        //however, the Company model can be used for things other than actual enterprises, like musical groups.
        //But this seems like a stupid way to define those other things, so keeping this required because, someday,
        //Company will only be used for actual companies.
        public Country Country { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime FoundingDate { get; set; }
        public double AverageRating { get; set; }
    }
}
