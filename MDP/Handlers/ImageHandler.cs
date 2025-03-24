using MDP.Data;
using MDP.Models;
using MDP.Models.Works;

namespace MDP.Handlers
{
    public class ImageHandler(DatabaseConnector conn) : Handler(conn), ICrudHandler<Image, ImageInsert>
    {
        public Task<Image> Create(ImageInsert original)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Image?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Image> Update(Image updated)
        {
            throw new NotImplementedException();
        }
    }
}
