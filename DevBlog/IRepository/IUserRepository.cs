using DevBlog.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<BlogUser> GetAll();
    }
}
