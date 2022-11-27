using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Data
{
    public class UserInfoService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public UserInfoService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public UserInfoResponse GetUserInfoAsync(string userId)
        {
            if (!Helpers.Helpers.IsValidId(userId))
                return null;

            string query = "SELECT UserInfo.avatar, UserInfo.fame, UserInfo.level, UserInfo.memberSince FROM UserInfo WHERE UserInfo.userId='" + userId + "';";
            List<UserInfoResponse> userInfo;
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                userInfo = dbContext.UserInfoResponse
                    .FromSqlRaw<UserInfoResponse>(query)
                    .ToList<UserInfoResponse>();
            }
            return userInfo[0];
        }

        // Not yet a usable function, needs to accept info to update.
        public void UpdateUserInfo(string username)
        {
            if (!Helpers.Helpers.IsAlphaNumeric(username))
                return;

            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.ExecuteSqlRaw("INSERT INTO `grafflife`.`UserInfo` (`userId`, `fame`, `level`, `memberSince`) VALUES ('7335f761-108f-45e3-a6ea-1094bcb11642', '1', '1', '2008-01-01 00:00:01');");
            }
        }
    }
}