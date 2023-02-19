using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Entities.Concrete;
using MVCBlogSitesi.Entities.Concrete;

namespace MvcBlogHomeIdentity.Models
{
    public class ArticleReadVM
    {
        public int Id { get; set; }
        public ArticleReadVM()
        {
            Categories = new HashSet<Category>();
        }
        public string Name { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Category> Categories { get; set; }
        public string Context { get; set; }
        public int? Like { get; set; }
        public int ReadTime { get; set; }
        public DateTime dateTime { get; set; }
    }
}
