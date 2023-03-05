using DoctorWho.Db.DataModels;

namespace DoctorWho.Db.Repositories
{
    public interface IEpisodeRepository : IRepository<Episode>
    {
        int AddCompanionToEpisode(int Id, Companion Companion);
        int AddEnemyToEpisode(int Id, Enemy Enemy);
    }
}