using MDP.Models.Accessory;
using MDP.Models.Companies;
using MDP.Models.Persons;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MDP.Models.Works
{
    public class Artifact : IEntity
    {
        public int Id { get; set; }
        public Name ShortName { get; set; }
        public Name FullName { get; set; }
        public List<Name>? OtherNames { get; set; }
        public string? Description { get; set; }
        [Required]
        public Media Media { get; set; }
        [Required]
        public List<Category> Categories { get; set; }
        public List<Demographic>? TargetDemographics { get; set; }
        public AgeRating AgeRating { get; set; }
        public Image CardImage { get; set; }
        public Image MainImage { get; set; }
        public List<Image>? OtherImages { get; set; }
        public double AverageRating { get; set; }
        public DateTime? ReleaseDate { get; set; }

    }
}
