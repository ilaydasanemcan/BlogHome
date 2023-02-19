using MvcBlogHomeIdentity.Entities.Concrete;
using MVCBlogSitesi.Repositories.Abstract;

namespace MvcBlogHomeIdentity.Repositories.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetById(int id);
    }
}
