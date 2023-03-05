using DoctorWho.Db.DataModels;
using DoctorWho.Db.DBContext;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly DoctorWhoCoreDbContext context;

        public EpisodeRepository(DoctorWhoCoreDbContext context)
        {
            this.context = context ?? new DoctorWhoCoreDbContext();
        }
        public int Add(Episode episode)
        {
            context.Episodes.Add(episode);
            return context.SaveChanges();
        }

        public int Delete(int Id)
        {
            var episode = GetById(Id);

            if (episode != null)
            {
                context.Episodes.Remove(episode);
                return context.SaveChanges();
            }
            return 0;
        }

        public Episode GetById(int Id)
        {
            return context.Episodes.Find(Id);
        }

        public int Update(Episode episode)
        {
            var OldEpisode = GetById(episode.EpisodeId);

            if(OldEpisode != null)
            {
                OldEpisode.EpisodeNumber = episode.EpisodeNumber;
                OldEpisode.SeriesNumber = episode.SeriesNumber;
                OldEpisode.EpisodeType = episode.EpisodeType;
                OldEpisode.Title = episode.Title;
                OldEpisode.EpisodeDate = episode.EpisodeDate;
                OldEpisode.Notes = episode.Notes;
                OldEpisode.AuthorId = episode.AuthorId;
                OldEpisode.DoctorId = episode.DoctorId;
                return context.SaveChanges();
            }
            return 0;
        }

        public int AddEnemyToEpisode(int Id, Enemy Enemy)
        {
            var Episode = GetById(Id);

            Episode.Enemies.Add(Enemy);
            return context.SaveChanges();
        }

        public int AddCompanionToEpisode(int Id, Companion Companion)
        {
            var Episode = GetById(Id);

            Episode.Companions.Add(Companion);
            return context.SaveChanges();
        }
    }
}
