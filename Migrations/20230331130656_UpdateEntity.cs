using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "videogames",
                newName: "Release_Date");

            migrationBuilder.RenameColumn(
                name: "HouseId",
                table: "videogames",
                newName: "Software_house_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Software_house_id",
                table: "videogames",
                newName: "HouseId");

            migrationBuilder.RenameColumn(
                name: "Release_Date",
                table: "videogames",
                newName: "ReleaseDate");
        }
    }
}
