using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Entities.Concrete;
using MVCBlogSitesi.Entities.Abstract;

namespace MVCBlogSitesi.Entities.Concrete
{
    public class Article : BaseEntity
    {
        public Article()
        {
            Categories = new HashSet<Category>();
        }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Category> Categories { get; set; }
        public string Context { get; set; }
        public int Like { get; set; }
    }
}
