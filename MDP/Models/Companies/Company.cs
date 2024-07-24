using MDP.Models.Works;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MDP.Models.Companies
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public Name ShortName { get; set; }
        [Required]
        public Name FullName { get; set; }
        public Image CardImgUrl { get; set; }
        public Image MainImgUrl { get; set; }
        public List<Image>? OtherImages { get; set; }
        //This is required while Person's is not because it does not make sense for a company yo be anonymous.
        //however, the Company model can be used for things other than actual enterprises, like musical groups.
        //But this seems like a stupid way to define those other things, so keeping this required because, someday,
        //Company will only be used for actual companies.
        [Required]
        public Country Country { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime FoundingDate { get; set; }
        public double AverageRating { get; set; }
        public List<Artifact> ParticipatedWorks { get; set; }
    }
}
