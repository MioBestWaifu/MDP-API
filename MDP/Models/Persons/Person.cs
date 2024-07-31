using MDP.Models.Companies;

namespace MDP.Models.Persons
{

    public class Person
    {
        public int Id { get; set; }
        public Name ShortName { get; set; }
        public Name FullName { get; set; }
        public List<Name>? Nicknames { get; set; }
        public Image CardImage { get; set; }
        public Image MainImage { get; set; }
        public List<Image>? OtherImages { get; set; }
        public Country? Country { get; set; }
        public List<Role> Roles { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public double AverageRating { get; set; }
        public Gender Gender { get; set; }
    }
}
