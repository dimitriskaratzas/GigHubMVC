using GigHubMVC.Core.Dtos;
using GigHubMVC.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GigHubMVC.Persistence;

namespace GigHubMVC.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly string _userId;
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _userId = User.Identity.GetUserId();
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
           

            if (_context.Followings
                .Any(f => f.FollowerId == _userId && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("Following already exists.");
            }
                

            var following = new Following()
            {
                FollowerId = _userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var following = _context.Followings
                .SingleOrDefault(f => f.FollowerId == _userId && f.FolloweeId == id);

            if (following == null)
                return NotFound();

            _context.Followings.Remove(following);
            _context.SaveChanges();

            return Ok(id);
        }
    }

    
}
