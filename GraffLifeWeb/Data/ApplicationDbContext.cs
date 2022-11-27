using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraffLifeWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Photo> UserPhotos { get; set; }
        public DbSet<PhotoResponse> UserPhotosResponse { get; set; } // holds UserName instead of userId
        public DbSet<PhotoResponse2> UserPhotosResponse2 { get; set; } // no username or id
        public DbSet<StringResponse> StringResponse { get; set; }
        public DbSet<UserInfoResponse> UserInfoResponse { get; set; }
        public DbSet<UserInfoResponse2> UserInfoResponse2 { get; set; }
        public DbSet<CrewInfoResponse> CrewInfoResponse { get; set; }
        public DbSet<CrewRankingResponse> CrewRankingResponse { get; set; }
        public DbSet<CrewMembershipResponse> CrewsResponse { get; set; }
        public DbSet<CrewMemberResponse> CrewMemberResponse { get; set; }
        public DbSet<CheckEmailResponse> CheckEmailResponse { get; set; }

    }

    // Verify whether or not email is dupe, just return the name so we check if anything was returned
    public class CheckEmailResponse
    {
        [Key]
        public string UserName { get; set; }
    }
}
