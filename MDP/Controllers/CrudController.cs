using MDP.Data;
using MDP.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    public class CrudController <K,I> : ControllerBase
    {
        private readonly DatabaseConnector conn;
        protected readonly ICrudHandler<K,I> crudHandler;
        public CrudController(DatabaseConnector conn, ICrudHandler<K,I> crud)
        {
            this.conn = conn;
            this.crudHandler = crud;
        }

        [HttpPost]
        public K Create(I original)
        {
            try
            {
                return crudHandler.Create(original).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(K);
            }
        }

        [HttpGet("{id}")]
        public K? Get(int id)
        {
            return crudHandler.Get(id).Result;
        }

        [HttpGet("paginated")]
        public List<K> GetPaginatedRange(int page, int amount)
        {
            return crudHandler.GetPaginatedRange(page, amount).Result;
        }

        [HttpGet("count")]
        public int GetCount()
        {
            return crudHandler.GetCount().Result;
        }

        [HttpPatch]
        public K Update(K updated)
        {
            return crudHandler.Update(updated).Result;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return crudHandler.Delete(id).Result;
        }
    }
}
