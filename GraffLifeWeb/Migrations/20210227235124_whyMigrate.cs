using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraffLifeWeb.Migrations
{
    public partial class whyMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.CreateTable(
                name: "CrewInfoResponse",
                columns: table => new
                {
                    crewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    headId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    abbreviation = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    fame = table.Column<ulong>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewInfoResponse", x => x.crewId);
                });

            migrationBuilder.CreateTable(
                name: "CrewMemberResponse",
                columns: table => new
                {
                    userId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    fame = table.Column<ulong>(nullable: false),
                    level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMemberResponse", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "CrewsResponse",
                columns: table => new
                {
                    crewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    abbreviation = table.Column<string>(nullable: true),
                    fame = table.Column<ulong>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewsResponse", x => x.crewId);
                });

            migrationBuilder.CreateTable(
                name: "StringResponse",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfoResponse",
                columns: table => new
                {
                    fame = table.Column<ulong>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    memberSince = table.Column<DateTime>(nullable: false),
                    avatar = table.Column<byte[]>(nullable: true),
                    level = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfoResponse", x => x.fame);
                });

            migrationBuilder.CreateTable(
                name: "UserPhotos",
                columns: table => new
                {
                    photoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    photo = table.Column<byte[]>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    fame = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotos", x => x.photoId);
                });

            migrationBuilder.CreateTable(
                name: "UserPhotosResponse",
                columns: table => new
                {
                    photoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    photo = table.Column<byte[]>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    fame = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotosResponse", x => x.photoId);
                });

            migrationBuilder.CreateTable(
                name: "UserPhotosResponse2",
                columns: table => new
                {
                    photoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    photo = table.Column<byte[]>(nullable: true),
                    fame = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotosResponse2", x => x.photoId);
                });
        */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropTable(
                name: "CrewInfoResponse");

            migrationBuilder.DropTable(
                name: "CrewMemberResponse");

            migrationBuilder.DropTable(
                name: "CrewsResponse");

            migrationBuilder.DropTable(
                name: "StringResponse");

            migrationBuilder.DropTable(
                name: "UserInfoResponse");

            migrationBuilder.DropTable(
                name: "UserPhotos");

            migrationBuilder.DropTable(
                name: "UserPhotosResponse");

            migrationBuilder.DropTable(
                name: "UserPhotosResponse2");
        */
        }
    }
}
