using Microsoft.AspNetCore.Mvc;
using MvcBlogHomeIdentity.Areas.Identity.Data;
using MvcBlogHomeIdentity.Models;
using MvcBlogHomeIdentity.Repositories.Abstract;

namespace MvcBlogHomeIdentity.Controllers
{
    public class WritersController : Controller
    {
        private readonly IWriterRepository writerRepository;
        private readonly IArticleRepository articleRepository;

        public WritersController(IWriterRepository writerRepository, IArticleRepository articleRepository)
        {
            this.writerRepository = writerRepository;
            this.articleRepository = articleRepository;
        }

        public IActionResult Index()
        {
            var writers = writerRepository.GetAll();
            WriterIndexVM writerIndexVM = new WriterIndexVM();
            writerIndexVM.Writers = writers;
            return View(writerIndexVM);
        }
        //[HttpPost]
        //public IActionResult Index(WriterIndexVM writerIndexVM)
        //{
        //    return View(writerIndexVM);
        //}

        public IActionResult Profile(string id)
        {
            var user = writerRepository.GetAllIncludeArticle(id);
            WriterProfileVM writerProfileVM = new WriterProfileVM();
            writerProfileVM.Id = user.Id;
            writerProfileVM.FirstName = user.FirstName;
            writerProfileVM.LastName = user.LastName;
            writerProfileVM.UserName = user.UserName;
            writerProfileVM.Articles = user.Articles;
            if (user.PhotoPath != null)
            {
                writerProfileVM.PhotoPath = user.PhotoPath;
            }
            
            return View(writerProfileVM);
        }
        public IActionResult Create()
        {
            return View();
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
