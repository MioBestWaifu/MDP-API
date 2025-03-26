using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Common;
using MDP.Models.Persons;
using Microsoft.EntityFrameworkCore;
using MDP.Models;
using MDP.Models.Accessory;
using MDP.Utils;
namespace MDP.Handlers.Persons
{
    /// <summary>
    /// Returns a full Person. If you need a partial one, query elsewhere.s
    /// </summary>
    public class PersonRequestHandler(DatabaseConnector conn) : Handler(conn), ICrudHandler<Person, PersonInsert>, ISearchHandler<List<Person>>
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
            toCreate.Country = await connector.Countries.FindAsync(original.Country.Id);
            toCreate.Roles = new List<Role>();
            foreach (Role role in original.Roles)
            {
                toCreate.Roles.Add(await connector.Roles.FindAsync(role.Id));
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
            Person toUpdate = await Get(updated.Id);
            if(toUpdate == null)
            {
                throw new InvalidOperationException("Person not found");
            }
            toUpdate.ShortName.Literal = updated.ShortName.Literal;
            toUpdate.FullName.Literal = updated.FullName.Literal;

            if(updated.Nicknames != null)
            {
                if(toUpdate.Nicknames == null)
                    toUpdate.Nicknames = new List<Name>();

                var toKeepNicknames = updated.Nicknames.Select(x => x.Id);
                toUpdate.Nicknames.RemoveAll(x=> !toKeepNicknames.Contains(x.Id));

                foreach (Name nickname in updated.Nicknames)
                {
                    var orName = toUpdate.Nicknames.Find(z=>z.Id == nickname.Id);

                    if (orName is null)
                        orName = new Name();

                    orName.Literal = nickname.Literal;
                }
            }

            toUpdate.Description = updated.Description;
            toUpdate.Birthday = updated.Birthday;
            toUpdate.Gender = updated.Gender;
            toUpdate.Country = await connector.Countries.FindAsync(updated.Country.Id);

            List<Role> buffer = [];
            foreach (Role role in updated.Roles)
            {
                buffer.Add(connector.Roles.Find(role.Id));
            }

            toUpdate.Roles.Clear();
            toUpdate.Roles = buffer;

            toUpdate.CardImage.Content = updated.CardImage.Content;
            toUpdate.MainImage.Content = updated.MainImage.Content;

            await connector.SaveChangesAsync();
            return toUpdate;
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

        public async Task<List<Person>> GetPaginatedRange(int page, int amount)
        {
            return await connector.People
                .OrderBy(a => a.Id)
                .Skip((page - 1) * amount)
                .Take(amount)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await connector.People.CountAsync();
        }

        public async Task<List<Person>> HandleSearch(string query, int page = 0)
        {
            return connector.People.Include(x => x.ShortName)
                .Include(x => x.FullName)
                .Where(x => x.ShortName.Literal.Contains(query) || x.FullName.Literal.Contains(query))
                .Take(Constants.MAX_SEARCH_WORKS)
                .Include(x => x.CardImage)
                .Include(x => x.Roles)
                .ToList();        
        }
    }
}
