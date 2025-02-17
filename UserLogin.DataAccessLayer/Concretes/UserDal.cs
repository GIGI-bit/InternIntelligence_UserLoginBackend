using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin.Core.DataAccess;
using UserLogin.DataAccessLayer.Abstracts;
using UserLogin.Models;
using UserLogin.Models.Data;

namespace UserLogin.DataAccessLayer.Concretes
{
    public class UserDal:EFEntityBaseRepository<Login_DB, User>, IUserDal
    {
        public UserDal(Login_DB context) : base(context)
        {
        }
    }
}
