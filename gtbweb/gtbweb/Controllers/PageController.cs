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
    public class InputPageModel
    {
             [BindProperty]
              public string editor{get;set;}
             [BindProperty]
              public string Pageid{get;set;}
              [BindProperty]
              public string Title{get;set;}
               [BindProperty]
              public string search{get;set;}
    }
    public class PageController : Controller
    {   private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IDatabaseService  _dataservice;
        
         public PageController(IDatabaseService  dataservice,UserManager<IdentityUser> userManager,
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

        public IActionResult Page(int? id)
        {
            var page =  _dataservice.GetBlogPage(id,_userManager.GetUserId(User));
                ViewBag.PageDetails = page; 
               
              
            return View();
        }
          public IActionResult Search(InputPageModel Input)
        {
            var page =  _dataservice.SearchBlogs(Input.search, _userManager.GetUserId(User));
                ViewBag.BlogCollection = page; 
               
              
            return View();
        }
        public IActionResult Save(InputPageModel Input)
        {
            _dataservice.SaveBlogText(Input.editor,Input.Pageid);
                
            return LocalRedirect(Url.Content("~/Page/Page/"+Input.Pageid));
        }
        public async Task<IActionResult> Image(int id)
        {    
          /*  Dictionary<string, string> jsonValues = new Dictionary<string, string>();
             jsonValues.Add("client_id", "6f1f83f0399e8b91d2e5a07b05d65907c452cc90501ab0c002a6d99815c4adc5");
           
            var foto = await Unsplash.SendRequest(HttpMethod.Get,"https://api.unsplash.com/photos/random","6f1f83f0399e8b91d2e5a07b05d65907c452cc90501ab0c002a6d99815c4adc5",JsonConvert.SerializeObject(jsonValues));
            //await Task.Delay(60000);
            Console.WriteLine("helpppppppppp"); 
*/ 
            Unsplash photo= new Unsplash("6f1f83f0399e8b91d2e5a07b05d65907c452cc90501ab0c002a6d99815c4adc5","");
        
         
            _dataservice.SaveImage(photo.url,id);
                
            return LocalRedirect(Url.Content("~/Page/Page/"+id));
        }
         public IActionResult SaveTitle(InputPageModel Input)
        {
            _dataservice.SaveTitle(Input.Title,Input.Pageid);
                
            return LocalRedirect(Url.Content("~/Page/Page/"+Input.Pageid));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
