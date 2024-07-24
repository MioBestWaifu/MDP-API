using MDP.Models.Works;

namespace MDP.Models.Users
{
    public class UserFavoriteWork
    {
        public int UserId { get; set; }
        public Artifact Artifact { get; set; }
    }
}
