using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class SeedJoinTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CompanionEpisode",
                columns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                values: new object[,]
                {
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 5 },
                    { 7, 6 },
                    { 8, 3 },
                    { 9, 4 },
                    { 10, 5 }
                });

            migrationBuilder.InsertData(
                table: "EnemyEpisode",
                columns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                values: new object[,]
                {
                    { 6, 2 },
                    { 7, 3 },
                    { 8, 4 },
                    { 9, 5 },
                    { 11, 5 },
                    { 12, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "CompanionEpisode",
                keyColumns: new[] { "CompanionsCompanionId", "EpisodesEpisodeId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "EnemyEpisode",
                keyColumns: new[] { "EnemiesEnemyId", "EpisodesEpisodeId" },
                keyValues: new object[] { 12, 6 });
        }
    }
}
