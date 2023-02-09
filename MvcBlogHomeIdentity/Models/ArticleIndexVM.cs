using MvcBlogHomeIdentity.Entities.Concrete;
using MVCBlogSitesi.Entities.Concrete;

namespace MvcBlogHomeIdentity.Models
{
    public class ArticleIndexVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
