using DoctorWho.Db.DataModels;

namespace DoctorWho.Db.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorWithEpisodes(int Id);
    }
}