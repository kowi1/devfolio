using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using gtbweb.Models;
using gtbweb.Services;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


namespace gtbweb.webapi.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IDatabaseService _dataservice;
        public ProfileController(IDatabaseService dataservice,UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
              _dataservice= dataservice;      
              _userManager = userManager;
              _signInManager = signInManager;
              
        }

        
        // GET api/profile
        [HttpPost]
        public async Task<ActionResult<string>> Post(TestUserParameters model)
        {    
     
          //    var result = _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: true);
          //  var fg=  _signInManager.SignOutAsync();
              var user = await _signInManager.UserManager.FindByEmailAsync(model.UserName);

           var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
           var identity = userPrincipal.Identity;
            
            //var pi =  _dataservice.GetSkills();
            var pi=_userManager.GetUserId(userPrincipal);
             return JsonConvert.SerializeObject(pi);
               //  }  
        
        
             //var profile =  _dataservice.GetProfile(_userManager.GetUserId(User));
           //return new string[] { pi[0].Value, pi[0].Text };
            //return new string[] {" pi.Designation", "pi.About" };
            //  return JsonConvert.SerializeObject("h");
        }

        // GET api/profile/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
           
            return "value";
        }

        // POST api/profile
    /*    [HttpPost]
        public void Post([FromBody] string value)
        {
        }
*/
        // PUT api/profile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/profile/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}