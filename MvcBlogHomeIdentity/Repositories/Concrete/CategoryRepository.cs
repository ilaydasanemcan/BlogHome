﻿using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Entities.Concrete;
using MvcBlogHomeIdentity.Repositories.Abstract;
using MVCBlogSitesi.Repositories.Concrete;
using System.Linq;

namespace MvcBlogHomeIdentity.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        //public string GetAllCategoryName()
        //{
        //    return db.Categories.Select(c => c.Name).All();
        //}
    }
}
