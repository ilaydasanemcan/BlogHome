using MvcBlogHomeIdentity.Areas.Identity.Data;
using MVCBlogSitesi.Entities.Concrete;

namespace MvcBlogHomeIdentity.Models
{
    public class HomeIndexVM
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}
