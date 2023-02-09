using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MvcBlogHomeIdentity.Areas.Identity.Data
{
    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u=> u.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(20).IsRequired();
        }

        
    }
}