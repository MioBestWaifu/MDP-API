﻿namespace MDP.Models
{
    using System.Collections.Generic;

    public class Interest
    {
        public Link Link { get; set; }
        public string Description { get; set; }
        public List<string> TargetDemographics { get; set; } = new List<string>();
        public bool Selected { get; set; } = false;
    }
}
