using DoctorWho.Db.DBContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.DataModels
{
    public class Author
    {
        private DoctorWhoCoreDbContext context;

        public Author() { }
        public Author(DoctorWhoCoreDbContext Context)
        {
            Episodes = new List<Episode>();

            context = Context ?? new DoctorWhoCoreDbContext();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public List<Episode> Episodes { get; set; }

        private Author author;

        public Author GetById(int Id)
        {
            return context.Authors.Find(Id);
        }

        private Author GetAuthorWithEpisodes(int Id)
        {
            return context.Authors
                .Include(a => a.Episodes)
                .FirstOrDefault(a => a.AuthorId == Id);
        }

        public int Add(string Name)
        {
            author = new Author()
            {
                AuthorName = Name
            };
            context.Authors.Add(author);
            return context.SaveChanges();
        }

        public int Update(int Id, string Name)
        {
            author = GetById(Id);

            if (author != null)
            {
                author.AuthorName = Name;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int Id)
        {
            author = GetAuthorWithEpisodes(Id);

            if (author != null)
            {
                context.Authors.Remove(author);
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
