using DoctorWho.Db.DBContext;

namespace DoctorWho.Db.DataModels
{
    public class Episode
    {
        private DoctorWhoCoreDbContext context;

        public Episode() { 
            context = new DoctorWhoCoreDbContext();
        }
        public Episode(DoctorWhoCoreDbContext Context)
        {
            Companions = new List<Companion>();
            Enemies = new List<Enemy>();

            context = Context ?? new DoctorWhoCoreDbContext();
        }

        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public EpisodeType EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public string? Notes { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public List<Companion> Companions { get; set; }
        public List<Enemy> Enemies { get; set; }

        private Episode episode;

        public Episode GetById(int Id)
        {
            return context.Episodes.Find(Id);
        }

        public int Add(Episode Episode)
        {
            episode = Episode;
            
            context.Episodes.Add(episode);
            return context.SaveChanges();
        }

        public int Delete(int Id)
        {
            episode = GetById(Id);

            if(episode != null)
            {
                context.Episodes.Remove(episode);
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
