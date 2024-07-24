namespace MDP.Models.Pages
{
    using System.Collections.Generic;
    using MDP.Models.Companies;
    using MDP.Models.Persons;

    public class CompanyPageModel : BasePageModel
    {
        public Company Company { get; set; }
        public List<Person> Affiliates { get; set; } = new List<Person>();
    }
}
