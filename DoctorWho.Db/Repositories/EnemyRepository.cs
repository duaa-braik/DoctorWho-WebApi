using DoctorWho.Db.DataModels;
using DoctorWho.Db.DBContext;

namespace DoctorWho.Db.Repositories
{
    public class EnemyRepository : IEnemyRepository
    {
        private readonly DoctorWhoCoreDbContext context;

        public EnemyRepository(DoctorWhoCoreDbContext context)
        {
            this.context = context ?? new DoctorWhoCoreDbContext();
        }
        public int Add(Enemy enemy)
        {
            //context.Enemies.Add(enemy);
            context.Set<Enemy>().Add(enemy);
            return context.SaveChanges();
        }

        public int Delete(int Id)
        {
            var enemy = GetById(Id);

            if (enemy != null)
            {
                context.Enemies.Remove(enemy);
                return context.SaveChanges();
            }
            return 0;
        }

        public Enemy GetById(int Id)
        {
            return context.Enemies.Find(Id);
        }

        public int Update(Enemy enemy)
        {
            var OldEnemy = GetById(enemy.EnemyId);

            if (enemy != null)
            {
                OldEnemy.EnemyName = enemy.EnemyName;
                OldEnemy.Description = enemy.Description;

                return context.SaveChanges();
            }
            return 0;
        }
    }
}
