using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Entities.Concrete;
using MVCBlogSitesi.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace MvcBlogHomeIdentity.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        //Category category = new Category
        //{
        //    Id = 1,
        //    Name = "Programming",
        //    CreateTime = DateTime.Now,
        //    Context=""
        //};


        List<Category> CategoriesList = new List<Category>()
        {
        new Category{Id=1,Name="Programming", CreateTime=DateTime.Now, PhotoPath="/image/Programming.jpg",Context="Lorem ipsum dolor sit amet, ea eos tibique expetendis, tollit viderer ne nam. No ponderum accommodare eam, purto nominavi cum ea, sit no dolores tractatos. Scripta principes quaerendum ex has, ea mei omnes eruditi. Nec ex nulla mandamus, quot omnesque mel et. Amet habemus ancillae id eum, justo dignissim mei ea, vix ei tantas aliquid. Cu laudem impetus conclusionemque nec, velit erant persius te mel."},
        new Category{Id=2,Name="DataScience", CreateTime=DateTime.Now, PhotoPath="/image/DataScience.jpeg",Context="Lorem ipsum dolor sit amet, ea eos tibique expetendis, tollit viderer ne nam. No ponderum accommodare eam, purto nominavi cum ea, sit no dolores tractatos. Scripta principes quaerendum ex has, ea mei omnes eruditi. Nec ex nulla mandamus, quot omnesque mel et. Amet habemus ancillae id eum, justo dignissim mei ea, vix ei tantas aliquid. Cu laudem impetus conclusionemque nec, velit erant persius te mel."},
        new Category{Id=3,Name="Technology", CreateTime=DateTime.Now, PhotoPath="/image/Technology.jpeg",Context="Lorem ipsum dolor sit amet, ea eos tibique expetendis, tollit viderer ne nam. No ponderum accommodare eam, purto nominavi cum ea, sit no dolores tractatos. Scripta principes quaerendum ex has, ea mei omnes eruditi. Nec ex nulla mandamus, quot omnesque mel et. Amet habemus ancillae id eum, justo dignissim mei ea, vix ei tantas aliquid. Cu laudem impetus conclusionemque nec, velit erant persius te mel."},
        new Category{Id=4,Name="SelfImprovement", CreateTime=DateTime.Now, PhotoPath="/image/SelfImprovement.jpeg",Context="Lorem ipsum dolor sit amet, ea eos tibique expetendis, tollit viderer ne nam. No ponderum accommodare eam, purto nominavi cum ea, sit no dolores tractatos. Scripta principes quaerendum ex has, ea mei omnes eruditi. Nec ex nulla mandamus, quot omnesque mel et. Amet habemus ancillae id eum, justo dignissim mei ea, vix ei tantas aliquid. Cu laudem impetus conclusionemque nec, velit erant persius te mel."},
        new Category{Id=5,Name="Writing", CreateTime=DateTime.Now, PhotoPath="/image/Writing.jpeg",Context="Lorem ipsum dolor sit amet, ea eos tibique expetendis, tollit viderer ne nam. No ponderum accommodare eam, purto nominavi cum ea, sit no dolores tractatos. Scripta principes quaerendum ex has, ea mei omnes eruditi. Nec ex nulla mandamus, quot omnesque mel et. Amet habemus ancillae id eum, justo dignissim mei ea, vix ei tantas aliquid. Cu laudem impetus conclusionemque nec, velit erant persius te mel."},
        new Category{Id=6,Name="Relationships", CreateTime=DateTime.Now, PhotoPath="/image/Relationships.jpeg",Context="Lorem ipsum dolor sit amet, ea eos tibique expetendis, tollit viderer ne nam. No ponderum accommodare eam, purto nominavi cum ea, sit no dolores tractatos. Scripta principes quaerendum ex has, ea mei omnes eruditi. Nec ex nulla mandamus, quot omnesque mel et. Amet habemus ancillae id eum, justo dignissim mei ea, vix ei tantas aliquid. Cu laudem impetus conclusionemque nec, velit erant persius te mel."},
        new Category{Id=7,Name="MachineLearning", CreateTime=DateTime.Now, PhotoPath="/image/MachineLearning.jpeg",Context="Lorem ipsum dolor sit amet, ea eos tibique expetendis, tollit viderer ne nam. No ponderum accommodare eam, purto nominavi cum ea, sit no dolores tractatos. Scripta principes quaerendum ex has, ea mei omnes eruditi. Nec ex nulla mandamus, quot omnesque mel et. Amet habemus ancillae id eum, justo dignissim mei ea, vix ei tantas aliquid. Cu laudem impetus conclusionemque nec, velit erant persius te mel."},
        new Category{Id=8,Name="Productivity", CreateTime=DateTime.Now, PhotoPath="/image/Productivity.jpeg",Context="Lorem ipsum dolor sit amet, ea eos tibique expetendis, tollit viderer ne nam. No ponderum accommodare eam, purto nominavi cum ea, sit no dolores tractatos. Scripta principes quaerendum ex has, ea mei omnes eruditi. Nec ex nulla mandamus, quot omnesque mel et. Amet habemus ancillae id eum, justo dignissim mei ea, vix ei tantas aliquid. Cu laudem impetus conclusionemque nec, velit erant persius te mel."},
        };

        builder.Entity<Category>().HasData(CategoriesList);

        string adminRoleId = Guid.NewGuid().ToString();
        string standartRoleId = Guid.NewGuid().ToString();

        IdentityRole adminRole = new IdentityRole { Id = adminRoleId, Name = "admin", NormalizedName = "ADMIN" };

        IdentityRole standartRole = new IdentityRole { Id = standartRoleId, Name = "standart", NormalizedName = "STANDART" };

        builder.Entity<IdentityRole>().HasData(adminRole);
        builder.Entity<IdentityRole>().HasData(standartRole);

        var hasher = new PasswordHasher<IdentityUser>();

        string adminAppUserId = Guid.NewGuid().ToString();
        string standartAppUserId = Guid.NewGuid().ToString();


        ApplicationUser adminUser = new ApplicationUser
        {
            Id = adminAppUserId,
            FirstName = "Admin",
            LastName = "Admin",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

        ApplicationUser standartUser = new ApplicationUser
        {
            Id = standartAppUserId,
            FirstName = "Standart",
            LastName = "Standart",
            Email = "standart@standart.com",
            NormalizedEmail = "STANDART@STANDART.COM",
            UserName = "standart@standart.com",
            NormalizedUserName = "STANDART@STANDART.COM",
            EmailConfirmed = true,
        };
        standartUser.PasswordHash = hasher.HashPassword(standartUser, "Standart123!");

        builder.Entity<ApplicationUser>().HasData(adminUser);
        builder.Entity<ApplicationUser>().HasData(standartUser);

        IdentityUserRole<string> adminUserRole = new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminAppUserId };
        IdentityUserRole<string> standartUserRole = new IdentityUserRole<string> { RoleId = standartRoleId, UserId = standartAppUserId };

        builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
        builder.Entity<IdentityUserRole<string>>().HasData(standartUserRole);

        builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
        {
            UserId = adminAppUserId,
            Id = 1,
            ClaimType = "IsAdmin",
            ClaimValue = "true"
        });


    }

    
}
