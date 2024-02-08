using MySql.Data.MySqlClient;

namespace MDP.Data
{
    public class StatementPreparer
    {
        public static MySqlCommand GetCountry(int id)
        {
            MySqlCommand com = new MySqlCommand(Statements.getCountry);
            com.Parameters.AddWithValue("@id", id);
            return com;
        }

        public static MySqlCommand GetDemographics(int id)
        {
            MySqlCommand com = new MySqlCommand(Statements.getDemographics);
            com.Parameters.AddWithValue("@id", id);
            return com;
        }

        public static MySqlCommand GetCategory (int id)
        {
            MySqlCommand com = new MySqlCommand(Statements.getCategory);
            com.Parameters.AddWithValue("@id", id);
            return com;
        }


        public static MySqlCommand GetAgeRating (int id)
        {
            MySqlCommand com = new MySqlCommand(Statements.getAgeRating);
            com.Parameters.AddWithValue("@id", id);
            return com;
        }

        public static MySqlCommand GetImageType (int id)
        {
            MySqlCommand com = new MySqlCommand(Statements.getImageType);
            com.Parameters.AddWithValue("@id", id);
            return com;
        }

        public static MySqlCommand GetMedia (int id)
        {
            MySqlCommand com = new MySqlCommand(Statements.getMedia);
            com.Parameters.AddWithValue("@id", id);
            return com;
        }

        public static MySqlCommand GetRole (int id)
        {
            MySqlCommand com = new MySqlCommand(Statements.getRole);
            com.Parameters.AddWithValue("@id", id);
            return com;
        }

        public static MySqlCommand
        {

        }

        public static MySqlCommand
        {

        }


        public static MySqlCommand
        {

        }


        public static MySqlCommand
        {

        }


        public static MySqlCommand
        {

        }


        public static MySqlCommand
        {

        }


        public static MySqlCommand
        {

        }


        public static MySqlCommand
        {

        }


        public static MySqlCommand
        {

        }


        public static MySqlCommand
        {

        }


        public static MySqlCommand
        {

        }
    }
}
