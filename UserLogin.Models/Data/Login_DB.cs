using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin.Models.Data
{
    public class Login_DB: IdentityDbContext<User>
    {
        public Login_DB(DbContextOptions<Login_DB> options) : base(options)
        {

        }

        public virtual DbSet<User> users{ get; set; }

    }
}
