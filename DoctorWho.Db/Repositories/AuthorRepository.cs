using DoctorWho.Db.DataModels;
using DoctorWho.Db.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DoctorWho.Db.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DoctorWhoCoreDbContext context;

        public AuthorRepository(DoctorWhoCoreDbContext context)
        {
            this.context = context ?? new DoctorWhoCoreDbContext();
        }
        public int Add(Author author)
        {
            context.Authors.Add(author);
            return context.SaveChanges();
        }

        public int Delete(int Id)
        {
            var author = GetAuthorWithEpisodes(Id);

            if (author != null)
            {
                context.Authors.Remove(author);
                return context.SaveChanges();
            }
            return 0;
        }

        public Author GetAuthorWithEpisodes(int Id)
        {
            return context.Authors
                .Include(a => a.Episodes)
                .FirstOrDefault(a => a.AuthorId == Id);
        }

        public Author GetById(int Id)
        {
            return context.Authors.Find(Id);
        }

        public int Update(Author author)
        {
            var OldAuthor = GetById(author.AuthorId);

            if (OldAuthor != null)
            {
                OldAuthor.AuthorName = author.AuthorName;
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
