using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Entities.Concrete;
using MvcBlogHomeIdentity.Models;
using MvcBlogHomeIdentity.Repositories.Abstract;

namespace MvcBlogHomeIdentity.Controllers
{
    public class WritersController : Controller
    {
        private readonly IWriterRepository writerRepository;
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;

        public WritersController(IWriterRepository writerRepository, IArticleRepository articleRepository,ICategoryRepository categoryRepository)
        {
            this.writerRepository = writerRepository;
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var writers = writerRepository.GetAll();
            WriterIndexVM writerIndexVM = new WriterIndexVM();
            writerIndexVM.Writers = writers;
            return View(writerIndexVM);
        }
        
        public IActionResult Category(string id)
        {
            var categories = categoryRepository.GetAll();
            var user = writerRepository.GetAllIncludeCategory(id);
            
            WriterCategoryVM writerCategoryVM = new WriterCategoryVM();
            writerCategoryVM.Categories = categories;
            writerCategoryVM.ApplicationUserId = id;
            writerCategoryVM.WriterCategories = user.Categories;
            return View(writerCategoryVM);
        }

        [HttpPost]
        public IActionResult Category(int[] ids, string id)
        {
            ApplicationUser applicationUser = new ApplicationUser();

            applicationUser = writerRepository.GetAllIncludeCategory(id);
            HashSet<Category> categories = new HashSet<Category>();

            foreach (var item in ids)
            {
                var category = categoryRepository.GetById(item);
                categories.Add(category);
            }

            applicationUser.Categories = categories;

            var newApplicationUser = writerRepository.Update(applicationUser);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Send()
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Profile(string id)
        {
            var user = writerRepository.GetAllIncludeArticle(id);
            WriterProfileVM writerProfileVM = new WriterProfileVM();
            writerProfileVM.Id = user.Id;
            writerProfileVM.FirstName = user.FirstName;
            writerProfileVM.LastName = user.LastName;
            writerProfileVM.UserName = user.UserName;
            writerProfileVM.Articles = user.Articles;
            writerProfileVM.Description = user.Description;

            if (user.PhoneNumber != null)
            {
                writerProfileVM.PhoneNumber = user.PhoneNumber;
            }

            if (user.PhotoPath != null)
            {
                writerProfileVM.PhotoPath = user.PhotoPath;
            }
            
            return View(writerProfileVM);
        }
        public IActionResult Create()
        {
            var categories = categoryRepository.GetAll();
            ArticleCreateVM articleCreateVM = new ArticleCreateVM();
            articleCreateVM.Categories = categories;
            return View(articleCreateVM);
        }

        //[HttpPost]
        //public IActionResult Search(string name)
        //{
        //    var writers = writerRepository.Search(name);
        //    WriterIndexVM writerIndexVM = new WriterIndexVM();
        //    writerIndexVM.Writers = writers;
        //    return View(writerIndexVM);
        //}
    }
}
