using MDP.Data;
using MDP.Models.Pages;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class InterestUpdatePageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<UserPageModel>
    {
        public async Task<UserPageModel> HandleRequest(int id)
        {
            Task<MySqlDataReader> interestsTask = connector.ExecuteQuery(StatementPreparer.GetAllInterestBasedOnUser(id));
            UserPageModel toReturn = new UserPageModel();

            MySqlDataReader reader = await interestsTask;
            while (reader.Read())
            {
                if(reader.GetBoolean("selected"))
                    toReturn.InterestDictionary["Selected"].Add(Models.Interest.FromQuery(reader));
                else
                    toReturn.InterestDictionary["Unselected"].Add(Models.Interest.FromQuery(reader));
            }

            return toReturn;
        }
    }
}
