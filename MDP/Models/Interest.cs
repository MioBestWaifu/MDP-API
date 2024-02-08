namespace MDP.Models
{
    using MySql.Data.MySqlClient;
    using System.Collections.Generic;

    public class Interest : IQueryable<Interest>
    {
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

            return interest;
        }
    }
}
