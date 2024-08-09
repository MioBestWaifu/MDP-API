using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDP.Models.Users
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Name ShortName { get; set; }
        public Image? CardImage { get; set; }
        public Image? MainImage { get; set; }
        public List<Image>? OtherImages { get; set; }
        public Country? Country { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        //Required by the interface, but should never be used.
        [NotMapped]
        public Name FullName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void RemoveSensitiveInformation()
        {
            Email = null;
            Password = null;
        }
    }
}
