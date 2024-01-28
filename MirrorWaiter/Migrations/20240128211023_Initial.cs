using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MirrorWaiter.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    nick_name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    bio = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    link = table.Column<string>(type: "text", nullable: false),
                    profile_image = table.Column<string>(type: "text", nullable: false),
                    banner_image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profile");
        }
    }
}
