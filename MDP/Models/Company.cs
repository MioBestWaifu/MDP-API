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
        public string Role { get; set; }
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
            company.Id = reader.GetInt32("id");
            company.ShortName = reader.GetString("shortName");
            company.FullName = reader.GetString("fullName");
            company.FoundingDate = reader.GetDateTime("foundingDate");
            return company;
        }
    }
}
