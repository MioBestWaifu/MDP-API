namespace MDP.Models
{
    public interface IEntity
    {
        public int Id { get; set; }
        public Name ShortName { get; set; }
        public Name FullName { get; set; }
        public Image CardImage { get; set; }
        public Image MainImage { get; set; }

    }
}
