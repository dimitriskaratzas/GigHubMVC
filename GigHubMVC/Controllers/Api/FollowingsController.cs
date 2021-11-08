using GigHubMVC.Core.Dtos;
using GigHubMVC.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GigHubMVC.Persistence;
using GigHubMVC.Core;

namespace GigHubMVC.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly string _userId;
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _userId = User.Identity.GetUserId();
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {


            var following = _unitOfWork.Followings.GetFollowing(_userId, dto.FolloweeId);
            if (following != null)
                return BadRequest("Following already exists");
                

            following = new Following()
            {
                FollowerId = _userId,
                FolloweeId = dto.FolloweeId
            };

            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var following = _unitOfWork.Followings.GetFollowing(_userId, id);

            if (following == null)
                return NotFound();

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }

    
}
