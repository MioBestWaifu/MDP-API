using MDP.Models.Accessory;

namespace MDP.Models.Companies
{
    public class CompanyInsert
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public Country Country { get; set; }
        public List<Role> Roles { get; set; }
        public string Description { get; set; }
        public DateOnly FoundingDate { get; set; }
    }
}
