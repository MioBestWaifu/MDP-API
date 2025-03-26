using MDP.Models.Accessory;

namespace MDP.Models.Recommendation
{
    public class DemoAge
    {
        public int Id { get; set; }
        public Demographic Demographic { get; set; }
        public int RangeStart { get; set; }
        public int RangeEnd { get; set; }
        public double Weight { get; set; }
    }
}
