using MDP.Models;
using MDP.Data;
using MDP.Models.Recommendation;
using MDP.Models.Users;
using Microsoft.EntityFrameworkCore;
namespace MDP.Handlers.Reviews
{


    /// <summary>
    /// Busca, cria e retorna uma única review baseada no Id dela.
    /// </summary>
    public class ReviewRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Review>
    {
        public async Task<Review?> HandleRequest(int id)
        {
            return connector.Reviews.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Review(int artifactId, int userId, int rate)
        {
            User user = connector.Users.Find(userId);
            var review = new Review { ArtifactId = artifactId, User = user, Rating = rate, Comment = "", Date = new DateOnly() };
            connector.Reviews.Add(review);
            connector.SaveChanges();

            if(review.Rating >= 7)
            {
                var demographicsUserAlreadyHas = connector.UserDemos.Where(x => x.User.Id == review.User.Id).Select(x=> x.Demographic).ToList();
                var artifactCategories = connector.Artifacts.Include(x=> x.Categories).First(x=> x.Id == artifactId).Categories;
                var demographicsFromCategories = connector.DemoCats.Where(x => artifactCategories.Contains(x.Category)).Select(x => x.Demographic).ToList();
                var demographicsToInsert = demographicsFromCategories.Except(demographicsUserAlreadyHas).ToList();
                foreach (var demo in demographicsToInsert)
                {
                    connector.UserDemos.Add(new UserDemo { User = review.User, Demographic = demo });
                }
            }

            connector.SaveChanges();
            return true;
        }
    }
}
