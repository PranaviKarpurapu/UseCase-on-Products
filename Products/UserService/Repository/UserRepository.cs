using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repository
{
    public class UserRepository: IUserRepository
    {

        private readonly ProductDBContext _context;
        public UserRepository(ProductDBContext context)
        {
            _context = context;
        }


        public UserDetails UserLogin(string uname, string pwd)
        {
            UserDetails ud = _context.UserDetails.SingleOrDefault(res => res.Username == uname && res.Password == pwd);
            return ud;
        }

        public void UserRegister(UserDetails userobj)
        {
            _context.Add(userobj);
            _context.SaveChanges();
        }

        public void UpdateProfile(UserDetails userobj)
        {
            _context.UserDetails.Update(userobj);
            _context.SaveChanges();
        }

        public UserDetails ViewProfile(string userid)
        {
            return _context.UserDetails.Find(userid);
        }






    }
}
