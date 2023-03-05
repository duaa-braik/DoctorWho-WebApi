using DoctorWho.Db.DataModels;
using DoctorWho.Db.DBContext;

namespace DoctorWho.Db.Repositories
{
    public class CompanionRepository : ICompanionRepository
    {
        private readonly DoctorWhoCoreDbContext context;

        public CompanionRepository(DoctorWhoCoreDbContext context)
        {
            this.context = context ?? new DoctorWhoCoreDbContext();
        }
        public int Add(Companion companion)
        {
            context.Companions.Add(companion);
            return context.SaveChanges();
        }

        public int Delete(int Id)
        {
            var companion = GetById(Id);

            if (companion != null)
            {
                context.Companions.Remove(companion);
                return context.SaveChanges();
            }
            return 0;
        }

        public Companion GetById(int Id)
        {
            return context.Companions.Find(Id);
        }

        public int Update(Companion companion)
        {
            var OldCompanion = GetById(companion.CompanionId);

            if (OldCompanion != null)
            {
                OldCompanion.CompanionName = companion.CompanionName;
                OldCompanion.WhoPlayed = companion.WhoPlayed;

                return context.SaveChanges();
            }
            return 0;
        }
    }
}
