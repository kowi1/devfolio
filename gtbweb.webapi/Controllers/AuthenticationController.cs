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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
namespace gtbweb.webapi.Controllers
{
       public class TestUserParameters
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IDatabaseService _dataservice;
        private IConfiguration _config;  
        public AuthenticationController(IConfiguration config,IDatabaseService dataservice,UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
              _dataservice= dataservice;      
              _userManager = userManager;
              _signInManager = signInManager;
              _config = config; 
        }

        
        // GET api/profile
        [HttpPost]
        public async Task<ActionResult<string>> Post(TestUserParameters model)
        {   
            
            var user = await _signInManager.UserManager.FindByEmailAsync(model.UserName);
              var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
           // var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
          //  var identity = userPrincipal.Identity;
             if (result.Succeeded)
                {
            
             var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
              _config["Jwt:Issuer"],    
              null,    
              expires: DateTime.Now.AddMinutes(5),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token); 
                }
            return JsonConvert.SerializeObject("Invalid");
            
  /*           var mi="d";
        if (!_signInManager.IsSignedIn(User))
        {
              var result = _signInManager.PasswordSignInAsync("dolukowi@gmail.com", "Lastdon1!", true, lockoutOnFailure: true);
              var user = await _signInManager.UserManager.FindByEmailAsync("dolukowi@gmail.com");
            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
            var identity = userPrincipal.Identity;
              if (_signInManager.IsSignedIn(userPrincipal))
                 {
             var pi =  _dataservice.GetSkills();
             return JsonConvert.SerializeObject(pi);
                 }  
        }
        
             //var profile =  _dataservice.GetProfile(_userManager.GetUserId(User));
           //return new string[] { pi[0].Value, pi[0].Text };
            //return new string[] {" pi.Designation", "pi.About" };
              return JsonConvert.SerializeObject(_signInManager.IsSignedIn(User));
        }*/
        }
    }
}