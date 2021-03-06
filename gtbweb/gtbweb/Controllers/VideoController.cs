using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using gtbweb.Models;
using gtbweb.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
namespace gtbweb.Controllers
{
    public class InputVideoModel
    {
             
             [BindProperty]
              public int Videoid{get;set;}
              
    }
    public class VideoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IDatabaseService  _dataservice;
        
        public VideoController(IDatabaseService  dataservice,UserManager<IdentityUser> userManager,
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
        public async Task<IActionResult> Delete(InputVideoModel Input)
        {
            var videos = await _dataservice.DeleteVideo(Input.Videoid,_userManager.GetUserId(User));
            return LocalRedirect(Url.Content("~/Video/Video/"));
        }

  //[HttpPost("UploadFiles")]
public async Task<IActionResult> Post(IFormFile file)
{   
    var filePath ="hhh";

    if (file != null && file.Length > 0)
     {

    // full path to file in temp location
    //var filePath = Path.GetTempFileName();
    var fileName = Path.GetFileName(file.FileName);
    filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/video", fileName);

    
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
    filePath="dd";
    // process uploaded files
    // Don't rely on or trust the FileName property without validation.
   // var profiles =  _dataservice.GetProfile( _userManager.GetUserId(User));
    var videos =  _dataservice.CreateVideo(1,fileName,"/video/"+fileName);

     }
  
    return Ok(new {filePath});
}
   
[  HttpGet("file")]
   public async Task<FileStreamResult> Get(string name)
   {
     // var stream = await _dataservice.GetVideoByName(name);

     FileStream stream= System.IO.File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/video", "1592832323595.mp4"));
      return new FileStreamResult(stream, "video/mp4");
   }

        public async Task<IActionResult> Video()
        {        
                 if (_signInManager.IsSignedIn(User))
                 {
                           var videos = await _dataservice.GetVideos(_userManager.GetUserId(User));
                           ViewBag.VideoCollection = videos; 
                 }
                
                return View();
        }
       
    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
