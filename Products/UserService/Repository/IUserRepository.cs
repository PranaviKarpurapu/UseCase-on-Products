using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repository
{
    public interface IUserRepository
    {
        UserDetails UserLogin(string uname, string pwd);

        void UserRegister(UserDetails userobj);

        void UpdateProfile(UserDetails userobj);

        UserDetails ViewProfile(string userid);
    }
}

