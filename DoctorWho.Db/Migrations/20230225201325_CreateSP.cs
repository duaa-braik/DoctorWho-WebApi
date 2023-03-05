using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class CreateSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"create procedure spSummariseEpisodes
                    as 

                    select distinct top(3) companion.CompanionName, count(*) over(partition by companion.CompanionName) as Appearance
                    from Companions companion
                    inner join CompanionEpisode ec
                    on companion.CompanionId = ec.CompanionsCompanionId
                    order by Appearance desc

                    select distinct top(3) enemy.EnemyName, count(*) over(partition by enemy.EnemyName) as Appearance
                    from Enemies enemy
                    inner join EnemyEpisode ec
                    on enemy.EnemyId = ec.EnemiesEnemyId
                    order by Appearance desc"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop procedure spSummariseEpisodes");
        }
    }
}
