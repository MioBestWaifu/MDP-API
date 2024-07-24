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
            //Will rethink Interests later, so keeping this empty
            InterestUpdatePageModel toReturn = new InterestUpdatePageModel();

            return toReturn;
        }
    }
}
