using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HepsiSef.DAL.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    ParentID = table.Column<Guid>(nullable: true),
                    ShowOnMenu = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Newsletter",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalLogin",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    ProviderName = table.Column<int>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalLogin_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForgatPassword",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgatPassword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForgatPassword_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    ServiceCount = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    PrepareTime = table.Column<int>(nullable: false),
                    CookingTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipe_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookmark",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    RecipeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookmark_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookmark_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    RecipeID = table.Column<Guid>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeCategory_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    RecipeID = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ISCover = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeImage_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    RecipeID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeRate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    RecipeID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeRate_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RecordStatus = table.Column<int>(nullable: false),
                    RecipeID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Step_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_RecipeID",
                table: "Bookmark",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_UserID",
                table: "Bookmark",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalLogin_UserID",
                table: "ExternalLogin",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ForgatPassword_UserID",
                table: "ForgatPassword",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserID",
                table: "Recipe",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategory_CategoryID",
                table: "RecipeCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategory_RecipeID",
                table: "RecipeCategory",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeImage_RecipeID",
                table: "RecipeImage",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeID",
                table: "RecipeIngredient",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRate_RecipeID",
                table: "RecipeRate",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Step_RecipeID",
                table: "Step",
                column: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmark");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "ExternalLogin");

            migrationBuilder.DropTable(
                name: "ForgatPassword");

            migrationBuilder.DropTable(
                name: "Newsletter");

            migrationBuilder.DropTable(
                name: "RecipeCategory");

            migrationBuilder.DropTable(
                name: "RecipeImage");

            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "RecipeRate");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
