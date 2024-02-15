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
            try
            {
                person.Id = reader.GetInt32("id");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'id' column: {ex.Message}");
            }

            try
            {
                person.ShortName = reader.GetString("shortName");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'shortName' column: {ex.Message}");
            }

            try
            {
                person.FullName = reader.GetString("fullName");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'fullName' column: {ex.Message}");
            }

            try
            {
                person.Nicknames = reader.GetString("nicknames").Split(',').ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'nicknames' column: {ex.Message}");
            }

            try
            {
                person.Birthday = reader.GetDateTime("birthday");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'birthday' column: {ex.Message}");
            }

            try
            {
                person.Description = reader.GetString("description");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'description' column: {ex.Message}");
            }

            try
            {
                person.Gender = reader.GetString("gender");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'gender' column: {ex.Message}");
            }

            return person;
        }

        public void SetImageUrls(MySqlDataReader reader)
        {
            this.OtherImgUrls = new List<string>();
            while (reader.Read())
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        /// <summary>
        /// Passar o reader direto da query, sem chamar Read()
        /// </summary>
        /// <param name="reader"></param>
        public void SetCountry(MySqlDataReader reader)
        {
            try
            {
                reader.Read();
                this.Country = reader.GetString("name");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'name' column: {ex.Message}");
            }
        }

        /// <summary>
        /// Passar o reader sem chamar Read()
        /// </summary>
        /// <param name="reader"></param>
        public void SetRoles(MySqlDataReader reader)
        {
            this.Roles = new List<string>();
            while (reader.Read())
            {
                try
                {
                    this.Roles.Add(reader.GetString("name"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving 'name' column: {ex.Message}");
                }
            }
        }
        /// <summary>
        /// Passar reader sem chamar Read(). Espera uma coluna chamada average.
        /// </summary>
        /// <param name="reader"></param>
        public void SetAverageRating(MySqlDataReader reader)
        {
            try
            {
                reader.Read();
                this.AverageRating = reader.GetDouble("average");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'average' column: {ex.Message}");
            }
        }
    }
}
