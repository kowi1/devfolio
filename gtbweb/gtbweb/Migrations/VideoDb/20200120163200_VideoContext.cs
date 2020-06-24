using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gtbweb.Migrations.VideoDb
{
    public partial class VideoContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryArchives",
                columns: table => new
                {
                    CategoryArchiveID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryArchives", x => x.CategoryArchiveID);
                });

            migrationBuilder.CreateTable(
                name: "DateArchives",
                columns: table => new
                {
                    DateArchiveID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateArchiveName = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateArchives", x => x.DateArchiveID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Designation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    ServiceDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    VideoID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VideoTitle = table.Column<string>(nullable: true),
                    VideoFormat = table.Column<string>(nullable: true),
                    VideoLength = table.Column<DateTime>(nullable: false),
                    VideoFilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.VideoID);
                });

            migrationBuilder.CreateTable(
                name: "Archives",
                columns: table => new
                {
                    ArchiveID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateArchiveID = table.Column<int>(nullable: false),
                    CategoryArchiveID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archives", x => x.ArchiveID);
                    table.ForeignKey(
                        name: "FK_Archives_CategoryArchives_CategoryArchiveID",
                        column: x => x.CategoryArchiveID,
                        principalTable: "CategoryArchives",
                        principalColumn: "CategoryArchiveID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Archives_DateArchives_DateArchiveID",
                        column: x => x.DateArchiveID,
                        principalTable: "DateArchives",
                        principalColumn: "DateArchiveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileID = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ReplyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ReplyID",
                        column: x => x.ReplyID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proficiencies",
                columns: table => new
                {
                    ProficiencyID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileID = table.Column<int>(nullable: false),
                    SkillID = table.Column<int>(nullable: true),
                    PercentageScore = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proficiencies", x => x.ProficiencyID);
                    table.ForeignKey(
                        name: "FK_Proficiencies_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proficiencies_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoCollections",
                columns: table => new
                {
                    VideoCollectionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileID = table.Column<int>(nullable: false),
                    VideoID = table.Column<int>(nullable: false),
                    CreativePurpose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCollections", x => x.VideoCollectionID);
                    table.ForeignKey(
                        name: "FK_VideoCollections_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCollections_Video_VideoID",
                        column: x => x.VideoID,
                        principalTable: "Video",
                        principalColumn: "VideoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPages",
                columns: table => new
                {
                    BlogPageID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: false),
                    DateArchiveID = table.Column<int>(nullable: false),
                    CategoryArchiveID = table.Column<int>(nullable: false),
                    HeaderTitle = table.Column<string>(nullable: true),
                    HeaderImage = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    CommentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPages", x => x.BlogPageID);
                    table.ForeignKey(
                        name: "FK_BlogPages_CategoryArchives_CategoryArchiveID",
                        column: x => x.CategoryArchiveID,
                        principalTable: "CategoryArchives",
                        principalColumn: "CategoryArchiveID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPages_Comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPages_DateArchives_DateArchiveID",
                        column: x => x.DateArchiveID,
                        principalTable: "DateArchives",
                        principalColumn: "DateArchiveID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPages_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPages_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCollections",
                columns: table => new
                {
                    ServiceCollectionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceID = table.Column<int>(nullable: false),
                    ProficiencyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCollections", x => x.ServiceCollectionID);
                    table.ForeignKey(
                        name: "FK_ServiceCollections_Proficiencies_ProficiencyID",
                        column: x => x.ProficiencyID,
                        principalTable: "Proficiencies",
                        principalColumn: "ProficiencyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceCollections_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogCollections",
                columns: table => new
                {
                    BlogCollectionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileID = table.Column<int>(nullable: false),
                    BlogPageID = table.Column<int>(nullable: false),
                    ArchiveID = table.Column<int>(nullable: false),
                    PersonalStatement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCollections", x => x.BlogCollectionID);
                    table.ForeignKey(
                        name: "FK_BlogCollections_Archives_ArchiveID",
                        column: x => x.ArchiveID,
                        principalTable: "Archives",
                        principalColumn: "ArchiveID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCollections_BlogPages_BlogPageID",
                        column: x => x.BlogPageID,
                        principalTable: "BlogPages",
                        principalColumn: "BlogPageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCollections_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archives_CategoryArchiveID",
                table: "Archives",
                column: "CategoryArchiveID");

            migrationBuilder.CreateIndex(
                name: "IX_Archives_DateArchiveID",
                table: "Archives",
                column: "DateArchiveID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCollections_ArchiveID",
                table: "BlogCollections",
                column: "ArchiveID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCollections_BlogPageID",
                table: "BlogCollections",
                column: "BlogPageID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCollections_ProfileID",
                table: "BlogCollections",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPages_CategoryArchiveID",
                table: "BlogPages",
                column: "CategoryArchiveID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPages_CommentID",
                table: "BlogPages",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPages_DateArchiveID",
                table: "BlogPages",
                column: "DateArchiveID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPages_ProfileID",
                table: "BlogPages",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPages_TagID",
                table: "BlogPages",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProfileID",
                table: "Comments",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReplyID",
                table: "Comments",
                column: "ReplyID");

            migrationBuilder.CreateIndex(
                name: "IX_Proficiencies_ProfileID",
                table: "Proficiencies",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Proficiencies_SkillID",
                table: "Proficiencies",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCollections_ProficiencyID",
                table: "ServiceCollections",
                column: "ProficiencyID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCollections_ServiceID",
                table: "ServiceCollections",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCollections_ProfileID",
                table: "VideoCollections",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCollections_VideoID",
                table: "VideoCollections",
                column: "VideoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCollections");

            migrationBuilder.DropTable(
                name: "ServiceCollections");

            migrationBuilder.DropTable(
                name: "VideoCollections");

            migrationBuilder.DropTable(
                name: "Archives");

            migrationBuilder.DropTable(
                name: "BlogPages");

            migrationBuilder.DropTable(
                name: "Proficiencies");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "CategoryArchives");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DateArchives");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
