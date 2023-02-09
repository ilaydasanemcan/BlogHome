using MvcBlogHomeIdentity.Areas.Identity.Data;
using MVCBlogSitesi.Entities.Concrete;

namespace MvcBlogHomeIdentity.Models
{
	public class WriterProfileVM
	{
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhotoPath { get; set; }
        public IEnumerable<ApplicationUser> Writers { get; set; }
        public ApplicationUser Writer { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
