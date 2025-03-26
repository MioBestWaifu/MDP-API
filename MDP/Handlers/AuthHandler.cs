using MDP.Data;
using MDP.Models.Accessory;
using MDP.Models.Recommendation;
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

            int userAge = DateTime.Now.Year - register.Birthday.Year;
            var ageBasedDemoIds = connector.DemoAges.Where(x=> x.RangeStart <= userAge && x.RangeEnd >= userAge).Select(x=> x.Demographic.Id).ToList();
            var genderBasedDemoIds = connector.DemoGenders.Where(x => x.Gender == register.Gender).Select(x => x.Demographic.Id).ToList();
            var countryBasedDemoIds = connector.DemoCountrys.Where(x => x.Country.Id == register.Country.Id).Select(x => x.Demographic.Id).ToList();

            var union = ageBasedDemoIds.Union(genderBasedDemoIds).Union(countryBasedDemoIds);
            foreach (var demoId in union)
            {
                 var demo = connector.Demographics.First(x => x.Id == demoId);
                connector.UserDemos.Add(new UserDemo { User = register, Demographic = demo});
            }
            connector.SaveChanges();

            return true;
        }
    }
}
