using Microsoft.EntityFrameworkCore;
using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Repositories.Abstract;
using MVCBlogSitesi.Repositories.Concrete;

namespace MvcBlogHomeIdentity.Repositories.Concrete
{
	public class WriterRepository : GenericRepository<ApplicationUser>,IWriterRepository
	{
		private readonly ApplicationDbContext db;

		public WriterRepository(ApplicationDbContext db) : base(db)
		{
			this.db = db;
		}

        public ApplicationUser GetById(string id)
        {
			return db.Users.FirstOrDefault(a => a.Id==id);
        }

        public List<ApplicationUser> Search(string name)
        {
            return db.Users.Where(a => a.UserName.Contains(name)).ToList();
        }

        public ApplicationUser GetAllIncludeArticle(string id)
        {
            return db.ApplicationUser.Include(a => a.Articles).FirstOrDefault(a => a.Id == id);
        }
    }
}
