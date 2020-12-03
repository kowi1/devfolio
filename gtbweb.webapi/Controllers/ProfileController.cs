using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using gtbweb.Models;
using gtbweb.Services;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using  System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;

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
            var videos =  _dataservice.GetVideos("626f8045-c466-4036-876d-99d8ebbbf51a");
             return JsonConvert.SerializeObject(videos);
               //  }  
        
        
             //var profile =  _dataservice.GetProfile(_userManager.GetUserId(User));
           //return new string[] { pi[0].Value, pi[0].Text };
            //return new string[] {" pi.Designation", "pi.About" };
            //  return JsonConvert.SerializeObject("h");
        }

        [  HttpGet("file")]
//public async Task<HttpResponseMessage> Get(string name)
public async Task<FileStreamResult> Get(string name)
   {
    // var stream = await _dataservice.GetVideoByName(name);
     String f=Path.Combine(Directory.GetCurrentDirectory());
     FileStream stream= System.IO.File.OpenRead(Path.Combine(Directory.GetCurrentDirectory().Remove(f.Length-13), @"gtbweb/gtbweb/wwwroot/video",name));
      return new FileStreamResult(stream, "video/mp4");
   /*   var video = new VideoStream(name, "mp4");
 
      //var response = Request.CreateResponse();
      HttpResponseMessage response = new HttpResponseMessage();
      response.Content = new PushStreamContent(video.WriteToStream, new MediaTypeHeaderValue("video/mp4"));
 
      return response;*/
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
public class VideoStream
{
   private readonly string _filename;
 
   public VideoStream(string filename, string ext)
   {
       String f=Path.Combine(Directory.GetCurrentDirectory());
       _filename =Path.Combine(Directory.GetCurrentDirectory().Remove(f.Length-13), @"gtbweb/gtbweb/wwwroot/video",filename,",",ext);
      //_filename = @"C:UsersFilipDownloads" + filename + "."+ext;
   }
 
   public async void WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
   {
   //   try
     // {
      var buffer = new byte[65536];
 
      using (var video = File.Open(_filename, FileMode.Open, FileAccess.Read))
      {
         var length = (int)video.Length;
         var bytesRead = 1;
 
         while (length > 0 && bytesRead > 0)
         {
            bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
            await outputStream.WriteAsync(buffer, 0, bytesRead);
            length -= bytesRead;
         }
      }
     // }
    /*  catch (Exception ex)
      {
         return;
      }
      finally
      {
         outputStream.Close();
      }*/
   }
}
public class VideoOutputFormatter : IOutputFormatter
{
    public bool CanWriteResult(OutputFormatterCanWriteContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        if (context.Object is PushStreamContent)
            return true;

        return false;
    }

    public async Task WriteAsync(OutputFormatterWriteContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        using (var stream = ((PushStreamContent)context.Object))
        {
            var response = context.HttpContext.Response;
            if (context.ContentType != null)
            {
                response.ContentType = context.ContentType.ToString();
            }

            await stream.CopyToAsync(response.Body);
        }
    }
}
}