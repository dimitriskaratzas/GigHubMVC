using GigHubMVC.CustomAnnotations;
using GigHubMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHubMVC.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime(ErrorMessage ="The time formula is invalid")]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; } //this is the id

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            
        }
    }
}