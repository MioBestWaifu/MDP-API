using MDP.Data;
using MDP.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MDP.Handlers
{
    public class AuthHandler(DatabaseConnector connector) : Handler(connector)
    {
        public User Login(User login)
        {
            var user = connector.Users.Include(x=> x.ShortName)
                .Include(x=> x.CardImage)
                .FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if (user is null)
            {
                throw new InvalidOperationException("Invalid email or password");
            }
            return user;
        }

        public bool Register(User register)
        {
            if (connector.Users.FirstOrDefault(x => x.Email == register.Email) != null)
            {
                return false;
            }
            register.Country = connector.Countries.FirstOrDefault(x => x.Id == register.Country.Id);
            connector.Users.Add(register);
            connector.SaveChanges();
            return true;
        }
    }
}
