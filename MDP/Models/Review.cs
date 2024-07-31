using MDP.Models.Users;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.DataAnnotations;

namespace MDP.Models
{
    //Turn this into multiple classes inheriting here, some with reference to Artifact,
    //Company, Person, etc. The EF will take care of keeping this neetly in the database.
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime? Date { get; set; }
    }
}
