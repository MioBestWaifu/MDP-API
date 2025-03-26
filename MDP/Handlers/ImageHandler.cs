using MDP.Data;
using MDP.Models;
using MDP.Models.Companies;
using MDP.Models.Persons;
using MDP.Models.Works;

namespace MDP.Handlers
{
    public class ImageHandler(DatabaseConnector conn) : Handler(conn), ICrudHandler<Image, ImageInsert>
    {
        public async Task<Image> Create(ImageInsert original)
        {
            Image toInsert;
            switch (original.TargetType)
            {
                case EntityType.Artifact:
                    toInsert = new Image {
                        Content = original.Content,
                        Type = original.Type
                    };

                    Artifact target = connector.Artifacts.First(x => x.Id == original.TargetId);
                    if (original.Type == ImageType.MainImage)
                    {
                        target.MainImage = toInsert;
                    } else if (original.Type == ImageType.CardImage)
                    {
                        target.CardImage = toInsert;
                    } else
                    {
                        target.OtherImages ??= [];
                        target.OtherImages.Add(toInsert);
                    }
                    await connector.SaveChangesAsync();
                    return toInsert;
                case EntityType.Company:
                   toInsert = new Image
                    {
                        Content = original.Content,
                        Type = original.Type
                    };
                    Company targetCompany = connector.Companies.First(x => x.Id == original.TargetId);
                    if (original.Type == ImageType.MainImage)
                    {
                        targetCompany.MainImage = toInsert;
                    }
                    else if (original.Type == ImageType.CardImage)
                    {
                        targetCompany.CardImage = toInsert;
                    }
                    else
                    {
                        targetCompany.OtherImages ??= [];
                        targetCompany.OtherImages.Add(toInsert);
                    }
                    await connector.SaveChangesAsync();
                    return toInsert;
                case EntityType.Person:
                    toInsert = new Image
                    {
                        Content = original.Content,
                        Type = original.Type
                    };
                    Person targetPerson = connector.People.First(x => x.Id == original.TargetId);
                    if (original.Type == ImageType.MainImage)
                    {
                        targetPerson.MainImage = toInsert;
                    }
                    else if (original.Type == ImageType.CardImage)
                    {
                        targetPerson.CardImage = toInsert;
                    }
                    else
                    {
                        targetPerson.OtherImages ??= [];
                        targetPerson.OtherImages.Add(toInsert);
                    }
                    await connector.SaveChangesAsync();
                    return toInsert;
                default:
                    throw new Exception("Entity Type not supported");
            }

        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Image?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> GetPaginatedRange(int page, int amount)
        {
            throw new NotImplementedException();
        }

        public Task<Image> Update(Image updated)
        {
            throw new NotImplementedException();
        }
    }
}
