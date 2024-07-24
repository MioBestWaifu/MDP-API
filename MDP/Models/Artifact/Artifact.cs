namespace MDP.Models.Artifacts
{
    using MDP.Models.Accessory;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;

    public class Artifact 
    {
        public int Id { get; set; }
        public Name ShortName { get; set; }
        public Name Name { get; set; }
        public List<Name>? OtherNames { get; set; }
        public string Description { get; set; }
        public Accessory Media { get; set; }
        public List<Accessory> Categories { get; set; }
        public List<Accessory>? TargetDemographics { get; set; }
        public Accessory AgeRating { get; set; }
        public Image CardImage { get; set; }
        public Image MainImage { get; set; }
        public List<Image>? OtherImages { get; set; }
        public Role MainParticipantRole { get; set; }
        public Person? MainParticipant { get; set; }
        public double AverageRating { get; set; }
        public DateTime? ReleaseDate { get; set; }

    }
}
