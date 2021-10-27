using GigHubMVC.Dtos;
using GigHubMVC.Models;
using System.Web.Http;

namespace GigHubMVC.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            return Ok();
        }
    }

    
}
