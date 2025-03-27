using MDP.Models.Accessory;

namespace MDP.Models.Persons
{
    public class PersonInsert
    {
        //Images go elsewhere
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<string>? Nicknames { get; set; }
        public Country Country { get; set; }
        public List<Role> Roles { get; set; }
        public string Description { get; set; }
        public DateOnly? Birthday { get; set; }
        public Gender Gender { get; set; }
    }
}
