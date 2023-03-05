using DoctorWho.Db.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DoctorWho.Db.DBContext
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<ViewEpisodes> ViewEpisodes { get; set; }

        private void GetConnectionString(out string ConnectionString)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            ConnectionString = config["ConnectionString:Connection"];
        }

        public DoctorWhoCoreDbContext()
        {
        }

        public DoctorWhoCoreDbContext(DbContextOptions<DoctorWhoCoreDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    GetConnectionString(out string ConnectionString);
            //    optionsBuilder.UseSqlServer(ConnectionString);
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).HasConversion<string>();
            var Enemies = SeedEnemies();
            var Authors = SeedAuthors(); // 23, 29, 30, 32, 35
            var Companions = SeedCompanions();
            var Doctors = SeedDoctors();
            var Episodes = SeedEpisodes();

            var EnemiesEpisodes = SeedEnemiesEpisodes();
            var CompanionsEpisodes = SeedCompanionsEpisodes();

            modelBuilder.Entity<Enemy>().HasData(Enemies);
            modelBuilder.Entity<Author>().HasData(Authors);
            modelBuilder.Entity<Companion>().HasData(Companions);
            modelBuilder.Entity<Doctor>().HasData(Doctors);
            modelBuilder.Entity<Episode>().HasData(Episodes);

            modelBuilder.Entity<Episode>()
                .HasMany(e => e.Enemies)
                .WithMany(e => e.Episodes)
                .UsingEntity(ee => ee.HasData(EnemiesEpisodes));

            modelBuilder.Entity<Episode>()
                .HasMany(e => e.Companions)
                .WithMany(c => c.Episodes)
                .UsingEntity(ec => ec.HasData(CompanionsEpisodes));

            modelBuilder.HasDbFunction(
                typeof(DoctorWhoCoreDbContext)
                .GetMethod(nameof(PrintCompanions), new[] { typeof(int) })
                ).HasName("fnCompanions");

            modelBuilder.HasDbFunction(
                typeof(DoctorWhoCoreDbContext)
                .GetMethod(nameof(PrintEnemies), new[] { typeof(int) })
                ).HasName("fnEnemies");

            modelBuilder.Entity<ViewEpisodes>()
                .HasNoKey()
                .ToView("viewEpisodes");

            modelBuilder.Entity<Enemy>()
                .Property(e => e.EnemyId).UseIdentityColumn();
            modelBuilder.Entity<Companion>()
                .Property(c => c.CompanionId).UseIdentityColumn();
            modelBuilder.Entity<Episode>()
                .Property(e => e.EpisodeId).UseIdentityColumn();
            modelBuilder.Entity<Doctor>()
                .Property(d => d.DoctorId).UseIdentityColumn();
            modelBuilder.Entity<Author>()
                .Property(a => a.AuthorId).UseIdentityColumn();

        }

        public string PrintCompanions(int EpisodeId)
                => throw new NotImplementedException();

        public string PrintEnemies(int EpisodeId)
                => throw new NotImplementedException();

        private List<object> SeedCompanionsEpisodes()
        {
            var CompanionsEpisodes = new List<object>()
            {
                new { CompanionsCompanionId = 7, EpisodesEpisodeId = 2},
                new { CompanionsCompanionId = 7, EpisodesEpisodeId = 3},
                new { CompanionsCompanionId = 8, EpisodesEpisodeId = 3},
                new { CompanionsCompanionId = 7, EpisodesEpisodeId = 4},
                new { CompanionsCompanionId = 9, EpisodesEpisodeId = 4},
                new { CompanionsCompanionId = 7, EpisodesEpisodeId = 5},
                new { CompanionsCompanionId = 10, EpisodesEpisodeId = 5},
                new { CompanionsCompanionId = 7, EpisodesEpisodeId = 6},

            };

            return CompanionsEpisodes;
        }

        private List<object> SeedEnemiesEpisodes()
        {
            var EnemiesEpisodes = new List<object>()
            {
                new { EnemiesEnemyId = 6, EpisodesEpisodeId = 2},
                new { EnemiesEnemyId = 7, EpisodesEpisodeId = 3},
                new { EnemiesEnemyId = 8, EpisodesEpisodeId = 4},
                new { EnemiesEnemyId = 9, EpisodesEpisodeId = 5},
                new { EnemiesEnemyId = 11, EpisodesEpisodeId = 5},
                new { EnemiesEnemyId = 12, EpisodesEpisodeId = 6},

            };
            return EnemiesEpisodes;
        }

        private List<Companion> SeedCompanions()
        {
            List<Companion> companions = new List<Companion>()
            {
                new Companion { CompanionId = 7, CompanionName = "Rose Tyler"},
                new Companion { CompanionId = 8, CompanionName = "Adam Mitchell"},
                new Companion { CompanionId = 9, CompanionName = "Jack Harkness"},
                new Companion { CompanionId = 10, CompanionName = "Mickey Smith"},

            };
            return companions;
        }

        private List<Doctor> SeedDoctors()
        {
            var doctors = new List<Doctor>()
            {
                new Doctor { DoctorId = 1, DoctorNumber = 1, DoctorName = "William Hartnell", FirstEpisodeDate = new DateTime(1966, 9, 23), LastEpisodeDate = new DateTime(1966, 10, 29) },
                new Doctor { DoctorId = 2, DoctorNumber = 2, DoctorName = "Patrick Troughton", FirstEpisodeDate = new DateTime(1966, 11, 5), LastEpisodeDate = new DateTime(1969, 6, 21) },
                new Doctor { DoctorId = 3, DoctorNumber = 3, DoctorName = "Jon Pertwee", FirstEpisodeDate = new DateTime(1970, 1, 3), LastEpisodeDate = new DateTime(1974, 6, 8) },
                new Doctor { DoctorId = 9, DoctorNumber = 9, DoctorName = "Christopher Eccleston", FirstEpisodeDate = new DateTime(2005, 3, 26), LastEpisodeDate = new DateTime(2005, 6, 18) },
                new Doctor { DoctorId = 10, DoctorNumber = 10, DoctorName = "David Tennant", FirstEpisodeDate = new DateTime(2005, 12, 25), LastEpisodeDate = new DateTime(2010, 1, 1) },

            };
            return doctors;
        }

        private List<Author> SeedAuthors()
        {
            var authors = new List<Author>()
            {
                new Author { AuthorId = 23, AuthorName = "Russell T Davies"},
                new Author { AuthorId = 29, AuthorName = "Robert Shearman"},
                new Author { AuthorId = 30, AuthorName = "Steven Moffat"},
                new Author { AuthorId = 32, AuthorName = "James Moran"},
                new Author { AuthorId = 35, AuthorName = "Terry Nation"},

            };
            return authors;
        }

        private List<Enemy> SeedEnemies()
        {
            var enemies = new List<Enemy>()
            {
                new Enemy { EnemyId = 6, EnemyName = "Lady Cassandra"},
                new Enemy { EnemyId = 7, EnemyName = "Metaltron"},
                new Enemy { EnemyId = 8, EnemyName = "Empty Child"},
                new Enemy { EnemyId = 9, EnemyName = "Clockword Droid"},
                new Enemy { EnemyId = 11, EnemyName = "Control Node"},
                new Enemy { EnemyId = 12, EnemyName = "The Beast"},
            };
            return enemies;
        }

        private List<Episode> SeedEpisodes()
        {
            List<Episode> episodes = new List<Episode>()
            {
                new Episode { 
                    EpisodeId = 2, 
                    SeriesNumber = 1, 
                    Title = "The End of the World", 
                    EpisodeDate = new DateTime(2005, 4, 2),
                    AuthorId = 23,
                    DoctorId = 9,
                    EpisodeNumber = 2,
                    EpisodeType = EpisodeType.Episode,
                },
                new Episode {
                    EpisodeId = 3,
                    SeriesNumber = 1,
                    Title = "Dalek",
                    EpisodeDate = new DateTime(2005, 4, 30),
                    AuthorId = 29,
                    DoctorId = 9,
                    EpisodeNumber = 6,
                    EpisodeType = EpisodeType.Episode,
                },
                new Episode {
                    EpisodeId = 4,
                    SeriesNumber = 1,
                    Title = "The Doctor Dances",
                    EpisodeDate = new DateTime(2005, 5, 25),
                    AuthorId = 30,
                    DoctorId = 9,
                    EpisodeNumber = 10,
                    EpisodeType = EpisodeType.Episode
                },
                new Episode {
                    EpisodeId = 5,
                    SeriesNumber = 2,
                    Title = "The Girl in the Fireplace",
                    EpisodeDate = new DateTime(2006, 5, 6),
                    AuthorId = 30,
                    DoctorId = 10,
                    EpisodeNumber = 4,
                    EpisodeType = EpisodeType.Episode
                },
                new Episode {
                    EpisodeId = 6,
                    SeriesNumber = 2,
                    Title = "The Satan Pit",
                    EpisodeDate = new DateTime(2006, 6, 10),
                    AuthorId = 32,
                    DoctorId = 10,
                    EpisodeNumber = 9,
                    EpisodeType = EpisodeType.Episode
                },
            };
            return episodes;
        }
    }
}