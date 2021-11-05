using GigHubMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHubMVC.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}
