
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin.Core.Entities;

namespace UserLogin.Models
{
    public class User:IdentityUser,IEntity
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
