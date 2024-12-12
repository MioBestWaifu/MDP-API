using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Common;
using MDP.Models.Persons;
using Microsoft.EntityFrameworkCore;
using MDP.Models;
using MDP.Models.Accessory;
namespace MDP.Handlers.Persons
{
    /// <summary>
    /// Returns a full Person. If you need a partial one, query elsewhere.s
    /// </summary>
    public class PersonRequestHandler(DatabaseConnector conn) : Handler(conn), ICrudHandler<Person,PersonInsert>
    {
        public async Task<Person> Create(PersonInsert original)
        {
            Person toCreate = new Person();
            toCreate.ShortName = new Name() { Literal = original.ShortName};
            toCreate.FullName = new Name() { Literal = original.FullName };
            if(original.Nicknames != null)
            {
                toCreate.Nicknames = new List<Name>();
                foreach (string nickname in original.Nicknames)
                {
                    toCreate.Nicknames.Add(new Name() { Literal = nickname });
                }
            }
            toCreate.Description = original.Description;
            toCreate.Birthday = original.Birthday;
            toCreate.Gender = original.Gender;
            toCreate.Country = await connector.Countries.FindAsync(original.Country);
            toCreate.Roles = new List<Role>();
            foreach (int roleId in original.Roles)
            {
                toCreate.Roles.Add(await connector.Roles.FindAsync(roleId));
            }

            await connector.People.AddAsync(toCreate);
            await connector.SaveChangesAsync();
            return toCreate;
        }

        public async Task<Person?> Get(int id)
        {
            return await connector.People
                .Include(x => x.ShortName)
                .Include(x => x.FullName)
                .Include(x => x.Nicknames)
                .Include(x => x.CardImage)
                .Include(x => x.MainImage)
                .Include(x => x.OtherImages)
                .Include(x => x.Country)
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        

        public async Task<Person> Update(Person updated)
        {
            Person toCreate = await Get(updated.Id);
            if(toCreate == null)
            {
                throw new InvalidOperationException("Person not found");
            }
            toCreate.ShortName.Literal = updated.ShortName.Literal;
            toCreate.FullName.Literal = updated.FullName.Literal;

            if(updated.Nicknames != null)
            {
                if(toCreate.Nicknames == null)
                    toCreate.Nicknames = new List<Name>();

                toCreate.Nicknames.RemoveAll(x => !updated.Nicknames.Any(y => y.Id == x.Id));

                foreach (Name nickname in updated.Nicknames)
                {
                    var orName = toCreate.Nicknames.Find(z=>z.Id == nickname.Id);

                    if (orName is null)
                        orName = new Name();

                    orName.Literal = nickname.Literal;
                }
            }

            toCreate.Description = updated.Description;
            toCreate.Birthday = updated.Birthday;
            toCreate.Gender = updated.Gender;
            toCreate.Country = await connector.Countries.FindAsync(updated.Country.Id);

            List<Role> buffer = [];
            foreach (Role role in updated.Roles)
            {
                buffer.Add(connector.Roles.Find(role.Id));
            }

            toCreate.Roles = buffer;

            await connector.SaveChangesAsync();
            return toCreate;
        }

        public async Task<bool> Delete(int id)
        {
            var nameIds = await connector.People.Include(x => x.ShortName)
                .Include(x => x.FullName)
                .Include(x => x.Nicknames)
                .Where(x => x.Id == id)
                .Select(x => new List<int> { x.ShortName.Id, x.FullName.Id }.Concat(x.Nicknames.Select(y => y.Id)).ToList())
                .FirstOrDefaultAsync();
            connector.Names.RemoveRange(connector.Names.Where(n => nameIds.Contains(n.Id)));
            
            connector.People.Remove(connector.People.Find(id));
            await connector.SaveChangesAsync();

            return true;
        }
    }
}
