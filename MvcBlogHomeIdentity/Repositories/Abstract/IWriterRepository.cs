using MvcBlogHomeIdentity.Areas.Identity.Data;
using MVCBlogSitesi.Repositories.Abstract;

namespace MvcBlogHomeIdentity.Repositories.Abstract
{
	public interface IWriterRepository : IRepository<ApplicationUser>
	{
        ApplicationUser GetById(string id);
        List<ApplicationUser> Search(string name);
        ApplicationUser GetAllIncludeArticle(string id);
    }
}
