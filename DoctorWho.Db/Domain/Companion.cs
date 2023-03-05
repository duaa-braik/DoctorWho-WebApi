using DoctorWho.Db.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.DataModels
{
    public class Companion
    {
        private readonly DoctorWhoCoreDbContext context;

        public Companion() {
            context = new DoctorWhoCoreDbContext();
        }
        public Companion(DoctorWhoCoreDbContext Context)
        {
            Episodes = new List<Episode>();

            context = Context ?? new DoctorWhoCoreDbContext();
        }

        public int CompanionId { get; set; }
        public string CompanionName { get; set; }
        public string? WhoPlayed { get; set; }

        public List<Episode> Episodes { get; set; }

        private Companion companion;

        public int Add(string CompanionName, string WhoPlayed)
        {
            companion = new Companion
            {
                CompanionName = CompanionName,
                WhoPlayed = WhoPlayed
            };

            context.Companions.Add(companion);
            return context.SaveChanges();
        }

        public int Update(int Id, string Name, [Optional] string WhoPlayed)
        {
            companion = GetById(Id, context);

            if(companion != null)
            {
                companion.CompanionName = Name;
                if (!string.IsNullOrEmpty(WhoPlayed))
                {
                    companion.WhoPlayed = WhoPlayed;
                }
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int Id)
        {
            companion = GetById(Id, context);

            if(companion != null)
            {
                context.Companions.Remove(companion);
                return context.SaveChanges();
            }
            return 0;   
        }

        public Companion GetById(int Id, DoctorWhoCoreDbContext context)
        {
            return context.Companions.Find(Id);
        }
    }
}
