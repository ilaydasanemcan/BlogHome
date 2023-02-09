using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCBlogSitesi.Entities.Concrete;

namespace MvcBlogHomeIdentity.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        Articles = new HashSet<Article>();
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhotoPath { get; set; }
    public ICollection<Article> Articles { get; set; }
}

