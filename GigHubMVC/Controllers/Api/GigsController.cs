using GigHubMVC.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GigHubMVC.Persistence;
using GigHubMVC.Core;

namespace GigHubMVC.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = _unitOfWork.Gigs.GetGig(id);

            if (userId != gig.ArtistId)
                return Unauthorized();

            if (gig == null)
                return NotFound();

            if (gig.IsCancelled)
                return NotFound();

            gig.IsCancelled = true;

            _unitOfWork.Complete();
            return Ok();
        }
    }
}
