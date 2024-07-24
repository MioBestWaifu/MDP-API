using MDP.Data;
using MDP.Models.Works;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Reflection.PortableExecutable;

namespace MDP.Handlers.Work
{
    public class WorkRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Artifact>
    {
        public async Task<Artifact?> HandleRequest(int id)
        {
            return await connector.Artifacts.FindAsync(id);
        }
    }
}
