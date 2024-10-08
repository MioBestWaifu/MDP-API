﻿using MDP.Data;
using MDP.Models.Pages;
using MDP.Models.Works;
using MDP.Utils;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class SearchPageRequestHandler(DatabaseConnector conn) : Handler(conn), ISearchHandler<SearchPageModel>
    {
        public async Task<SearchPageModel> HandleSearch(string query, int page = 0)
        {
            List<Artifact> artifacts = connector.Artifacts
                .Where(a => a.ShortName.Literal.Contains(query) && a.FullName.Literal.Contains(query))
                .Skip(page * Constants.MAX_SEARCH_WORKS)
                .Include(a => a.ShortName)
                .Include(a => a.FullName)
                .Include(a => a.CardImage)
                .Take(Constants.MAX_SEARCH_WORKS).ToList();

            SearchPageModel toReturn = new SearchPageModel
            {
                Artifacts = artifacts
            };

            return toReturn;
        }
    }
}
