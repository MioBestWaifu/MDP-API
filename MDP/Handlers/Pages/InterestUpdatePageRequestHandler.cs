using MDP.Data;
using MDP.Models.Pages;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class InterestUpdatePageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<InterestUpdatePageModel>
    {
        public async Task<InterestUpdatePageModel> HandleRequest(int id)
        {
            Task<MySqlDataReader> interestsTask = connector.ExecuteQuery(StatementPreparer.GetAllInterestBasedOnUser(id));
            InterestUpdatePageModel toReturn = new InterestUpdatePageModel();

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
