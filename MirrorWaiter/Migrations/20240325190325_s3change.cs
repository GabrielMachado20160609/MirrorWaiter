using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MirrorWaiter.Migrations
{
    /// <inheritdoc />
    public partial class s3change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profile_image",
                table: "profile",
                newName: "profile_image_s3_key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profile_image_s3_key",
                table: "profile",
                newName: "profile_image");
        }
    }
}
