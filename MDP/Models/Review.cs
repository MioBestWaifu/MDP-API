using MDP.Models.Users;
using MDP.Models.Works;
using System.ComponentModel.DataAnnotations;

namespace MDP.Models
{
    //Turn this into multiple classes inheriting here, some with reference to Artifact,
    //Company, Person, etc. The EF will take care of keeping this neetly in the database.
    public class Review
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int ArtifactId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateOnly? Date { get; set; }
    }
}
