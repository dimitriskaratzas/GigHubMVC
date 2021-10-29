using GigHubMVC.CustomAnnotations;
using GigHubMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHubMVC.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }

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

        public string Heading { get; set; }

        public string Action 
        { 
            get 
            {
                return (Id != 0) ? "Edit" : "Create";
            } 
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            
        }
    }
}