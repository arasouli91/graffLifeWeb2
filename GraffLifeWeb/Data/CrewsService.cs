using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Data
{
    public class CrewsService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public CrewsService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        } 

        public void UpdateCrew(string username)
        {

            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.ExecuteSqlRaw("INSERT INTO `grafflife`.`UserInfo` (`userId`, `fame`, `level`, `memberSince`) VALUES ('7335f761-108f-45e3-a6ea-1094bcb11642', '1', '1', '2008-01-01 00:00:01');");
            }
        }

        // Get the user's crew memberships and fame and id for each crew
        public List<CrewMembershipResponse> GetMemberships(string userId)
        {
            if (!Helpers.Helpers.IsValidId(userId))
                return null;

            string query = "SELECT Crews.abbreviation, Crews.fame, UsersCrews.crewId FROM UsersCrews, Crews WHERE UsersCrews.userId='" + userId.ToString()
                         + "' && Crews.crewId=UsersCrews.crewId;";
            List<CrewMembershipResponse> crews;
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                crews = dbContext.CrewsResponse
                    .FromSqlRaw<CrewMembershipResponse>(query)
                    .ToList<CrewMembershipResponse>();
            }
            return crews;
        }

        // Get members of a crew: retrieve id and name of users and fame and level
        public List<CrewMemberResponse> GetMembers(int crewId)
        {
            string query = "SELECT UserInfo.userId, UserInfo.fame, UserInfo.level, AspNetUsers.UserName FROM UsersCrews, UserInfo, AspNetUsers WHERE UsersCrews.crewId='" + crewId.ToString()
                         + "' && UserInfo.userId=UsersCrews.userId && AspNetUsers.Id=UserInfo.userId;";
            List<CrewMemberResponse> members;
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                members = dbContext.CrewMemberResponse
                    .FromSqlRaw<CrewMemberResponse>(query)
                    .ToList<CrewMemberResponse>();
            }
            return members;
        }

        public CrewInfoResponse GetCrewInfo(int crewId)
        {
            ///////// retrieve headId and name so that we can make a link with name rendered and headId in URL when we link to the head user
            /////head info will be displayed up top, but also in roster, in roster there is additonal info i.e. fame and level/rank
            string query = "SELECT Crews.crewId, Crews.description, Crews.fame, Crews.abbreviation, Crews.name, Crews.headId, AspNetUsers.UserName" 
                        + " FROM UsersCrews, Crews, AspNetUsers WHERE UsersCrews.crewId='" + crewId.ToString() + "' && Crews.headId=AspNetUsers.Id";

            List<CrewInfoResponse> crewInfo;
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                crewInfo = dbContext.CrewInfoResponse
                    .FromSqlRaw<CrewInfoResponse>(query)
                    .ToList<CrewInfoResponse>();
            }
            return crewInfo[0];
        }

        /*
        Crews have crewId because there can be crews with same name and same abbreviation.
        Just like in real life. There will be ways to differentiate, like often fame will be displayed right next to crew.

        A crew's fame will be determined by graff that is dedicated to the crew by members,
        and, in addition, once a week or night idk, it will be recalculated to include the sum of 20% of each member's fame

         */
    }
}