using MVCBlogSitesi.Entities.Concrete;
using MVCBlogSitesi.Repositories.Abstract;

namespace MvcBlogHomeIdentity.Repositories.Abstract
{
    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetAllIncludeUsers();
        IEnumerable<Article> GetAllIncludeUsersById(string id);
        Article GetAllIncludeUsers(int id);
        IEnumerable<Article> GetByIncludeCategory(int id);
        Article GetById(int id);
    }
}
