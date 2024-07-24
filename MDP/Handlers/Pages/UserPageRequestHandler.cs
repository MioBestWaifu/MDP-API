using MDP.Data;
using MDP.Handlers.Users;
using MDP.Models.Pages;

namespace MDP.Handlers.Pages
{
    public class UserPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<UserPageModel>
    {
        public async Task<UserPageModel> HandleRequest(int id)
        {
            UserPageModel toReturn = new UserPageModel
            {
                //What if null?
                User = await new UserRequestHandler(conn).HandleRequest(id)
            };
            return toReturn;
        }
    }
}
