using MDP.Data;
using MDP.Handlers.Persons;
using MDP.Models.Pages;
using MDP.Models;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class PersonPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<PersonPageModel>
    {
        public async Task<PersonPageModel> HandleRequest(int id)
        {
            PersonPageModel toReturn = new PersonPageModel();
            toReturn.Person = await new PersonRequestHandler(conn).HandleRequest(id);
            return toReturn;
        }
    }
}
