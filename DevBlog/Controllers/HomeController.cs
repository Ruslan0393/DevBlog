using Blogger.Models;
using DevBlog.Areas.Identity.Data;
using DevBlog.IRepository;
using DevBlog.Models;
using DevBlog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;



namespace DevBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<BlogUser> _userManager;
        private readonly IPostRepository _postRepo;

        public HomeController(ILogger<HomeController> logger, UserManager<BlogUser> userManager, IPostRepository postRepo)
        {
            _logger = logger;
            _userManager = userManager;
            _postRepo = postRepo;
        }

        public IActionResult AllPosts()
        {
            IEnumerable<Post> allPosts = _postRepo.GetAll();
            IEnumerable<BlogUser> getUsers = _userManager.Users;

            if (allPosts != null)
            {
                MyPostViewModel posts = new MyPostViewModel
                {
                    AllUsers = getUsers,
                    AllPosts = allPosts,
                    Title = "All posts"
                };

                return View(posts);
            }
            return View();
        }


        public IActionResult Index()
        {
            IEnumerable<Post> allPosts = _postRepo.GetAll();
            IEnumerable<BlogUser> getUsers = _userManager.Users;

            if (allPosts != null)
            {
                MyPostViewModel posts = new MyPostViewModel
                {
                    AllUsers = getUsers,
                    AllPosts = allPosts,
                    Title = "All posts"
                };

                return View(posts);
            }
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
