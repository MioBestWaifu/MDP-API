using MySql.Data.MySqlClient;

namespace MDP.Models
{
    public class Link
    {
        public string ImgUrl { get; set; }
        public string MainLabel { get; set; }
        public string SecondaryLabel { get; set; }
        public string RedirectTo { get; set; }

        public static Link FromLinkablePerson(MySqlDataReader reader)
        {
            Link toReturn = new Link();
            toReturn.ImgUrl = reader.GetString("url");
            toReturn.MainLabel = reader.GetString("name");
            toReturn.SecondaryLabel = reader.GetString("role");
            toReturn.RedirectTo = "/person/" + reader.GetInt32("id");
            return toReturn;
        }

        public static Link FromLinkableAffiliation(MySqlDataReader reader)
        {
            Link toReturn = new Link();
            toReturn.ImgUrl = reader.GetString("url");
            toReturn.MainLabel = reader.GetString("name");
            toReturn.RedirectTo = "/person/" + reader.GetInt32("id");
            return toReturn;
        }

        public static Link FromLinkableCompany(MySqlDataReader reader)
        {
            Link toReturn = new Link();
            toReturn.ImgUrl = reader.GetString("url");
            toReturn.MainLabel = reader.GetString("name");
            toReturn.SecondaryLabel = reader.GetString("role");
            toReturn.RedirectTo = "/company/" + reader.GetInt32("id");
            return toReturn;
        }
    }
}
