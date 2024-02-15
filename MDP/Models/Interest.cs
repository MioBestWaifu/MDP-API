namespace MDP.Models
{
    using MySql.Data.MySqlClient;
    using System.Collections.Generic;

    public class Interest : IQueryable<Interest>
    {
        public int Id { get; set; }
        public Link Link { get; set; }
        public string Description { get; set; }
        public List<string> TargetDemographics { get; set; } = new List<string>();
        public bool Selected { get; set; } = false;

        /// <summary>
        /// Cria um Interest com link,link.MainLabel, link.ImgUrl e description.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Interest FromQuery(MySqlDataReader reader)
        {
            Interest interest = new Interest();
            interest.Link = new Link();
            try
            {
                interest.Id = reader.GetInt32("id");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'Id' not found: {ex.Message}");
            }
            try
            {
                interest.Link.MainLabel = reader.GetString("name");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'name' not found: {ex.Message}");
            }

            try
            {
                interest.Link.ImgUrl = reader.GetString("url");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'url' not found: {ex.Message}");
            }

            try
            {
                interest.Description = reader.GetString("description");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'description' not found: {ex.Message}");
            }

            try
            {
                interest.Selected = reader.GetBoolean("selectes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'selected' not found: {ex.Message}");
            }

            return interest;
        }

        /// <summary>
        /// Cria o targetDemographics e o popula. Passar o reader direto da query, sem chamar Read().
        /// </summary>
        /// <param name="reader"></param>
        public void SetDemographics(MySqlDataReader reader)
        {
            this.TargetDemographics = new List<string>();
            while (reader.Read())
            {
                try
                {
                    this.TargetDemographics.Add(reader.GetString("name"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving 'name' column: {ex.Message}");
                }
            }
        }
    }
}
