using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.IRepository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetUserAllPosts(string id);
        Post Get(int id);
        Post Create(Post post);
        Post Update(Post post);
        Post Delete(int id);
    }
}
