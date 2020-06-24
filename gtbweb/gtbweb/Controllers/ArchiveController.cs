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
    public class InputArchiveModel
    {

               [BindProperty]
              public int id{get;set;}
    }
    public class ArchiveController : Controller
    {   private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IDatabaseService  _dataservice;
        
         public ArchiveController(IDatabaseService  dataservice,UserManager<IdentityUser> userManager,
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

        
          public IActionResult SearchDateArchive(int? id)
        {
            var page =  _dataservice.SearchDateArchive(id, _userManager.GetUserId(User));
                ViewBag.BlogCollection = page; 
               
              
            return View("~/Views/Shared/Archive.cshtml");
        }
          public IActionResult SearchCategoryArchive(int? id)
        {
            var page =  _dataservice.SearchCategoryArchive(id, _userManager.GetUserId(User));
                ViewBag.BlogCollection = page; 
               
              
            return View("~/Views/Shared/Archive.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
