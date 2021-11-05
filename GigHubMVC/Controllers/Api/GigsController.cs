using GigHubMVC.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GigHubMVC.Persistence;

namespace GigHubMVC.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = _context.Gigs
                .SingleOrDefault(g => g.ID == id && g.ArtistId == userId);

            if (gig == null)
                return NotFound();

            if (gig.IsCancelled)
                return NotFound();

            gig.IsCancelled = true;

            _context.SaveChanges();
            return Ok();
        }
    }
}
