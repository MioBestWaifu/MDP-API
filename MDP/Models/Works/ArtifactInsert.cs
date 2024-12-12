using MDP.Models.Accessory;

namespace MDP.Models.Works
{
    public class ArtifactInsert
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public List<string>? OtherNames { get; set; } = [];
        public string? Description { get; set; }
        public int Media { get; set; }
        public List<int> Categories { get; set; }
        public List<int>? TargetDemographics { get; set; }
        public int AgeRating { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
