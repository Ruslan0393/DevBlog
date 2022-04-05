using Blogger.Models;
using DevBlog.Areas.Identity.Data;
using DevBlog.IRepository;
using DevBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;





namespace DevBlog.Controllers
{
    [Authorize]
    public class UserPostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IWebHostEnvironment _webHost;
        private readonly UserManager<BlogUser> _userManager;

        public UserPostController(IPostRepository postRepository,
             IWebHostEnvironment webHost,
             UserManager<BlogUser> userManager)
        {
            _postRepository = postRepository;
            _webHost = webHost;
            _userManager = userManager;
        }

        [HttpGet]
        public ViewResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(AddPostViewModel addPost)
        {
            if (ModelState.IsValid)
            {
                string photoFilePath = ProcessUploadedFile(addPost);
                string idUser = _userManager.GetUserId(HttpContext.User);
                Post newPost = new Post
                {
                    Title = addPost.Title,
                    Body = addPost.Body,
                    PostImg = photoFilePath,
                    AddTime = DateTime.Now,
                    BlogUserRefId = idUser
                };
                newPost = _postRepository.Create(newPost);
                return RedirectToAction("MyPost", new { id = newPost.Id });
            }
             return View();
        }

        public ViewResult MyAllPosts()
        {
            string idUser = _userManager.GetUserId(HttpContext.User);
            IEnumerable<Post> userPost = _postRepository.GetUserAllPosts(idUser);
            if (userPost != null)
            {
                GetAllUserPostViewModel allPostsUser = new GetAllUserPostViewModel()
                {
                    posts = userPost,
                    title = "All posts"
                };
                return View(allPostsUser);
            }
            else
            {
                return NotFoundView();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult MyPost(int id)
        {
            Post userPost = _postRepository.Get(id);
            var idRef = userPost.BlogUserRefId;
            var getUsers = _userManager.Users;
            var thatUser = getUsers.Where(v => v.Id.Equals(idRef)).Select(v => v).FirstOrDefault();
            
            if (userPost != null)
            {
                GetGlobalPosts newP = new GetGlobalPosts()
                {
                    users = thatUser,
                    post = userPost,
                    title = userPost.Title
                };
                return View(newP);
            }
            else
            {
                return NotFoundView();
            }
        }
        
        public IActionResult TempPost()
        {
            return RedirectToAction("MyallPosts");
        }
       
        public IActionResult DeletPost(int id)
        {
            _postRepository.Delete(id);
            return RedirectToAction("temppost");
        }


    /*    [HttpGet]
        public IActionResult EditPost(int id)
        {
            Post post = _postRepository.Get(id);
            if (post != null)
            {
                EditViewModel updatePost = new EditViewModel
                {
                    Id = post.Id,
                    Body = post.Body,
                    Title = post.Title,
                    Photo = post.PostImg
                };
                return View(updatePost);
            }
            return NotFound();
        }
*/
/*
        [HttpPost]
        public IActionResult EditPost(EditViewModel post)
        {
            if (ModelState.IsValid)
            {
                Post exitingPost = _postRepository.Get(post.Id);
                exitingPost.Body = post.Body;
                exitingPost.Title = post.Title;
                if (post.Photo != null)
                {
                    if(exitingPost.PostImg != null)
                    {
                        string filePath = Path.Combine(_webHost.WebRootPath, "PostImages", post.Photo);
                        System.IO.File.Delete(filePath);
                    }
                    exitingPost.PostImg = ProcessUploadedFile(post);
                }

            }
            return View();
        }
*/



        private ViewResult NotFoundView()
        {
            Response.StatusCode = 404;
            return View("PostNotFound");
        }


        private string ProcessUploadedFile(AddPostViewModel post)
        {
            string uniqueFileName = string.Empty;
            if (post.Photo != null)
            {
                string uploadFolder = Path.Combine(_webHost.WebRootPath, "PostImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + post.Photo.FileName;
                string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
                {
                    post.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
