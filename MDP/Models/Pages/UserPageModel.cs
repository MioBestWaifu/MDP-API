namespace MDP.Models.Pages
{
    public class UserPageModel
    {
        public User User { get; set; }

        public List<Review> Interactions { get; set; } = [];
    }
}
