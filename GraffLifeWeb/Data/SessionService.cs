using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using GraffLifeWeb.Helpers;

namespace GraffLifeWeb.Data
{
    public class SessionService
    {
        private string UserId { get; set; }
        private readonly IServiceScopeFactory scopeFactory;

        public SessionService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        // Get the UserId from current session, but if pass in false, then you get any UserId
        public string GetUserId(string username, bool isCurrent = true)
        {
            if (isCurrent && UserId != null)
                return UserId;
            string retId = string.Empty;
            if(username.Length > 0 && Helpers.Helpers.IsAlphaNumeric(username)) // retrieve id
            {
                // Get Id from DB
                using (var scope = scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    string query = "SELECT AspNetUsers.Id FROM AspNetUsers WHERE AspNetUsers.UserName = '" + username + "';";
                    var userId = dbContext.StringResponse
                        .FromSqlRaw<StringResponse>(query).ToList();
                    if (userId.Count == 0)
                    {
                        return string.Empty;
                    }
                    retId = userId.First().Id;
                    if (isCurrent)
                        UserId = userId.First().Id; // set session's userId
                }
            }
            return retId;
        }
    }
}
