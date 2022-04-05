using Blogger.Models;
using DevBlog.Data;
using DevBlog.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DevBlogContext _blogContext;

        public PostRepository(DevBlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public Post Create(Post post)
        {
            _blogContext.Posts.Add(post);
            _blogContext.SaveChanges();
            return post;
        }


        public Post Delete(int id)
        {
            var post = _blogContext.Posts.Find(id);
            if(post != null)
            {
                _blogContext.Posts.Remove(post);
                _blogContext.SaveChanges();
            }
            return post;
        }


        public IEnumerable<Post> GetAll()
        {
            return _blogContext.Posts;
        }


        public Post Get(int id)
        {
            return _blogContext.Posts.Find(id);
        }


        public IEnumerable<Post> GetUserAllPosts(string id)
        {
            return _blogContext.Posts.Where(v => v.BlogUserRefId == id).AsEnumerable();
        }


        public Post Update(Post updatePost)
        {
            var post = _blogContext.Posts.Attach(updatePost);
            post.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _blogContext.SaveChanges();
            return updatePost;
        }
    }
}
