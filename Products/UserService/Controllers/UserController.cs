using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Repository;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _iuserrepo;
        

        public UserController(IUserRepository iuserrepo)
        {
            _iuserrepo = iuserrepo;
            
        }

        [HttpPost]
        [Route("UserRegister")]

        public IActionResult UserRegister(UserDetails ud)
        {
            try
            {
                _iuserrepo.UserRegister(ud);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPost]
        [Route("UserLogin/{uname}/{pwd}")]

        public IActionResult UserLogin(string uname,string pwd)
        {
            try
            {
                UserDetails user = _iuserrepo.UserLogin(uname, pwd);
                if (user == null)
                    return Ok("Invalid User");
                else
                    return Ok(user);
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }




        [HttpPut]
        [Route("EditProfile")]

        public IActionResult EditProfile(UserDetails userobj)
        {
            try
            {
                _iuserrepo.UpdateProfile(userobj);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("ViewProfile/{userid}")]

        public IActionResult ViewProfile(string userid)
        {
            try
            {
                return Ok(_iuserrepo.ViewProfile(userid));
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
