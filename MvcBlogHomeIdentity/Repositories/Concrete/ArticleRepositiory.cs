using Microsoft.EntityFrameworkCore;
using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Repositories.Abstract;
using MVCBlogSitesi.Entities.Concrete;
using MVCBlogSitesi.Repositories.Concrete;
using System.Linq;

namespace MvcBlogHomeIdentity.Repositories.Concrete
{
    public class ArticleRepositiory : GenericRepository<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext db;

        public ArticleRepositiory(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public Article GetById(int id)
        {
            return db.Articles.FirstOrDefault(a => a.Id == id);
        }
        public IEnumerable<Article> GetByIncludeCategory(int id)
        {
            return db.Articles.Include(a => a.Categories).Where(a => a.Categories.Any(c => c.Id == id)).OrderByDescending(a => a.Like);
        }

        public IEnumerable<Article> GetAllIncludeUsers()
        {
            return db.Articles.Include(s => s.ApplicationUser).OrderByDescending(a => a.Like);
        }

        public IEnumerable<Article> GetAllIncludeUsersById(string id)
        {
            return (IEnumerable<Article>)db.Articles.Include(s => s.ApplicationUser).Where(a => a.ApplicationUser.Id == id).Select(a=> a.Name);
        }

        public Article GetAllIncludeUsers(int id)
        {
            return db.Articles.Include(a => a.ApplicationUser).FirstOrDefault(a => a.Id == id);
        }
    }
}
