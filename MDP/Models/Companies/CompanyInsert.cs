namespace MDP.Models.Companies
{
    public class CompanyInsert
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public int Country { get; set; }
        public List<int> Roles { get; set; }
        public string Description { get; set; }
        public DateTime FoundingDate { get; set; }
    }
}
