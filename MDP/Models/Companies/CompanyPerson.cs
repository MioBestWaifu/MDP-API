using MDP.Models.Persons;

namespace MDP.Models.Companies
{
    public class CompanyPerson
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public Person Person { get; set; }
        public DateTime Start { get; set; }
        //The To of current participants is null
        public DateTime? End { get; set; }
    }
}
