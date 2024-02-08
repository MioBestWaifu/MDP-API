namespace MDP.Models
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;

    public class Person : IQueryable<Person>
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<string> Nicknames { get; set; }
        public string CardImgUrl { get; set; }
        public string MainImgUrl { get; set; }
        public List<string> OtherImgUrls { get; set; }
        public string Country { get; set; }
        public List<string> Roles { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public double AverageRating { get; set; }
        public string Gender { get; set; }

        /// <summary>
        /// Cria uma Person com id, shortName, fullName, nicknames, birthday e description.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Person FromQuery(MySqlDataReader reader)
        {
            Person person = new Person();
            person.Id = reader.GetInt32("id");
            person.ShortName = reader.GetString("shortName");
            person.FullName = reader.GetString("fullName");
            person.Nicknames = reader.GetString("nicknames").Split(',').ToList();
            person.Birthday = reader.GetDateTime("birthday");
            person.Description = reader.GetString("description");

            return person;
        }
    }
}
