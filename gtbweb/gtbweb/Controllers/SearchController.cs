using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gtbweb.Models;
using gtbweb.Services;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Unsplasharp;
using Unsplasharp.Models;


namespace gtbweb.Controllers
{
    public class InputSearchModel
    {

               [BindProperty]
              public string search{get;set;}
    }
    public class SearchController : Controller
    {   private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IDatabaseService  _dataservice;
        
         public SearchController(IDatabaseService  dataservice,UserManager<IdentityUser> userManager,
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

        
          public IActionResult Search(InputSearchModel Input)
        {
            var page =  _dataservice.SearchBlogs(Input.search, _userManager.GetUserId(User));
                ViewBag.BlogCollection = page; 
               
              
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
