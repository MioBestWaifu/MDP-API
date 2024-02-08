namespace MDP.Models
{
    using MySql.Data.MySqlClient;
    using System;

    public class Review : IQueryable<Review>
    {
        public User User { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }

        /// <summary>
        /// Cria uma review com rating, comment e date. Não cria um user.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Review FromQuery(MySqlDataReader reader)
        {
            Review review = new Review();
            try
            {
                review.Rating = reader.GetInt32("rating");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'rating' column: {ex.Message}");
            }
            try
            {
                review.Comment = reader.GetString("comment");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'comment' column: {ex.Message}");
            }
            try
            {
                review.Date = reader.GetDateTime("date");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving 'date' column: {ex.Message}");
            }
            return review;
        }
    }
}
