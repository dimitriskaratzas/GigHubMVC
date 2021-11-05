using GigHubMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHubMVC.Repositories
{
    public interface IFollowingRepository
    {
        IEnumerable<Following> GetFollowings(string userId);
        Following GetFollowing(string followerId, string followeeId);
        void Add(Following following);
        void Remove(Following following);
    }
}
