using DoctorWho.Db.DataModels;

namespace DoctorWho.Db.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorWithEpisodes(int id);
    }
}