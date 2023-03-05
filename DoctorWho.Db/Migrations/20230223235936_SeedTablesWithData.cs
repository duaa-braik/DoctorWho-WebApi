using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class SeedTablesWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WhoPlayed",
                table: "Companions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 23, "Russell T Davies" },
                    { 29, "Robert Shearman" },
                    { 30, "Steven Moffat" },
                    { 32, "James Moran" },
                    { 35, "Terry Nation" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 7, "Rose Tyler", null },
                    { 8, "Adam Mitchell", null },
                    { 9, "Jack Harkness", null },
                    { 10, "Mickey Smith", null }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, null, "William Hartnell", 1, new DateTime(1966, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1966, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, "Patrick Troughton", 2, new DateTime(1966, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1969, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, "Jon Pertwee", 3, new DateTime(1970, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, null, "Christopher Eccleston", 9, new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, null, "David Tennant", 10, new DateTime(2005, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 6, null, "Lady Cassandra" },
                    { 7, null, "Metaltron" },
                    { 8, null, "Empty Child" },
                    { 9, null, "Clockword Droid" },
                    { 11, null, "Control Node" },
                    { 12, null, "The Beast" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 2, 23, 9, new DateTime(2005, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Episode", null, 1, "The End of the World" },
                    { 3, 29, 9, new DateTime(2005, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Episode", null, 1, "Dalek" },
                    { 4, 30, 9, new DateTime(2005, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Episode", null, 1, "The Doctor Dances" },
                    { 5, 30, 10, new DateTime(2006, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Episode", null, 2, "The Girl in the Fireplace" },
                    { 6, 32, 10, new DateTime(2006, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Episode", null, 2, "The Satan Pit" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "WhoPlayed",
                table: "Companions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
