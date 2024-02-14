using MDP.Data;
using MDP.Handlers.Interest;
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
                var toAdd = Models.Interest.FromQuery(reader);
                toAdd.SetDemographics(await new InterestRequestHandler(connector).GetDemographics(toAdd.Id));
                if (reader.GetBoolean("selected"))
                    toReturn.InterestDictionary["Selected"].Add(toAdd);
                else
                    toReturn.InterestDictionary["Unselected"].Add(toAdd);
            }

            return toReturn;
        }
    }
}
