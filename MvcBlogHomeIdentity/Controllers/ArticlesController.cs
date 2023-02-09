using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBlogHomeIdentity.Models;
using MvcBlogHomeIdentity.Repositories.Abstract;

namespace MvcBlogHomeIdentity.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;

        public ArticlesController(IArticleRepository articleRepository,ICategoryRepository categoryRepository)
        {
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = categoryRepository.GetAll();
            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
            articleIndexVM.Categories = categories;
            return View(articleIndexVM);
        }
    }
}
