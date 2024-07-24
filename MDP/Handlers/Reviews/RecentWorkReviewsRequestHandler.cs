﻿using MDP.Data;
using MDP.Utils;
using MySql.Data.MySqlClient;
using MDP.Handlers.Users;
using MDP.Models;

namespace MDP.Handlers.Reviews
{
    public class RecentWorkReviewsRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<Review>>
    {
        public async Task<List<Review>> HandleRequest(int id)
        {
            return connector.ArtifactReviews.Where(x => x.Artifact.Id == id).OrderByDescending(x => x.Review.Date).Take(Constants.MAX_RECENT_REVIEWS).Select(x=>x.Review).ToList();
        }
    }
}
