namespace MDP.Models
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;

    public class User : IQueryable<User>
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Name Nickname { get; set; }
        public Image CardImageUrl { get; set; }
        public Image MainImageUrl { get; set; }
        public List<Image>? OtherImageUrls { get; set; }
        public Country? Country { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }

        public void RemoveSensitiveInformation()
        {
            this.Email = null;
            this.Password = null;
        }
    }
}
