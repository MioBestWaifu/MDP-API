using MDP.Models.Users;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel.DataAnnotations;

namespace MDP.Models
{

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
