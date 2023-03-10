using MvcBlogHomeIdentity.Areas.Identity.Data;
using MVCBlogSitesi.Entities.Abstract;
using MVCBlogSitesi.Entities.Concrete;

namespace MvcBlogHomeIdentity.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            ApplicationUsers=new HashSet<ApplicationUser>();
        }
        public string? PhotoPath { get; set; }
        public string? Context { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
