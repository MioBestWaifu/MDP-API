using MDP.Data;
using MDP.Models;
using MDP.Models.Works;
using Microsoft.EntityFrameworkCore;

namespace MDP.Handlers.Work
{
    /// <summary>
    /// This returns a full Artifact. If you need a partial one, query elsewhere.
    /// </summary>
    /// <param name="conn"></param>
    public class WorkRequestHandler(DatabaseConnector conn) : Handler(conn), ICrudHandler<Artifact, ArtifactInsert>
    {
        public async Task<Artifact> Create(ArtifactInsert original)
        {
            var names = original.OtherNames?.Select(x => new Name { Literal = x }).ToList();
            var media = connector.Medias.First(x => x.Id == original.Media);
            var categories = original.Categories.Where(x => connector.Categories.Any(y => y.Id == x.Id)).ToList();
            var demographics = original.TargetDemographics?.Where(x => connector.Demographics.Any(y => y.Id == x.Id)).ToList();
            var ageRating = connector.AgeRatings.First(x => x.Id == original.AgeRating);
            Artifact toCreate = new Artifact
            {
                ShortName = new Name { Literal = original.Name },
                FullName = new Name { Literal = original.FullName },
                OtherNames = names,
                Description = original.Description,
                Media = media,
                Categories = categories,
                TargetDemographics = demographics,
                AgeRating = ageRating,
                ReleaseDate = original.ReleaseDate
            };
            await connector.Artifacts.AddAsync(toCreate);
            await connector.SaveChangesAsync();
            return toCreate;
        }

        //This needs to delete the otherImages too
        public async Task<bool> Delete(int id)
        {
            var nameIds = await connector.Artifacts.Include(x => x.ShortName)
                .Include(x => x.FullName)
                .Include(x => x.OtherNames)
                .Where(x => x.Id == id)
                .Select(x => new List<int> { x.ShortName.Id, x.FullName.Id }.Concat(x.OtherNames.Select(y => y.Id)).ToList())
                .FirstOrDefaultAsync();
            connector.Names.RemoveRange(connector.Names.Where(n=>nameIds.Contains(n.Id)));
            connector.Artifacts.Remove(await connector.Artifacts.FirstAsync(x=> x.Id == id));
            await connector.SaveChangesAsync();
            return true;
        }

        public async Task<Artifact?> Get(int id)
        {
            var artifact = await connector.Artifacts
                .Include(a => a.Categories)
                .Include(a => a.TargetDemographics)
                .Include(a => a.AgeRating)
                .Include(a => a.CardImage)
                .Include(a => a.MainImage)
                .Include(a => a.Media)
                .Include(a => a.ShortName)
                .Include(a => a.FullName)
                .FirstOrDefaultAsync(a => a.Id == id);

            return artifact;
        }

        public async Task<int> GetCount()
        {
            return await connector.Artifacts.CountAsync();
        }

        public async Task<List<Artifact>> GetPaginatedRange(int page, int amount)
        {
            return await connector.Artifacts
                .OrderBy(a => a.Id) 
                .Skip((page - 1) * amount)
                .Take(amount)
                .ToListAsync();
        }

        public async Task<Artifact> Update(Artifact updated)
        {
            var existingEntity = await Get(updated.Id);

            if (existingEntity != null)
            {
                //Images go in their own thing, not here
                existingEntity.ShortName.Literal = updated.ShortName.Literal;
                existingEntity.FullName.Literal = updated.FullName.Literal;
                
                
                if (updated.OtherNames != null)
                {
                    if (existingEntity.OtherNames == null)
                        existingEntity.OtherNames = new List<Name>();
                    //Remove the names that are not in the updated list...
                    existingEntity.OtherNames.RemoveAll(x => !updated.OtherNames.Any(y => y.Id == x.Id));
                    //...Then update the remaining
                    foreach (var name in updated.OtherNames)
                    {
                        var exName = existingEntity.OtherNames.Find(x => x.Id == name.Id);
                        if (exName is null)
                        {
                            exName = new Name();
                        }
                        exName.Literal = name.Literal;
                    }
                }
                existingEntity.Description = updated.Description;
                existingEntity.Media = connector.Medias.Find(updated.Media.Id);
                existingEntity.Categories = updated.Categories.Select(x=> connector.Categories.First(y=> y.Id == x.Id)).ToList();
                existingEntity.TargetDemographics = updated.TargetDemographics.Select(x => connector.Demographics.First(y => y.Id == x.Id)).ToList(); ;
                existingEntity.AgeRating = connector.AgeRatings.Find(updated.AgeRating.Id);
                existingEntity.ReleaseDate = updated.ReleaseDate;

                await connector.SaveChangesAsync();
                return existingEntity;
            }

            throw new InvalidOperationException("Entity not found");

        }
    }
}
