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

        public static MySqlCommand GetWorkMedia (int work)
        {
            MySqlCommand com = new MySqlCommand(Statements.getWorkMedia);
            com.Parameters.AddWithValue("@work", work);
            return com;
        }

        public static MySqlCommand GetWorkMainParticipantRole (int work)
        {
            MySqlCommand com = new MySqlCommand(Statements.getWorkMainParticipantRole);
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

        public static MySqlCommand GetWorkAverageRating (int work)
        {
            MySqlCommand com = new MySqlCommand(Statements.getWorkAverageRating);
            com.Parameters.AddWithValue("@work", work);
            return com;
        }

        public static MySqlCommand GetPersonById (int person)
        {
            MySqlCommand com = new MySqlCommand(Statements.getPersonById);
            com.Parameters.AddWithValue("@person", person);
            return com;
        }

        public static MySqlCommand GetPersonRolesByPersonId (int person)
        {
            MySqlCommand com = new MySqlCommand(Statements.getPersonRolesByPersonId);
            com.Parameters.AddWithValue("@person", person);
            return com;
        }

        public static MySqlCommand GetAllPersonImages (int person)
        {
            MySqlCommand com = new MySqlCommand(Statements.getAllPersonImages);
            com.Parameters.AddWithValue("@person", person);
            return com;
        }

        public static MySqlCommand GetRecentPersonReviews (int person, int limit)
        {
            MySqlCommand com = new MySqlCommand(Statements.getRecentPersonReviews);
            com.Parameters.AddWithValue("@person", person);
            com.Parameters.AddWithValue("@limit", limit);
            return com;
        }

        public static MySqlCommand GetAllPersonReviews (int person)
        {
            MySqlCommand com = new MySqlCommand(Statements.getAllPersonReviews);
            com.Parameters.AddWithValue("@person", person);
            return com;
        }

        public static MySqlCommand GetPersonAverageRating (int person)
        {
            MySqlCommand com = new MySqlCommand(Statements.getPersonAverageRating);
            com.Parameters.AddWithValue("@person", person);
            return com;
        }

        public static MySqlCommand GetCompanyById (int company)
        {
            MySqlCommand com = new MySqlCommand(Statements.getCompanyById);
            com.Parameters.AddWithValue("@company", company);
            return com;
        }

        public static MySqlCommand GetCompanyRolesByCompanyId (int company)
        {
            MySqlCommand com = new MySqlCommand(Statements.getCompanyRolesByCompanyId);
            com.Parameters.AddWithValue("@company", company);
            return com;
        }

        public static MySqlCommand GetAllCompanyImages (int company)
        {
            MySqlCommand com = new MySqlCommand(Statements.getAllCompanyImages);
            com.Parameters.AddWithValue("@company", company);
            return com;
        }

        public static MySqlCommand GetRecentCompanyReviews (int company, int limit)
        {
            MySqlCommand com = new MySqlCommand(Statements.getRecentCompanyReviews);
            com.Parameters.AddWithValue("@company", company);
            com.Parameters.AddWithValue("@limit", limit);
            return com;
        }

        public static MySqlCommand GetAllCompanyReviews (int company)
        {
            MySqlCommand com = new MySqlCommand(Statements.getAllCompanyReviews);
            com.Parameters.AddWithValue("@company", company);
            return com;
        }

        public static MySqlCommand GetCompanyAverageRating (int company)
        {
            MySqlCommand com = new MySqlCommand(Statements.getCompanyAverageRating);
            com.Parameters.AddWithValue("@company", company);
            return com;
        }

        public static MySqlCommand GetUserById (int user)
        {
            MySqlCommand com = new MySqlCommand(Statements.getUserById);
            com.Parameters.AddWithValue("@user", user);
            return com;
        }

        public static MySqlCommand GetAllUserImages (int user)
        {
            MySqlCommand com = new MySqlCommand(Statements.getAllUserImages);
            com.Parameters.AddWithValue("@user", user);
            return com;
        }

        public static MySqlCommand GetUserInterestsByUserId (int user)
        {
            MySqlCommand com = new MySqlCommand(Statements.getUserInterestsByUserId);
            com.Parameters.AddWithValue("@user", user);
            return com;
        }

        public static MySqlCommand GetUserCountry (int user)
        {
            MySqlCommand com = new MySqlCommand(Statements.getUserCountry);
            com.Parameters.AddWithValue("@user", user);
            return com;
        }

        public static MySqlCommand GetInterestById (int interest)
        {
            MySqlCommand com = new MySqlCommand(Statements.getInterestById);
            com.Parameters.AddWithValue("@interest", interest);
            return com;
        }

        public static MySqlCommand GetInterestDemographicsByInterestId (int interest)
        {
            MySqlCommand com = new MySqlCommand(Statements.getInterestDemographicsByInterestId);
            com.Parameters.AddWithValue("@interest", interest);
            return com;
        }
    }
}
