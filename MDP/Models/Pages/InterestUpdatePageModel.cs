﻿namespace MDP.Models.Pages
{
    public class InterestUpdatePageModel
    {
        public Dictionary<string, List<Interest>> InterestDictionary { get; set; } = new Dictionary<string, List<Interest>>()
            {
                { "Selected", new List<Interest>() },
                { "Unselected", new List<Interest>() }
            };
    }
}
