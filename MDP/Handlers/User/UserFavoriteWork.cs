using MDP.Models.Works;

namespace MDP.Handlers.User
{
    public class UserFavoriteWork
    {
        public int UserId { get; set; }
        public Artifact Artifact { get; set; }
    }
}
