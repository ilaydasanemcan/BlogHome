using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBlogHomeIdentity.Entities.Concrete;
using MvcBlogHomeIdentity.Models;
using MvcBlogHomeIdentity.Repositories.Abstract;
using MVCBlogSitesi.Entities.Concrete;

namespace MvcBlogHomeIdentity.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IWriterRepository writerRepository;

        public ArticlesController(IArticleRepository articleRepository,ICategoryRepository categoryRepository, IWriterRepository writerRepository)
        {
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
            this.writerRepository = writerRepository;
        }

        public IActionResult Index(string Id)
        {
            var categories = categoryRepository.GetAll();
            var user=writerRepository.GetAllIncludeCategory(Id);
            ArticleIndexVM articleIndexVM = new ArticleIndexVM();
            if (user != null)
            {
                articleIndexVM.Categories = user.Categories;
            }
            else 
            {
                articleIndexVM.Categories = categories;
            }
            
            return View(articleIndexVM);
        }

        public IActionResult Read(int id)
        {
            var article = articleRepository.GetAllIncludeUsers(id);
            var user=writerRepository.GetById(article.ApplicationUser.Id);
            //var articleC = articleRepository.GetByIncludeCategory(id);
            ArticleReadVM articleReadVM = new ArticleReadVM();
            articleReadVM.Id = article.Id;
            articleReadVM.UserId = user.Id;
            articleReadVM.Name = article.Name;
            articleReadVM.Context = article.Context;
            articleReadVM.ReadTime = article.Context.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length/2;
            //articleReadVM.Categories = article.Categories;
            articleReadVM.ApplicationUser = article.ApplicationUser;
            articleReadVM.dateTime = article.CreateTime;
            article.Like++;
            articleRepository.Update(article);
            articleReadVM.Like = article.Like;
            return View(articleReadVM);
        }

        public IActionResult CategoryArticle(int id)
        {
            ArticleCategoryVM articleCategoryVM = new ArticleCategoryVM();
            
            var articles = articleRepository.GetByIncludeCategory(id);
            if (articles == null || !articles.Any())
            {
                articleCategoryVM.Articles = null;
            }
            else { articleCategoryVM.Articles = articles; }

            return View(articleCategoryVM);
        }

        public IActionResult Write()
        {
            var categories = categoryRepository.GetAll();
            ArticleCreateVM articleCreateVM = new ArticleCreateVM();
            articleCreateVM.Categories = categories;
            return View(articleCreateVM);
        }

        [HttpPost]
        public IActionResult Write(string id,Article article, int[] ids)
        {
            var user = writerRepository.GetById(id);
            HashSet<Category> categories = new HashSet<Category>();
            foreach (var item in ids)
            {
                var category = categoryRepository.GetById(item);
                categories.Add(category);
            }
            //ArticleCreateVM articleCreateVM = new ArticleCreateVM();
            article.Like = 0;
            article.ApplicationUser = user;
            article.Categories = (ICollection<Entities.Concrete.Category>?)categories;
            articleRepository.Add(article);
            return RedirectToAction("Index","Home");
        }

        public IActionResult Delete(int id)
        {
            var article=articleRepository.GetById(id);
            if (article != null)
            {
                articleRepository.Delete(article);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
