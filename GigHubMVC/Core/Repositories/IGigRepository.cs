using GigHubMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHubMVC.Core.Repositories
{
    public interface IGigRepository
    {
        IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithArtistAndGenre(int gigId);
        Gig GetGig(int gigId);
        void Add(Gig gig);
        IEnumerable<Gig> GetUpcomingGigs(string searchTerm = null);
    }
}
