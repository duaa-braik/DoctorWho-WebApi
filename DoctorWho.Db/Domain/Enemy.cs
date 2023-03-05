using DoctorWho.Db.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.DataModels
{
    public class Enemy
    {
        private Enemy enemy;
        private DoctorWhoCoreDbContext context;

        public Enemy() {
            context = new DoctorWhoCoreDbContext();
        }
        public Enemy(DoctorWhoCoreDbContext Context)
        {
            Episodes = new List<Episode>();

            context = Context ?? new DoctorWhoCoreDbContext();

        }

        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string? Description { get; set; }

        public List<Episode> Episodes { get; set; }

        public int CreateEnemy(string EnemyName)
        {
            enemy = new Enemy()
            {
                EnemyName = EnemyName
            };
            context.Add(enemy);
            return context.SaveChanges();
        }

        public int UpdateEnemy(int EnemyId, string EnemyName, [Optional] string Description)
        {
            enemy = GetEnemyById(EnemyId, context);

            if (enemy != null)
            {
                if (!string.IsNullOrEmpty(EnemyName))
                {
                    enemy.EnemyName = EnemyName;
                }
                if (!string.IsNullOrEmpty(Description))
                {
                    enemy.Description = Description;
                }
                return context.SaveChanges();
            }
            return 0;

        }

        public int DeleteEnemy(int EnemyId)
        {
            
            enemy = GetEnemyById(EnemyId, context);

            if (enemy != null)
            {
                context.Enemies.Remove(enemy);
                return context.SaveChanges();
            }
            return 0;
        }

        private Enemy GetEnemyById(int EnemyId, DoctorWhoCoreDbContext context)
        {
            return context.Enemies.Find(EnemyId);
        }
    }
}
