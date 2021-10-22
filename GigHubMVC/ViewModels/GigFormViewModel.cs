using GigHubMVC.Models;
using System.Collections.Generic;

namespace GigHubMVC.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; } //this is the id
        public IEnumerable<Genre> Genres { get; set; }
    }
}