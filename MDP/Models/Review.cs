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

        public void SetUser(User user)
        {
            this.User = user;
        }

        /*
         * Essa porra pode dar problema pela forma de iteração do reader e interação com a base de dados. Os getallreviews trazem apenas os
         * ids dos usuários, então tem que estar coordenado pra não dar problema. Rever isso.
         */
        public void SetUser(MySqlDataReader reader)
        {
            reader.Read();
            this.User = User.FromQuery(reader);
        }
    }
}
