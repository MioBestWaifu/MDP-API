namespace MDP.Models
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;

    public class User : IQueryable<User>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string CardImgUrl { get; set; }
        public string MainImgUrl { get; set; }
        public List<string> OtherImgUrls { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }

        /// <summary>
        /// Cria um user com id, email, password, nickname, description e birthday.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static User FromQuery(MySqlDataReader reader)
        {
            User user = new User();
            user.Id = reader.GetInt32("id");
            user.Email = reader.GetString("email");
            user.Password = reader.GetString("password");
            user.Nickname = reader.GetString("nickname");
            user.Description = reader.GetString("description");
            user.Birthday = reader.GetDateTime("birthday");
            return user;
        }
    }
}
