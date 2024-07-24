namespace MDP.Models.Artifacts
{
    using MDP.Models.Accessory;
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
        public Accessory Media { get; set; }
        [Required]
        public List<Accessory> Categories { get; set; }
        public List<Accessory>? TargetDemographics { get; set; }
        public Accessory AgeRating { get; set; }
        public Image CardImage { get; set; }
        public Image MainImage { get; set; }
        public List<Image>? OtherImages { get; set; }
        [Required]
        public Role MainParticipantRole { get; set; }
        public Person? MainParticipant { get; set; }
        public List<Person>? ParticipantPersons { get; set; }
        public List<Company>? ParticipantCompanies { get; set; }
        public double AverageRating { get; set; }
        public DateTime? ReleaseDate { get; set; }

    }
}
