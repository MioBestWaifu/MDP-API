using MDP.Models.Works;

namespace MDP.Models.Users
{
    public class UserFavoriteWork
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Artifact Artifact { get; set; }
    }
}
