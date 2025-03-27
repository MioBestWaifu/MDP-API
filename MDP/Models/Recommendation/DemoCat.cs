using MDP.Models.Accessory;

namespace MDP.Models.Recommendation
{
    public class DemoCat
    {
        public int Id { get; set; }
        public Demographic Demographic { get; set; }
        public Category Category { get; set; }
        public double Weight { get; set; }
    }
}
