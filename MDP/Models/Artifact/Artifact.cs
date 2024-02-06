namespace MDP.Models.Artifacts
{
    using System;
    using System.Collections.Generic;

    public class Artifact
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<string> OtherNames { get; set; }
        public string Description { get; set; }
        public string Media { get; set; }
        public List<string> Categories { get; set; }
        public List<string> TargetDemographics { get; set; }
        public string AgeRating { get; set; }
        public string CardImgUrl { get; set; }
        public string MainImgUrl { get; set; }
        public List<string> OtherImgUrls { get; set; }
        public string MainParticipantRole { get; set; }
        public string MainParticipant { get; set; }
        public double AverageRating { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
