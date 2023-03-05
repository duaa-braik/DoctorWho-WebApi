namespace DoctorWho.Db.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetById(int id);
        public Task Add(T t);
        public Task Update(T t);
        public Task Delete(int Id);
    }
}
