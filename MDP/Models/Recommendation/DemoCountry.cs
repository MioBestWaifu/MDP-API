using MDP.Models.Accessory;

namespace MDP.Models.Recommendation
{
    public class DemoCountry
    {
        public int Id { get; set; }
        public Demographic Demographic { get; set; }
        public Country Country { get; set; }
        public double Weight { get; set; }
    }
}
