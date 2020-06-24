using Unsplasharp;
using Unsplasharp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using System;
using Newtonsoft.Json.Linq;
using System.Net;


namespace gtbweb.Services
{
  public class Unsplash
  {
    const string BaseUrl = "https://api.unsplash.com/";

    public string url {get;set;}

     
    public Unsplash(string client_id, string secretKey)
    {
        
         var restClient = new RestClient("https://api.unsplash.com/");

        var restRequest = new RestRequest("photos/random?client_id=6f1f83f0399e8b91d2e5a07b05d65907c452cc90501ab0c002a6d99815c4adc5", Method.GET);
        //restRequest.AddParameter("client_id",client_id, ParameterType.UrlSegment);

        var restResponse = restClient.Execute(restRequest);
        if(restResponse.StatusCode == HttpStatusCode.OK)
    {
        dynamic jsonResponse = JsonConvert.DeserializeObject(restResponse.Content);
       // dynamic api = JObject.Parse(jsonResponse);
        url=jsonResponse.urls.full;
    }
    else
    {
        url="/img/testimonial-2.jpg";
    }
    }
 }
}