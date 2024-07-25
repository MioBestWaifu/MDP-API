using MDP.Data;
using MDP.Handlers.Work;
using MDP.Models;
using MDP.Models.Pages;
using MDP.Models.Works;
using MDP.Utils;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class HomePageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<HomePageModel>
    {
        public async Task<HomePageModel> HandleRequest(int id)
        {
            HomePageModel toReturn = new HomePageModel();
            toReturn.Artifacts = connector.Artifacts
                .Include(a => a.Categories)
                .Include(a => a.TargetDemographics)
                .Include(a => a.AgeRating)
                .Include(a => a.CardImage)
                .Include(a => a.MainImage)
                .Include(a => a.Media)
                .Include(a => a.ShortName)
                .Include(a => a.FullName)
                .Take(10)
                .ToList();

            toReturn.NewsAndHighlights = connector.GlobalNews
                .OrderByDescending(x=>x.News.Date)
                .Take(Constants.MAX_RECENT_NEWS)
                .Select(x=> x.News)
                .ToList();

            return toReturn;
        }
    }
}
