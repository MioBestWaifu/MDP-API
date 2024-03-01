using Microsoft.AspNetCore.Mvc;
using MDP.Models.Pages;
using MDP.Handlers.Pages;
using MDP.Data;

namespace MDP.Controllers
{
    [ApiController]
    [Route("pages")]
    public class PagesController : ControllerBase
    {
        private readonly DatabaseConnector conn;
        public PagesController(DatabaseConnector conn)
        {
            this.conn = conn;
        }
        [HttpGet("community")]
        public CommunityPageModel GetCommunityPage(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("company")]
        [ResponseCache(Duration = 60)]
        public CompanyPageModel GetCompanyPage(int id)
        {
            return new CompanyPageRequestHandler(conn).HandleRequest(id).Result;
        }

        [HttpGet("favorites")]
        public FavoritesPageModel GetFavoritesPage()
        {
            return new FavoritesPageRequestHandler(conn).HandleRequest(1).Result;
        }

        [HttpGet("home")]
        public HomePageModel GetHomePage()
        {
            return new HomePageRequestHandler(conn).HandleRequest(1).Result;
        }

        [HttpGet("interestsetup")]
        public InterestSetupPageModel GetInterestSetupPage()
        {
            throw new NotImplementedException();
        }

        [HttpGet("interestupdate")]
        public InterestUpdatePageModel GetInterestUpdatePage()
        {
            return new InterestUpdatePageRequestHandler(conn).HandleRequest(1).Result;
        }

        [HttpGet("person")]
        [ResponseCache(Duration = 60)]
        public PersonPageModel GetPersonPage(int id)
        {
            return new PersonPageRequestHandler(conn).HandleRequest(id).Result;
        }

        [HttpGet("search")]
        public SearchPageModel GetSearchPage(string query)
        {
            return new SearchPageRequestHandler(conn).HandleSearch(query).Result;
        }

        [HttpGet("user")]
        [ResponseCache(Duration = 60)]
        public UserPageModel GetUserPage(int id)
        {
            return new UserPageRequestHandler(conn).HandleRequest(id).Result;
        }

        [HttpGet("work")]
        [ResponseCache(Duration = 60)]
        public WorkPageModel GetWorkPage(int id)
        {
            return new WorkPageRequestHandler(conn).HandleRequest(id).Result;
        }
    }
}
