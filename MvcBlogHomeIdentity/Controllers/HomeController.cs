using Microsoft.AspNetCore.Mvc;
using MvcBlogHomeIdentity.Models;
using MvcBlogHomeIdentity.Repositories.Abstract;
using System.Diagnostics;

namespace MvcBlogHomeIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository articleRepository;

        public HomeController(ILogger<HomeController> logger,IArticleRepository articleRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;
        }
        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult Historys()
        {
            return View();
        }

        public IActionResult Articles()
        {
            return View();
        }

        public IActionResult Writers()
        {
            return View();
        }

        public IActionResult Index()
        {
            var articles = articleRepository.GetAllIncludeUsers();
            HomeIndexVM homeIndexVM = new HomeIndexVM();
            homeIndexVM.Articles = articles;
            return View(homeIndexVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}