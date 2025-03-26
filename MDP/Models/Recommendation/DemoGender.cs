using MDP.Models.Accessory;

namespace MDP.Models.Recommendation
{
    public class DemoGender
    {
        public int Id { get; set; }
        public Demographic Demographic { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
    }
}
