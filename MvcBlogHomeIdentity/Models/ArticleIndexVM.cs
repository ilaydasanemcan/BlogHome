using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Entities.Concrete;
using MVCBlogSitesi.Entities.Concrete;

namespace MvcBlogHomeIdentity.Models
{
    public class ArticleIndexVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Category> WriterCategories { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
