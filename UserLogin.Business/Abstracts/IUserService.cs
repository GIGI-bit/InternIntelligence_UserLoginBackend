using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin.Models;

namespace UserLogin.Business.Abstracts
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(string id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(User user);
    }
}
