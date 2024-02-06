using Microsoft.AspNetCore.Mvc;
using MDP.Models.Pages;

namespace MDP.Controllers
{
    [ApiController]
    [Route("pages")]
    public class PagesController : ControllerBase
    {

        public CommunityPageModel GetCommunityPage()
        {
            throw new NotImplementedException();
        }

        public CompanyPageModel GetCompanyPage()
        {
            throw new NotImplementedException();
        }

        //Do the same as above for the rest of the models
        public UserPageModel GetUserPage()
        {
            throw new NotImplementedException();
        }

        public WorkPageModel GetWorkPage()
        {
            throw new NotImplementedException();
        }

        public FavoritesPageModel GetFavoritesPage()
        {
            throw new NotImplementedException();
        }

        public HomePageModel GetHomePage()
        {
               throw new NotImplementedException();
        }

        public InterestUpdatePageModel GetInterestUpdatePage()
        {
            throw new NotImplementedException();
        }

        public PersonPageModel GetPersonPage()
        {
            throw new NotImplementedException();
        }

        public SearchPageModel GetSearchPage()
        {
            throw new NotImplementedException();
        }

        
    }
}
