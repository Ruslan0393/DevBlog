using DevBlog.Areas.Identity.Data;
using DevBlog.Data;
using DevBlog.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DevBlogContext _userData;
        public UserRepository(DevBlogContext userData)
        {
            _userData = userData;
        }
        
        public IEnumerable<BlogUser> GetAll()
        {
            return _userData.Users;
        }

    }
}
