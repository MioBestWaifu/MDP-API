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
            try
            {
                toReturn.ImgUrl = reader.GetString("url");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'url' not found: {ex.Message}");
            }
            try
            {
                toReturn.MainLabel = reader.GetString("name");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'name' not found: {ex.Message}");
            }
            try
            {
                toReturn.SecondaryLabel = reader.GetString("role");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'role' not found: {ex.Message}");
            }
            try
            {
                toReturn.RedirectTo = "/person/" + reader.GetInt32("person");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'person' not found: {ex.Message}");
            }
            return toReturn;
        }

        public static Link FromLinkableWork(MySqlDataReader reader)
        {
            Link toReturn = new Link();
            try
            {
                toReturn.ImgUrl = reader.GetString("url");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'url' not found: {ex.Message}");
            }
            try
            {
                toReturn.MainLabel = reader.GetString("name");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'name' not found: {ex.Message}");
            }
            try
            {
                toReturn.SecondaryLabel = reader.GetString("role");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'role' not found: {ex.Message}");
            }
            try
            {
                toReturn.RedirectTo = "/work/" + reader.GetInt32("work");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'work' not found: {ex.Message}");
            }
            return toReturn;
        }

        public static Link FromLinkableAffiliation(MySqlDataReader reader)
        {
            Link toReturn = new Link();
            try
            {
                toReturn.ImgUrl = reader.GetString("url");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'url' not found: {ex.Message}");
            }
            try
            {
                toReturn.MainLabel = reader.GetString("name");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'name' not found: {ex.Message}");
            }
            try
            {
                toReturn.RedirectTo = "/person/" + reader.GetInt32("person");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'person' not found: {ex.Message}");
            }
            return toReturn;
        }

        public static Link FromLinkableCompany(MySqlDataReader reader)
        {
            Link toReturn = new Link();
            try
            {
                toReturn.ImgUrl = reader.GetString("url");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'url' not found: {ex.Message}");
            }
            try
            {
                toReturn.MainLabel = reader.GetString("name");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'name' not found: {ex.Message}");
            }
            try
            {
                toReturn.SecondaryLabel = reader.GetString("role");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'role' not found: {ex.Message}");
            }
            try
            {
                toReturn.RedirectTo = "/company/" + reader.GetInt32("company");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'company' not found: {ex.Message}");
            }
            return toReturn;
        }

        public static Link FromLinkableNews(MySqlDataReader reader)
        {
            Link toReturn = new Link();
            try
            {
                toReturn.ImgUrl = reader.GetString("url");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'url' not found: {ex.Message}");
            }
            try
            {
                toReturn.MainLabel = reader.GetString("title");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'title' not found: {ex.Message}");
            }
            try
            {
                toReturn.SecondaryLabel = reader.GetString("text");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'text' not found: {ex.Message}");
            }
            try
            {
                toReturn.RedirectTo = "/news/" + reader.GetInt32("id");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Column 'id' not found: {ex.Message}");
            }
            return toReturn;
        }
    }
}
