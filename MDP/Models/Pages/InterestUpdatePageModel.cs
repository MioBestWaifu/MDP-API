namespace MDP.Models.Pages
{
    public class PersonPageModel
    {
        public Dictionary<string, List<Interest>> InterestDictionary { get; set; } = new Dictionary<string, List<Interest>>()
            {
                { "Selected", new List<Interest>() },
                { "Unselected", new List<Interest>() }
            };
    }
}
