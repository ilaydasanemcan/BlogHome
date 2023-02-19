using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Entities.Concrete;
using System.Collections;

namespace MvcBlogHomeIdentity.Models
{
    public class WriterCategoryVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Category> WriterCategories { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
