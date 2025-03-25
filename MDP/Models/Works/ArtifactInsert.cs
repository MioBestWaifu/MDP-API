using MDP.Models.Accessory;

namespace MDP.Models.Works
{
    public class ArtifactInsert
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public List<string>? OtherNames { get; set; } = [];
        public string? Description { get; set; }
        public Media Media { get; set; }
        public List<Category> Categories { get; set; }
        public List<Demographic> TargetDemographics { get; set; }
        public AgeRating AgeRating { get; set; }
        public DateOnly? ReleaseDate { get; set; }
    }
}
