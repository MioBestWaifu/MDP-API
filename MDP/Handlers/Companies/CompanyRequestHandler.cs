using MDP.Data;
using MDP.Models.Accessory;
using MDP.Models;
using MDP.Models.Companies;
using MDP.Models.Persons;
using Microsoft.EntityFrameworkCore;

namespace MDP.Handlers.Companies
{
    /// <summary>
    /// Returns a full Company. If you need a partial one, query elsewhere
    /// </summary>
    /// <param name="conn"></param>
    public class CompanyRequestHandler(DatabaseConnector conn) : Handler(conn), ICrudHandler<Company, CompanyInsert>
    {
        public async Task<Company> Create(CompanyInsert original)
        {
            Company toCreate = new Company();
            toCreate.ShortName = new Name() { Literal = original.ShortName };
            toCreate.FullName = new Name() { Literal = original.FullName };
            toCreate.Description = original.Description;
            toCreate.FoundingDate = original.FoundingDate;
            toCreate.Country = await connector.Countries.FindAsync(original.Country.Id);
            toCreate.Roles = new List<Role>();
            foreach (Role role in original.Roles)
            {
                toCreate.Roles.Add(await connector.Roles.FindAsync(role.Id));
            }

            await connector.Companies.AddAsync(toCreate);
            await connector.SaveChangesAsync();
            return toCreate;
        }

        //Will have to remove iamges too at some point
        public async Task<bool> Delete(int id)
        {
            var nameIds = await connector.Companies.Include(x => x.ShortName)
                .Include(x => x.FullName)
                .Where(x => x.Id == id)
                .Select(x => new List<int> { x.ShortName.Id, x.FullName.Id }.ToList())
                .FirstOrDefaultAsync();
            connector.Names.RemoveRange(connector.Names.Where(n => nameIds.Contains(n.Id)));

            connector.Companies.Remove(connector.Companies.Find(id));
            await connector.SaveChangesAsync();

            return true;
        }

        public async Task<Company?> Get(int id)
        {
            return await connector.Companies
                .Include(x => x.ShortName)
                .Include(x => x.FullName)
                .Include(x => x.CardImage)
                .Include(x => x.MainImage)
                .Include(x => x.OtherImages)
                .Include(x => x.Country)
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Id == id);
            //Do averagerating
        }

        public async Task<int> GetCount()
        {
            return await connector.Companies.CountAsync();
        }

        public async Task<List<Company>> GetPaginatedRange(int page, int amount)
        {
            return await connector.Companies
            .OrderBy(a => a.Id)
            .Skip((page - 1) * amount)
            .Take(amount)
            .ToListAsync();
        }

        public async Task<Company> Update(Company updated)
        {
            Company toUpdate = await Get(updated.Id);
            toUpdate.ShortName.Literal = updated.ShortName.Literal;
            toUpdate.FullName.Literal = updated.FullName.Literal;
            toUpdate.Description = updated.Description;
            toUpdate.FoundingDate = updated.FoundingDate;
            toUpdate.Country = await connector.Countries.FindAsync(updated.Country.Id);
            toUpdate.Roles = new List<Role>();
            foreach (Role role in updated.Roles)
            {
                toUpdate.Roles.Add(await connector.Roles.FindAsync(role.Id));
            }

            await connector.SaveChangesAsync();
            return toUpdate;
        }
    }
}
