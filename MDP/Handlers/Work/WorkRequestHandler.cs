using MDP.Data;
using MDP.Models.Works;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Reflection.PortableExecutable;

namespace MDP.Handlers.Work
{
    /// <summary>
    /// This returns a full Artifact. If you need a partial one, query elsewhere,
    /// </summary>
    /// <param name="conn"></param>
    public class WorkRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Artifact>
    {
        public async Task<Artifact?> HandleRequest(int id)
        {
            var artifact = connector.Artifacts
                .Include(a => a.Categories)
                .Include(a => a.TargetDemographics)
                .Include(a => a.AgeRating)
                .Include(a => a.CardImage)
                .Include(a => a.MainImage)
                .Include(a => a.Media)
                .Include(a => a.ShortName)
                .Include(a => a.FullName)
                .FirstOrDefault(a => a.Id == id);

            return artifact;
        }
    }
}
