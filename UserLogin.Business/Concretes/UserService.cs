using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin.Business.Abstracts;
using UserLogin.DataAccessLayer.Abstracts;
using UserLogin.Models;

namespace UserLogin.Business.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUserDal dal;

        public UserService(IUserDal dal)
        {
            this.dal = dal;
        }
        public async Task Add(User user)
        {
            await dal.Add(user);
        }

        public async Task Delete(User user)
        {
            await dal.Delete(user);
        }

        public async Task<User> GetUserById(string id)
        {
            return await dal.GetById(f => f.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await dal.GetAll();

        }

        public async Task Update(User user)
        {
            await dal.Update(user);
        }
    }
}
