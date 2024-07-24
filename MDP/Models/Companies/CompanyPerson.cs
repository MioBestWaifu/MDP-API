namespace MDP.Models.Companies
{
    public class CompanyPerson
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public Person Person { get; set; }
        public DateTime From { get; set; }
        //The To of current participants is null
        public DateTime To { get; set; }
    }
}
