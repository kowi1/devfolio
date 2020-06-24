using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Filters;

namespace gtbweb.Services
{  
    public class NoDirectAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var canAcess= false;

            // check the refer
            var referer= filterContext.HttpContext.Request.Headers["Referer"].ToString(); 
            if(!string.IsNullOrEmpty(referer)){
                var rUri = new System.UriBuilder(referer).Uri;
                var req = filterContext.HttpContext.Request;
                if(req.Host.Host==rUri.Host && req.Host.Port == rUri.Port && req.Scheme == rUri.Scheme ){
                    canAcess=true;
                }
            }

            // ... check other requirements

            if(!canAcess){
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", area = "" })); 
            }
        }
    }
}