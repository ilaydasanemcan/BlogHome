using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Entities.Concrete;

namespace MvcBlogHomeIdentity.Models
{
	public class WriterIndexVM
    {
        public string Name { get; set; }
        public IEnumerable<ApplicationUser> Writers { get; set; }
        
    }
}
