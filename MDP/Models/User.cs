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
            try
            {
                user.Id = reader.GetInt32("id");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'id' column: {ex.Message}");
            }
            try
            {
                user.Email = reader.GetString("email");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'email' column: {ex.Message}");
            }
            try
            {
                user.Password = reader.GetString("password");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'password' column: {ex.Message}");
            }
            try
            {
                user.Nickname = reader.GetString("nickname");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'nickname' column: {ex.Message}");
            }
            try
            {
                user.Description = reader.GetString("description");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'description' column: {ex.Message}");
            }
            try
            {
                user.Birthday = reader.GetDateTime("birthday");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'birthday' column: {ex.Message}");
            }
            try
            {
                user.Gender = reader.GetString("gender");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'gender' column: {ex.Message}");
            }
            return user;
        }

        public void SetImgUrls(MySqlDataReader reader)
        {
            this.OtherImgUrls = new List<string>();
            while (reader.Read())
            {
                switch (reader.GetInt32("type"))
                {
                    case (int)ImageTypes.CardImage:
                        this.CardImgUrl = reader.GetString("url");
                        break;
                    case (int)ImageTypes.MainImage:
                        this.MainImgUrl = reader.GetString("url");
                        break;
                    case (int)ImageTypes.OtherImage:
                        this.OtherImgUrls.Add(reader.GetString("url"));
                        break;
                }
            }
        }

        /// <summary>
        /// Passar o reader direto da query, sem chamar Read()
        /// </summary>
        /// <param name="reader"></param>
        public void SetCountry(MySqlDataReader reader)
        {
            reader.Read();
            this.Country = reader.GetString("name");
        }

        public void RemoveSensitiveInformation()
        {
            this.Email = null;
            this.Password = null;
        }
    }
}
