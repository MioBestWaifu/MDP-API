namespace MDP.Models.Works
{
    public class ArtifactReview
    {
        public int Id { get; set; }
        public Review Review { get; set; }
        public Artifact Artifact { get; set; }
    }
}
