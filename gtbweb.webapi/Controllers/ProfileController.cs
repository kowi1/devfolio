using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using gtbweb.Models;
using gtbweb.Services;
using Newtonsoft.Json;



namespace gtbweb.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private IDatabaseService _dataservice;
        public ProfileController(IDatabaseService dataservice)
        {
              _dataservice= dataservice;      
        }

        
        // GET api/profile
        [HttpGet]
        public ActionResult<string> Get()
        {
             var pi =  _dataservice.GetSkills();

           //return new string[] { pi[0].Value, pi[0].Text };
            //return new string[] {" pi.Designation", "pi.About" };
            return JsonConvert.SerializeObject(pi);
        }

        // GET api/profile/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/profile
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

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
