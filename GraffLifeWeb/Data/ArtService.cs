using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Data
{
    public class ArtService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public ArtService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public PhotoResponse2 GetArtAsync(int photoId)
        {
            string query = "SELECT UserPhotos.photo, UserPhotos.photoId, UserPhotos.fame, UserPhotos.date FROM UserPhotos WHERE UserPhotos.photoId = " + photoId.ToString() + ";";
            List<PhotoResponse2> photos;
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                photos = dbContext.UserPhotosResponse2
                    .FromSqlRaw<PhotoResponse2>(query)
                    .ToList<PhotoResponse2>();
            }
            return photos[0];
        }
    }
}