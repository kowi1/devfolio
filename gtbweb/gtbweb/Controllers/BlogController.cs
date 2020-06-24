using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gtbweb.Models;
using gtbweb.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
namespace gtbweb.Controllers
{
    public class BlogController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IDatabaseService  _dataservice;
        
        public BlogController(IDatabaseService  dataservice,UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
               _dataservice = dataservice; 
               _userManager = userManager;
               _signInManager = signInManager;
                   
        }
        
        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult Blog()
        {        
                 if (_signInManager.IsSignedIn(User))
                 {
                           var blogs =  _dataservice.GetBlogs(_userManager.GetUserId(User));
                           ViewBag.BlogCollection = blogs; 
                 }
                 else{
                           var blogs =  _dataservice.GetRecentBlogs(_userManager.GetUserId(User));
                           ViewBag.BlogCollection = blogs; 
                 }

            
                
                return View();
        }
        public IActionResult Create()
        {    var profile =  _dataservice.GetProfile(_userManager.GetUserId(User));
             var blogs =  _dataservice.CreateBlogPage(profile.ProfileID);
                ViewBag.BlogCollection = blogs; 
             return LocalRedirect(Url.Content("~/Page/Page/"+blogs.ToString()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
