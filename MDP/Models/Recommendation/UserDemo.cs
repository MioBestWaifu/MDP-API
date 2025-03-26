using MDP.Models.Accessory;
using MDP.Models.Users;

namespace MDP.Models.Recommendation
{
    public class UserDemo
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Demographic Demographic { get; set; }
    }
}
