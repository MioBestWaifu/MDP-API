using MDP.Data;
using MDP.Models;
using MDP.Models.Works;

namespace MDP.Handlers
{
    public class ImageHandler(DatabaseConnector conn) : Handler(conn), ICrudHandler<Image, ImageInsert>
    {
        public async Task<Image> Create(ImageInsert original)
        {
            switch (original.TargetType)
            {
                case EntityType.Artifact:
                    Image toInsert = new Image {
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
