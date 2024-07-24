namespace MDP.Models.Works
{
    using MDP.Models.Accessory;
    using MDP.Models.Companies;
    using MDP.Models.Persons;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artifact
    {
        public int Id { get; set; }
        [Required]
        public Name ShortName { get; set; }
        [Required]
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
        [Required]
        public Role MainParticipantRole { get; set; }
        public Person? MainParticipant { get; set; }
        public List<PersonParticipation>? ParticipantPersons { get; set; }
        public List<CompanyParticipation>? ParticipantCompanies { get; set; }
        public double AverageRating { get; set; }
        public DateTime? ReleaseDate { get; set; }

    }
}
