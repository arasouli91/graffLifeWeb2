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

    public class TopArtService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public TopArtService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        /// TODO: Optimize to only return enough to display on one page at a time: LIMIT 0, 12 ... LIMIT 12, 12 ... LIMIT 24, 12.....
        ///   will need to have another method to return how count of photos in DB, so we know how many page navigation buttons to make... eventually we will always know that it is 1000 photos bcuz that's our max for top photo ranking
        public List<PhotoResponse> GetTopArtAsync()
        {
            List<PhotoResponse> photos;
            using (var scope = scopeFactory.CreateScope())
            {
                string query = "SELECT UserPhotos.photo, UserPhotos.photoId, UserPhotos.fame, AspNetUsers.UserName FROM UserPhotos, AspNetUsers"
                             + " WHERE fame > 0 && AspNetUsers.Id = UserPhotos.userId ORDER BY fame DESC LIMIT 1000;";
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                photos = dbContext.UserPhotosResponse
                    .FromSqlRaw<PhotoResponse>(query)
                    .ToList<PhotoResponse>();
            }
            return photos;
        }

        public List<PhotoResponse2> GetMyArtAsync(string userId, bool isRecent = false)
        {
            if (userId.Length == 0 || !Helpers.Helpers.IsValidId(userId))
            {
                return null;
            }
            string query = "SELECT UserPhotos.photo, UserPhotos.photoId, UserPhotos.date, UserPhotos.fame FROM UserPhotos WHERE UserPhotos.userId = '" 
                + userId + (isRecent ? "' ORDER BY timestamp DESC;" : "' ORDER BY fame DESC;");
            List<PhotoResponse2> photos;
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                photos = dbContext.UserPhotosResponse2
                    .FromSqlRaw<PhotoResponse2>(query)
                    .ToList<PhotoResponse2>();
            }
            return photos;
        }
    }
}

/*
return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Photo
{
    fame = 0,
    photo = null,
    photoId = 23523235,
    userId = "@#$234234"
}).ToArray());*/