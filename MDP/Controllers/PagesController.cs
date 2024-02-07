using Microsoft.AspNetCore.Mvc;
using MDP.Models.Pages;

namespace MDP.Controllers
{
    [ApiController]
    [Route("api/pages")]
    public class PagesController : ControllerBase
    {
        [HttpGet("community")]
        public CommunityPageModel GetCommunityPage(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("company")]
        public CompanyPageModel GetCompanyPage(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("favorites")]
        public FavoritesPageModel GetFavoritesPage()
        {
            throw new NotImplementedException();
        }

        [HttpGet("home")]
        public HomePageModel GetHomePage()
        {
            throw new NotImplementedException();
        }

        [HttpGet("interestsetup")]
        public InterestSetupPageModel GetInterestSetupPage()
        {
            throw new NotImplementedException();
        }

        [HttpGet("interestupdate")]
        public InterestUpdatePageModel GetInterestUpdatePage()
        {
            throw new NotImplementedException();
        }

        [HttpGet("person")]
        public PersonPageModel GetPersonPage(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("search")]
        public SearchPageModel GetSearchPage()
        {
            throw new NotImplementedException();
        }

        [HttpGet("user")]
        public UserPageModel GetUserPage(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("work")]
        public WorkPageModel GetWorkPage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
