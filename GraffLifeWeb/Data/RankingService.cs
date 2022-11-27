using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Data
{
    /// <summary>
    /// WE SHOULD PROBABLY BE RETURNING A LIST OF THUMBNAILS AND ONLY ASK FOR AN INDIVIDUAL PIECE WHEN YOU YOU WANT TO RENDER THAT
    /// do we store thumbnail images w/ all the images in the DB?
    /// whether we should do this or not depends on what do we need to optimize for w.r.t. AWS free tier limits... space or bandwith?
    /// </summary>

    public class RankingService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public RankingService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        /// TODO: Optimize to only return enough to display on one page at a time: LIMIT 0, 100 ... LIMIT 100, 100 ... LIMIT 200, 100.....
        ///   will need to have another method to return total count, so we know how many page navigation buttons to make...
        public List<UserInfoResponse2> GetUserRankingsAsync()
        {
            List<UserInfoResponse2> rankings;
            using (var scope = scopeFactory.CreateScope())
            {
                string query = "SELECT UserInfo.userId, AspNetUsers.UserName, UserInfo.avatar, UserInfo.fame," 
                             + " UserInfo.level, UserInfo.memberSince, UserInfo.mainCrewId, Crews.abbreviation"
                             + " FROM UserInfo, Crews, AspNetUsers"
                             + " WHERE UserInfo.fame > 0 && UserInfo.mainCrewId=Crews.crewId && UserInfo.userId=AspNetUsers.Id"
                             + " ORDER BY UserInfo.fame DESC;";
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                rankings = dbContext.UserInfoResponse2
                    .FromSqlRaw<UserInfoResponse2>(query)
                    .ToList<UserInfoResponse2>();
            }
            return rankings;
        }

        public List<CrewRankingResponse> GetCrewRankingsAsync()
        {
            List<CrewRankingResponse> rankings;
            using (var scope = scopeFactory.CreateScope())
            {
                string query = "SELECT Crews.crewId, Crews.fame, Crews.abbreviation, Crews.name FROM Crews"
                             + " WHERE fame > 0 ORDER BY fame DESC;";
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                rankings = dbContext.CrewRankingResponse
                    .FromSqlRaw<CrewRankingResponse>(query)
                    .ToList<CrewRankingResponse>();
            }
            return rankings;
        }
    }
}
 