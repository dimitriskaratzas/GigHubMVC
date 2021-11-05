using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHubMVC.Repositories
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IAttendanceRepository Attendances { get; }
        IGenreRepository Genres { get; }
        IFollowingRepository Followings { get; }

        void Complete();
    }
}
