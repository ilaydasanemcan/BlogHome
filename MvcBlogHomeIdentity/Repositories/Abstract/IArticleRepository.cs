using MVCBlogSitesi.Entities.Concrete;
using MVCBlogSitesi.Repositories.Abstract;

namespace MvcBlogHomeIdentity.Repositories.Abstract
{
    public interface IArticleRepository : IRepository<Article>
    {
        Article GetByIncludeCategory(int id);
        IEnumerable<Article> GetAllIncludeUsers();
        IEnumerable<Article> GetAllIncludeUsersById(string id);
    }
}
