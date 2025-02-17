using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin.Business.Abstracts
{
    public interface IJwtTokenManager
    {
        string GenerateToken(string username);
    }
}
