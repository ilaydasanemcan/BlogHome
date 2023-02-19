using MVCBlogSitesi.Entities.Concrete;

namespace MvcBlogHomeIdentity.Models
{
    public class ArticleCategoryVM
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}
