using Microsoft.AspNetCore.Mvc;
using MDP.Models.Pages;

namespace MDP.Controllers
{
    [ApiController]
    [Route("pages")]
    public class PagesController : ControllerBase
    {
        [HttpGet(Name = "community")]
        public CommunityPageModel GetCommunityPage(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "company")]
        public CompanyPageModel GetCompanyPage(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "favorites")]
        public FavoritesPageModel GetFavoritesPage()
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "home")]
        public HomePageModel GetHomePage()
        {
            throw new NotImplementedException();
        }

        public InterestSetupPageModel GetInterestSetupPage()
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "interestupdate")]
        public InterestUpdatePageModel GetInterestUpdatePage()
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "person")]
        public PersonPageModel GetPersonPage(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "search")]
        public SearchPageModel GetSearchPage()
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "user")]
        public UserPageModel GetUserPage(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "work")]
        public WorkPageModel GetWorkPage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
