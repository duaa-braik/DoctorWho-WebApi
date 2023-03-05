using DoctorWho.Db.DataModels;
using DoctorWho.Db.DBContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorWhoCoreDbContext context;

        public DoctorRepository(DoctorWhoCoreDbContext context)
        {
            this.context = context ?? new DoctorWhoCoreDbContext();
        }
        public async Task Add(Doctor doctor)
        {
            context.Doctors.Add(doctor);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var doctor = await GetDoctorWithEpisodes(Id);

            if (doctor != null)
            {
                context.Doctors.Remove(doctor);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Doctor> GetById(int Id)
        {
            return await context.Doctors.FindAsync(Id);
        }

        public async Task Update(Doctor doctor)
        {
            var OldDoctor = await GetById(doctor.DoctorId);

            if (OldDoctor != null)
            {
                OldDoctor.DoctorNumber = doctor.DoctorNumber;
                OldDoctor.DoctorName = doctor.DoctorName;
                OldDoctor.BirthDate = doctor.BirthDate;
                OldDoctor.FirstEpisodeDate = doctor.FirstEpisodeDate;
                OldDoctor.LastEpisodeDate = doctor.LastEpisodeDate;
                await context.SaveChangesAsync();
            }
        }

        public async Task<Doctor> GetDoctorWithEpisodes(int Id)
        {
            return await context.Doctors
                .Include(d => d.Episodes)
                .FirstOrDefaultAsync(d => d.DoctorId == Id);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await context.Doctors.ToListAsync();
        }
    }
}
