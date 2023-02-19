using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Entities.Concrete;

namespace MvcBlogHomeIdentity.Models
{
    public class ArticleCreateVM
    {
        public ArticleCreateVM()
        {
            Categories = new HashSet<Category>();
        }
        public string Name { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Context { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
