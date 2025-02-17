using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin.Core.DataAccess;
using UserLogin.Models;

namespace UserLogin.DataAccessLayer.Abstracts
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
