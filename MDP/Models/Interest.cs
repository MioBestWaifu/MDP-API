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
            interest.Link.MainLabel = reader.GetString("name");
            interest.Link.ImgUrl = reader.GetString("url");
            interest.Description = reader.GetString("description");
            return interest;
        }
    }
}
