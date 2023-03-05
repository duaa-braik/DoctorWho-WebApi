using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class AddFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"create function fnEnemies (@EpisodeId int)
                    returns varchar(max)
                    as begin
	
	                    Declare @enemiesList Varchar(MAX)

	                    select @enemiesList = COALESCE(@enemiesList + ', ' + enemy.EnemyName, enemy.EnemyName) 
	                    from EnemyEpisode ee
	                    inner join Enemies enemy
	                    on enemy.EnemyId = ee.EnemiesEnemyId
	                    where ee.EpisodesEpisodeId = @EpisodeId
	
                    	return (select @enemiesList as enemies)
                    end"
                );

            migrationBuilder.Sql(
                @"create function dbo.fnCompanions (@EpisodeId int)
                    returns varchar(max)
                    as 
                    begin

	                    Declare @companionsList Varchar(MAX)

	                    Select @companionsList = COALESCE(@companionsList + ', ' + companion.CompanionName, companion.CompanionName) 
	                    From Companions companion 
	                    inner join CompanionEpisode ec
	                    on ec.CompanionsCompanionId = companion.CompanionId
	                    where ec.EpisodesEpisodeId = @EpisodeId
	                    return (Select @companionsList as companions)
	
                    end"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "drop function fnCompanions");
            migrationBuilder.Sql(
                "drop function fnEnemies");
        }
    }
}
