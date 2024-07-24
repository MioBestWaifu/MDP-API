namespace MDP.Models
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;

    public class Company : IQueryable<Company>
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string CardImgUrl { get; set; }
        public string MainImgUrl { get; set; }
        public List<string> OtherImgUrls { get; set; } = new List<string>();
        public string Country { get; set; }
        public List<string> Roles { get; set; }
        public DateTime FoundingDate { get; set; }
        public double AverageRating { get; set; }

        /// <summary>
        /// Cria uma Company com id, shortName, fullName e foundingDate.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Company FromQuery(MySqlDataReader reader)
        {
            Company company = new Company();
            try
            {
                company.Id = reader.GetInt32("id");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'id' column: {ex.Message}");
            }
            try
            {
                company.ShortName = reader.GetString("shortName");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'shortName' column: {ex.Message}");
            }
            try
            {
                company.FullName = reader.GetString("fullName");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'fullName' column: {ex.Message}");
            }
            try
            {
                company.FoundingDate = reader.GetDateTime("foundingDate");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'foundingDate' column: {ex.Message}");
            }
            return company;
        }

        public void SetImageUrls(MySqlDataReader reader)
        {
            try
            {
                this.OtherImgUrls = new List<string>();
                while (reader.Read())
                {
                    try
                    {
                        switch (reader.GetInt32("type"))
                        {
                            case (int)ImageType.CardImage:
                                this.CardImgUrl = reader.GetString("url");
                                break;
                            case (int)ImageType.MainImage:
                                this.MainImgUrl = reader.GetString("url");
                                break;
                            case (int)ImageType.OtherImage:
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving image urls: {ex.Message}");
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

        public void SetRoles(MySqlDataReader reader)
        {
            this.Roles = new List<string>();
            while (reader.Read())
            {
                try
                {
                    Roles.Add(reader.GetString("name"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        /// <summary>
        /// Passar reader sem chamar Read(). Espera uma coluna chamada average.
        /// </summary>
        /// <param name="reader"></param>
        public void SetAverageRating (MySqlDataReader reader)
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
