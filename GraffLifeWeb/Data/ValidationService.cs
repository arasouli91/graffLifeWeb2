using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Data
{
    public class ValidationService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public ValidationService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        } 

        // Checks DB for dupe email. Assumes other email validation has already occured.
        public bool ValidateEmail(string email)
        {
            string query = $"SELECT AspNetUsers.UserName FROM AspNetUsers WHERE AspNetUsers.Email='{email}';";
            bool isValidEmail = true;
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                isValidEmail = dbContext.CheckEmailResponse
                    .FromSqlRaw<CheckEmailResponse>(query)
                    .ToList<CheckEmailResponse>().Count == 0;
            }
            return isValidEmail;
        }
    }
}