using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class CreateView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"create view viewEpisodes as (
	                select E.Title, author.AuthorName, doctor.DoctorName, dbo.fnCompanions(E.EpisodeId) as Companions, dbo.fnEnemies(E.EpisodeId) as Enemies
	                from Authors author
	                inner join Episodes E
	                on E.AuthorId = author.AuthorId
	                inner join Doctors doctor
	                on doctor.DoctorId = E.DoctorId
                )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "drop view viewEpisodes");
        }
    }
}
