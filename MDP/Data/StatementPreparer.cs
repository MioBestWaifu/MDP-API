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

        public static MySqlCommand GetWorkById (int work)
        {
            MySqlCommand com = new MySqlCommand(Statements.getWorkById);
            com.Parameters.AddWithValue("@work", work);
            return com;
        }

        public static MySqlCommand GetWorkCategoriesByWorkId (int work)
        {
            MySqlCommand com = new MySqlCommand(Statements.getWorkCategoriesByWorkId);
            com.Parameters.AddWithValue("@work", work);
            return com;
        }

        public static MySqlCommand GetWorkOtherNames (int work)
        {
            MySqlCommand com = new MySqlCommand(Statements.getWorkOtherNames);
            com.Parameters.AddWithValue("@work", work);
            return com;
        }


        public static MySqlCommand GetWorkDemographics (int work)
        {
            MySqlCommand com = new MySqlCommand(Statements.getWorkDemographics);
            com.Parameters.AddWithValue("@work", work);
            return com;
        }

        public static MySqlCommand GetAllWorkImages (int work)
        {
            MySqlCommand com = new MySqlCommand(Statements.getAllWorkImages);
            com.Parameters.AddWithValue("@work", work);
            return com;
        }

        public static MySqlCommand GetRecentWorkReviews (int work, int limit)
        {
            MySqlCommand com = new MySqlCommand(Statements.getRecentWorkReviews);
            com.Parameters.AddWithValue("@work", work);
            com.Parameters.AddWithValue("@limit", limit);
            return com;
        }

        public static MySqlCommand GetAllWorkReviews (int work)
        {
            MySqlCommand com = new MySqlCommand(Statements.getAllWorkReviews);
            com.Parameters.AddWithValue("@work", work);
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
    }
}
