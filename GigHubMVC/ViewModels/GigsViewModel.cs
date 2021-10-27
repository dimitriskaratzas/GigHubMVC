using GigHubMVC.Models;
using System.Collections.Generic;

namespace GigHubMVC.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
    }
}