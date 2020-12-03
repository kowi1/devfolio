using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using gtbweb.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace gtbweb.Services
{
        public interface IDatabaseService
        {    List<SelectListItem> GetSkills();
             Profile GetProfile(string userid);
             //FileStream GetVideoByName(string name);
             List<ProficiencyViewModel> GetProficiency(string userid);
             List<RecentPostViewModel> GetRecentPosts(string userid);
             ServiceCollectionViewModel GetService(string userid);
             BlogCollectionViewModel GetBlogs(string userid);
             Task<VideoCollectionViewModel> GetVideos(string userid);
             Task<bool> DeleteVideo(int id,string userid);
             BlogCollectionViewModel SearchBlogs(string search,string userid);
             BlogCollectionViewModel SearchDateArchive(int? id,string userid);
             BlogCollectionViewModel SearchCategoryArchive(int? id,string userid);
             BlogCollectionViewModel GetRecentBlogs(string userid);
             BlogPageViewModel GetBlogPage(int? blogpageid,string userid);
             PortfolioCollectionViewModel  GetPortfolio(string userid);
             List<DateArchiveViewModel> GetDateArchive(string userid);
             List<CategoryArchiveViewModel> GetCategoryArchive(string userid);
             int CreateBlogPage(int profileid);
             int CreateVideo(int profileid,string filename,string filepath);
             void SaveBlogText(string Editortext, string pageid);
             void SaveTitle(string Title, string pageid);
             void SaveImage(string url, int id);
             void SaveAbout(string about, string userid);
             void SaveDesignation(string designation, string userid);
             void SaveProficiency(int skillid,int score, int profileid);
        }
        public class ServiceCollectionViewModel
        {
         
           public  string   Slogan { get; set; }
           public  ICollection<ServiceViewModel>  ServiceView { get; set; }
           
        }
        public class ProficiencyViewModel
        {
         
           public  string   Skill { get; set; }
           public  int      Score { get; set; }
           
        }
        public class ServiceViewModel
        {
         
           public  string   Title { get; set; }
           public  string   ServiceDescription { get; set; }
           
        }
        public class PortfolioViewModel
        {
           public  string   Title { get; set; }
           public  string   Tag { get; set; }
           public  string   PortfolioImage { get; set; }
           public  DateTime CreationDate { get; set; }
        }
         public class BlogCollectionViewModel
        {
          
           public  string   Slogan { get; set; }
           public  ICollection<BlogPageViewModel>  BlogView { get; set; }
        }
         public class VideoCollectionViewModel
        {
          
           public  string   Slogan { get; set; }
           public  ICollection<VideoViewModel>  VideoView { get; set; }
        }
        public class PortfolioCollectionViewModel
        {
           public  string   Slogan { get; set; }
           public  int   WorksCompleted { get; set; }
           public  int   AwardsWon { get; set; }
           public  int   TotalClients { get; set; }
           public  int  YearsOfExperience { get; set; }
           public  ICollection<PortfolioViewModel>  Portfolio { get; set; }
        }
         public class BlogPageViewModel
        {  public  int      ProfileID  { get; set; }
           public  int      BlogPageID  { get; set; }
           public  string   BlogImage  { get; set; }
           public  string   Title { get; set; }
           public  string   FullName { get; set; }
           public  string   PageTag { get; set; }
           public  int   ReadTime { get; set; }
           public  TagCollectionViewModel   TagCollection { get; set; }
           public  int   CommentCount { get; set; }
           public  string   Text { get; set; }
           //public  string  Author { get; set; }
           public  ICollection<RecentPostViewModel>  RecentPost { get; set; }
           public  ICollection<CommentViewModel>  Comments { get; set; }
           public  ArchiveViewModel  Archive { get; set; }
        }
         public class VideoViewModel
        {  public  int      ProfileID  { get; set; }
           public  int      VideoID  { get; set; }
           public  string   VideoFilePath  { get; set; }
           public  string   VideoTitle { get; set; }
           [DataType(DataType.Time)]
           public  DateTime   VideoLength { get; set; }
        }
         public class RecentPostViewModel
         {
            public int PostID { get; set; }
            public  string   Title { get; set; }
         }
          public class ReplyViewModel
         {
            public int CommentID { get; set; }
            public  string   Text { get; set; }
            public  string   Image { get; set; }
            public  string   FullName { get; set; }
 
            public DateTime CreationDate { get; set; }

            public ICollection<CommentViewModel>  Reply{ get; set; }
         }
          public class CommentViewModel
         {
            public int CommentID { get; set; }
            public  string   Text { get; set; }
            public  string   Image { get; set; }
            public  string   FullName { get; set; }
 
            public DateTime CreationDate { get; set; }

            public ICollection<ReplyViewModel>  Reply{ get; set; }
         }
         public class TagCollectionViewModel
         {
            public int TagCollectionID { get; set; }
           public  ICollection<TagViewModel>  TagList { get; set; }
         }
         public class TagViewModel
         {
            public  string   Title { get; set; }
         }
         public class DateArchiveViewModel
         {  
            public int DateArchiveID { get; set; }
            public string DateArchiveName { get; set; }
           
         }
         public class CategoryArchiveViewModel
         {
            public int CategoryArchiveID { get; set; }
            public string CategoryName { get; set; }
           
         }
         public class ArchiveViewModel
         {  
            public int ArchiveID { get; set; }
            public  ICollection<DateArchiveViewModel>  DateArchive { get; set; }
            public  ICollection<CategoryArchiveViewModel>  CategoryArchive { get; set; }
            
         }
        public class Seed
         {
            public List<RecentPostViewModel> posts { get; set; }
            public List<BlogPageViewModel> pages { get; set; }
            public BlogPageViewModel page { get; set; }
            public TagCollectionViewModel tagcollection { get; set; }
            public ICollection<CommentViewModel> commentlist { get; set; }
            public ICollection<ReplyViewModel> commentlists { get; set; }
            public ICollection<TagViewModel> taglist { get; set; }
            public BlogCollectionViewModel blogs { get; set; }
            public ServiceCollectionViewModel services { get; set; }
            public ICollection<ServiceViewModel> servicelist { get; set; }
            public PortfolioCollectionViewModel portfolios { get; set; }
            public ICollection<PortfolioViewModel> portfoliolist { get; set; }
            public ICollection<DateArchiveViewModel> datearchivelist {get;set;}
            public ICollection<CategoryArchiveViewModel> categoryarchivelist {get;set;}
            public ArchiveViewModel archiveitem {get;set;}
            public VideoCollectionViewModel videos{get;set;}
            public ICollection<VideoViewModel> videolist {get;set;}
            public Seed()
            {
                    datearchivelist = new List<DateArchiveViewModel>
                     {
                           new DateArchiveViewModel{DateArchiveID=1,DateArchiveName="October"},
                          new DateArchiveViewModel{DateArchiveID=1,DateArchiveName="November"},
                     };
                     categoryarchivelist = new List<CategoryArchiveViewModel>
                     {
                           new CategoryArchiveViewModel{CategoryArchiveID=1,CategoryName="October"},
                           new CategoryArchiveViewModel{CategoryArchiveID=1,CategoryName="November"},
                     };
                   taglist = new List<TagViewModel>
                     {
                           new TagViewModel{Title="Alex"},
                           new TagViewModel{Title="Alex"}
                     };
                    tagcollection = new TagCollectionViewModel{TagCollectionID=1,TagList=taglist };
                    archiveitem = new ArchiveViewModel {DateArchive=datearchivelist,CategoryArchive=categoryarchivelist };
                    posts = new List<RecentPostViewModel>
                     {
                           new RecentPostViewModel{PostID=2,Title="Alex"},
                           new RecentPostViewModel{PostID=3, Title="Alexander"}
                     };
                      commentlist = new List<CommentViewModel>
                              {
                                    new CommentViewModel{CommentID=1,Text="Alex",Image="/img/testimonial-2.jpg",FullName="Alex",CreationDate=DateTime.Parse("2005-09-01"),Reply=commentlists},
                                    new CommentViewModel{CommentID=2,Text="Alex",Image="/img/testimonial-2.jpg",FullName="Alex",CreationDate=DateTime.Parse("2005-09-01"),Reply=commentlists}
                              };
                     commentlists = new List<ReplyViewModel>
                              {
                                    new ReplyViewModel{CommentID=1,Text="Alex",Image="/img/testimonial-2.jpg",FullName="Alex",CreationDate=DateTime.Parse("2005-09-01"),Reply=null},
                                    new ReplyViewModel{CommentID=2,Text="Alex",Image="/img/testimonial-2.jpg",FullName="Alex",CreationDate=DateTime.Parse("2005-09-01"),Reply=null}
                              };
                    pages = new List<BlogPageViewModel>
                     {
                           new BlogPageViewModel{ProfileID=1,BlogPageID=1,BlogImage="/img/testimonial-2.jpg",Title="Alex",FullName="Alex",PageTag="Alex",ReadTime=20,TagCollection=tagcollection,CommentCount=30,Text="FrontEnd",RecentPost=posts,Comments=commentlist,Archive=archiveitem},
                           new BlogPageViewModel{ProfileID=1,BlogPageID=1,BlogImage="/img/testimonial-2.jpg",Title="Alex",FullName="Alex",PageTag="Alex",ReadTime=30,TagCollection=tagcollection,CommentCount=30,Text="FrontEnd",RecentPost=posts,Comments=commentlist,Archive=archiveitem}
                     };
                     videolist = new List<VideoViewModel>
                     {
                           new VideoViewModel{ProfileID=1,VideoID=1,VideoFilePath="/img/testimonial-2.jpg",VideoTitle="Alex",VideoLength=DateTime.Parse("2005-09-01")},
                           new VideoViewModel{ProfileID=1,VideoID=1,VideoFilePath="/img/testimonial-2.jpg",VideoTitle="Alex",VideoLength=DateTime.Parse("2005-09-01")}
                     };
                    servicelist = new List<ServiceViewModel>
                     {
                           new ServiceViewModel{Title="Web design",ServiceDescription="Artful Design is not an accident,it requires Art. "},
                           new ServiceViewModel{Title="Photography",ServiceDescription="A thousand words caught in the stillness of a flash"}
                     };
                    portfoliolist = new List<PortfolioViewModel>
                     {
                           new PortfolioViewModel{Title="Web design",Tag="Alex",PortfolioImage="/img/work-1.jpg",CreationDate=DateTime.Parse("2005-09-01")},
                           new PortfolioViewModel{Title="Web design",Tag="Alex",PortfolioImage="/img/work-2.jpg",CreationDate=DateTime.Parse("2005-09-01")}
                     };
                   page= new BlogPageViewModel{ProfileID=1,BlogPageID=1,BlogImage="/img/testimonial-2.jpg",Title="Alex",FullName="Alex",PageTag="Alex",ReadTime=30,TagCollection=tagcollection,CommentCount=30,Text="Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Cras ultricies ligula sed magna dictum porta. Quisque velit nisi, pretium ut lacinia in, elementum id enim. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Nulla quis lorem ut libero malesuada feugiat.",RecentPost=posts,Comments=commentlist,Archive=archiveitem};          
                   blogs= new BlogCollectionViewModel{Slogan="Creativity Has no Limits",BlogView=pages};
                   videos= new VideoCollectionViewModel{Slogan="Creativity Has no Limits",VideoView=videolist};
                   services= new ServiceCollectionViewModel{Slogan="Creativity Has no Limits",ServiceView=servicelist};
                   portfolios= new PortfolioCollectionViewModel{Slogan="Creativity Has no Limits",WorksCompleted=20,AwardsWon=4,TotalClients=9,YearsOfExperience=12, Portfolio=portfoliolist};
            
            }
         }

        public class DatabaseService: IDatabaseService
        {
            private readonly VideoDbContext  _theContext;

            public DatabaseService(VideoDbContext _context )
            {
              
                   _theContext=_context;
                  
                   
            }
            

             public List<SelectListItem> GetSkills()
             {
                var profile =  _theContext.Skills.Select(s =>
                new SelectListItem{
                          Value=s.SkillID.ToString(),
                          Text=s.Title
                }).ToList();
                 return profile;
             }
             public List<ProficiencyViewModel> GetProficiency(string userid)
             {
                var profile =  _theContext.Proficiencies.Where(s=>s.Profile.UserID==userid)
                                                      .Select(s =>
                                                      new ProficiencyViewModel{
                                                               Skill=s.Skill.Title,
                                                               Score=s.PercentageScore ?? 0
                                                      }).ToList();
                 return profile;
             }
             public Profile GetProfile(string userid)
             {
                var profile =  _theContext.Profiles.Where(s => s.UserID == userid).FirstOrDefault<Profile>();
                 return profile;
             }
             public ServiceCollectionViewModel  GetService(string userid)
             {
                   IEnumerable<gtbweb.Models.ServiceCollection> collections = _theContext.ServiceCollections;
                   IEnumerable<Service> services = _theContext.Services;
                   var querys = collections.Where(s =>s.Proficiency.Profile.UserID == userid )
                                           .Select(s=>s.Service)
                                           .Select(s=> 
                                              new ServiceViewModel
                                              {
                                                 Title =s.Title,
                                                 ServiceDescription=s.ServiceDescription
                                              }
                                           ).ToList();//.FirstOrDefault<Service>();
                   var query = new Seed().services;
                   query.ServiceView = querys;
                   return query;
             }
                public List<DateArchiveViewModel> GetDateArchive(string userid)
             {
                   IEnumerable<BlogCollection> collections = _theContext.BlogCollections;
                  
                   var querys = collections.Where(s =>s.BlogPage.Profile.UserID == userid )
                                           .Select(s=>s.BlogPage.DateArchive).Distinct()
                                           .Select(s=> 
                                              new DateArchiveViewModel
                                              {  DateArchiveID=s.DateArchiveID,
                                                 DateArchiveName =s.DateArchiveName.ToString()
                                                 
                                              }
                                           ).ToList();//.FirstOrDefault<Service>();
                  
                   return querys;
             }
                public List<CategoryArchiveViewModel> GetCategoryArchive(string userid)
             {
                   IEnumerable<BlogCollection> collections = _theContext.BlogCollections;
                  
                   var querys = collections.Where(s =>s.BlogPage.Profile.UserID == userid )
                                           .Select(s=>s.BlogPage.CategoryArchive).Distinct()
                                           .Select(s=> 
                                              new CategoryArchiveViewModel
                                              {
                                                 CategoryArchiveID=s.CategoryArchiveID,
                                                 CategoryName =s.CategoryName.ToString()
                                                 
                                              }
                                           ).ToList();//.FirstOrDefault<Service>();
                  
                   return querys;
             }
              public BlogCollectionViewModel SearchBlogs(string search,string userid)
             {
                   IEnumerable<BlogCollection> collections = _theContext.BlogCollections;
                   IEnumerable<Service> services = _theContext.Services;
                   Seed temp= new Seed();
                   var querys = collections.Where(s =>s.BlogPage.HeaderTitle.Contains(search))
                                            .Select(s=>s.BlogPage)
                                            .Select(s=> 
                                            new BlogPageViewModel{ProfileID=1,
                                            BlogPageID=s.BlogPageID,
                                            BlogImage=s.HeaderImage,
                                            Title=s.HeaderTitle,
                                            FullName=s.Profile.FirstName+" "+s.Profile.LastName,
                                            PageTag="Alex",
                                            ReadTime=30,
                                            TagCollection=temp.tagcollection,
                                            CommentCount=30,
                                            Text=s.Text,
                                            RecentPost=GetRecentPosts(userid),
                                            Comments=temp.commentlist,
                                            Archive=new ArchiveViewModel{DateArchive=GetDateArchive(userid),CategoryArchive=GetCategoryArchive(userid)}
                                            }        
                                            ).ToList();
                   var query = new Seed().blogs;
                   query.BlogView = querys;
                   return query;
             }
               public BlogCollectionViewModel SearchDateArchive(int? id,string userid)
             {
                   IEnumerable<BlogCollection> collections = _theContext.BlogCollections;
                   IEnumerable<Service> services = _theContext.Services;
                   Seed temp= new Seed();
                   var querys = collections.Where(s =>s.BlogPage.DateArchiveID== id && s.BlogPage.Profile.UserID == userid  )
                                            .Select(s=>s.BlogPage)
                                            .Select(s=> 
                                            new BlogPageViewModel{ProfileID=1,
                                            BlogPageID=s.BlogPageID,
                                            BlogImage=s.HeaderImage,
                                            Title=s.HeaderTitle,
                                            FullName=s.Profile.FirstName+" "+s.Profile.LastName,
                                            PageTag="Alex",
                                            ReadTime=30,
                                            TagCollection=temp.tagcollection,
                                            CommentCount=30,
                                            Text=s.Text,
                                            RecentPost=GetRecentPosts(userid),
                                            Comments=temp.commentlist,
                                            Archive=new ArchiveViewModel{DateArchive=GetDateArchive(userid),CategoryArchive=GetCategoryArchive(userid)}
                                            }        
                                            ).ToList();
                   var query = new Seed().blogs;
                   query.BlogView = querys;
                   return query;
             }
                public BlogCollectionViewModel SearchCategoryArchive(int? id,string userid)
             {
                   IEnumerable<BlogCollection> collections = _theContext.BlogCollections;
                   IEnumerable<Service> services = _theContext.Services;
                   Seed temp= new Seed();
                   var querys = collections.Where(s =>s.BlogPage.CategoryArchiveID== id && s.BlogPage.Profile.UserID == userid  )
                                            .Select(s=>s.BlogPage)
                                            .Select(s=> 
                                            new BlogPageViewModel{ProfileID=1,
                                            BlogPageID=s.BlogPageID,
                                            BlogImage=s.HeaderImage,
                                            Title=s.HeaderTitle,
                                            FullName=s.Profile.FirstName+" "+s.Profile.LastName,
                                            PageTag="Alex",
                                            ReadTime=30,
                                            TagCollection=temp.tagcollection,
                                            CommentCount=30,
                                            Text=s.Text,
                                            RecentPost=GetRecentPosts(userid),
                                            Comments=temp.commentlist,
                                            Archive=new ArchiveViewModel{DateArchive=GetDateArchive(userid),CategoryArchive=GetCategoryArchive(userid)}
                                            }        
                                            ).ToList();
                   var query = new Seed().blogs;
                   query.BlogView = querys;
                   return query;
             }
              public BlogCollectionViewModel GetBlogs(string userid)
             {
                   IEnumerable<BlogCollection> collections = _theContext.BlogCollections;
                   IEnumerable<Service> services = _theContext.Services;
                   Seed temp= new Seed();
                   var querys = collections.Where(s =>s.Profile.UserID == userid )
                                            .Select(s=>s.BlogPage)
                                            .Select(s=> 
                                            new BlogPageViewModel{ProfileID=1,
                                            BlogPageID=s.BlogPageID,
                                            BlogImage=s.HeaderImage,
                                            Title=s.HeaderTitle,
                                            FullName=s.Profile.FirstName+" "+s.Profile.LastName,
                                            PageTag="Alex",
                                            ReadTime=30,
                                            TagCollection=temp.tagcollection,
                                            CommentCount=30,
                                            Text=s.Text,
                                            RecentPost=GetRecentPosts(userid),
                                            Comments=temp.commentlist
                                            }        
                                            ).ToList();
                   var query = new Seed().blogs;
                   query.BlogView = querys;
                   return query;
             }
             public async Task<VideoCollectionViewModel> GetVideos(string userid)
             {
                   IEnumerable<VideoCollection> collections = _theContext.VideoCollections;
                   IEnumerable<Service> services = _theContext.Services;
                   Seed temp= new Seed();
                   var querys = collections.Where(s =>s.Profile.UserID == userid )
                                            .Select(s=>s.Video)
                                            .Select(s=> 
                                            new VideoViewModel{ProfileID=1,
                                            VideoID=s.VideoID,
                                            VideoTitle=s.VideoTitle,
                                            VideoFilePath=s.VideoFilePath,
                                            VideoLength=s.VideoLength
                                            }        
                                            ).ToList();
                   var query = new Seed().videos;
                   query.VideoView = querys;
                   return query;
             }
               public BlogCollectionViewModel GetRecentBlogs(string userid)
             {
                   IEnumerable<BlogCollection> collections = _theContext.BlogCollections;
                   IEnumerable<Service> services = _theContext.Services;
                   Seed temp= new Seed();
                   var querys = collections.OrderByDescending(s=>s.BlogPage.CreationDate)
                                            .Select(s=>s.BlogPage)
                                            .Select(s=> 
                                            new BlogPageViewModel{ProfileID=1,
                                            BlogPageID=s.BlogPageID,
                                            BlogImage=s.HeaderImage,
                                            Title=s.HeaderTitle,
                                            FullName=s.Profile.FirstName+" "+s.Profile.LastName,
                                            PageTag="Alex",
                                            ReadTime=30,
                                            TagCollection=temp.tagcollection,
                                            CommentCount=30,
                                            Text=s.Text,
                                            RecentPost=GetRecentPosts(userid),
                                            Comments=temp.commentlist
                                            }        
                                            ).ToList();
                   var query = new Seed().blogs;
                   query.BlogView = querys;
                   return query;
             }
              public PortfolioCollectionViewModel GetPortfolio(string userid)
             {
                   IEnumerable<BlogCollection> collections = _theContext.BlogCollections;
                   IEnumerable<Service> services = _theContext.Services;
                   var querys = collections.Where(s =>s.ProfileID == 1 ).FirstOrDefault<BlogCollection>();
                   var query = new Seed().portfolios;
                   return query;
             }
               public List<RecentPostViewModel> GetRecentPosts(string userid)
             {
                   IEnumerable<BlogPage> collections = _theContext.BlogPages;
                   
                   var querys = collections.Where(s =>s.Profile.UserID== userid)
                                           .Select(s=>
                                           new RecentPostViewModel{
                                            PostID=s.BlogPageID,
                                            Title=s.HeaderTitle
                                           }).ToList();
                  // var query = new Seed().portfolios;
                   return querys;
             }
            
              public BlogPageViewModel GetBlogPage(int? blogpageid,string userid)
             {
                   IEnumerable<BlogPage> collections = _theContext.BlogPages;
                   IEnumerable<Service> services = _theContext.Services;
                   Seed temp= new Seed();
                   var blogpage = collections.Where(s =>s.BlogPageID == blogpageid )
                                              .Select(s=>
                                                      new BlogPageViewModel{
                                           ProfileID=s.ProfileID,
                                           Title=s.HeaderTitle,
                                           BlogImage=s.HeaderImage,
                                           Text=s.Text,
                                           FullName=s.Profile.FirstName+" "+s.Profile.LastName,
                                           PageTag="Alex",
                                           ReadTime=30,
                                           CommentCount=30,
                                           TagCollection=temp.tagcollection,
                                           BlogPageID=s.BlogPageID,
                                           RecentPost=GetRecentPosts(userid),
                                           Comments=temp.commentlist,
                                           Archive= new ArchiveViewModel{DateArchive=GetDateArchive(userid),CategoryArchive=GetCategoryArchive(userid)}
                                           }).ToList().FirstOrDefault<BlogPageViewModel>();
                   //var pageview = new Seed().page;
                  
                   /* new BlogPageViewModel{ProfileID=1,
                                      BlogImage="/img/testimonial-2.jpg",
                                      Title="Alex",
                                      FullName="Alex",
                                      PageTag="Alex",
                                      ReadTime=20,
                                      TagCollection=tagcollection,
                                      CommentCount=30,
                                      Text="FrontEnd",
                                      RecentPost=posts,
                                      Comments=commentlist};
                   */
                   return blogpage;
             }
             public void SaveBlogText(string editortext,string pageid)
             {
              var page =  _theContext.BlogPages.Where(s => s.BlogPageID == Convert.ToInt32(pageid)).FirstOrDefault<BlogPage>();
              page.Text=editortext;
              _theContext.SaveChanges();
             }
             public void SaveAbout(string about,string userid)
             {
              var profile =  _theContext.Profiles.Where(s => s.UserID == userid).FirstOrDefault<Profile>();
              profile.About=about;
              _theContext.SaveChanges();
             }
              public void SaveDesignation(string designation,string userid)
             {
              var profile =  _theContext.Profiles.Where(s => s.UserID == userid).FirstOrDefault<Profile>();
              profile.Designation = designation;
              _theContext.SaveChanges();
             }
               public void SaveTitle(string Title,string pageid)
             {
             var page =  _theContext.BlogPages.Where(s => s.BlogPageID == Convert.ToInt32(pageid)).FirstOrDefault<BlogPage>();
              page.HeaderTitle=Title;
              _theContext.SaveChanges();
             }
              public void SaveImage(string url,int id)
             {
             var page =  _theContext.BlogPages.Where(s => s.BlogPageID == id).FirstOrDefault<BlogPage>();
              page.HeaderImage=url;
              _theContext.SaveChanges();
             }
              public void SaveProficiency(int skillid,int score,int profileid)
             {
              var proficiencycontext =  _theContext.Proficiencies;
               var proficiencyitem = new Proficiency
               {
                  ProfileID=profileid,
                  SkillID=skillid,
                  PercentageScore=score
               };
             proficiencycontext.Add(proficiencyitem);
              _theContext.SaveChanges();
             }
              public int CreateBlogPage(int profileid)
             {
              var blogpagecontext =  _theContext.BlogPages;
              var archivecontext=  _theContext.Archives;
              var blogcollectioncontext =  _theContext.BlogCollections;
               var timestamp=DateTime.Now;
               var blogitem = new BlogPage
               {
                  ProfileID=profileid,
                  TagID=1,
                  DateArchiveID=1,
                  CategoryArchiveID=1,
                  HeaderTitle="Fill Title",
                  HeaderImage="/img/testimonial-2.jpg",
                  CreationDate=timestamp,
                  LastEditDate=DateTime.Now,
                  Text="<h2 class=\"dfree-header mce-content-body\" contenteditable=\"true\" style=\"position: relative;\" spellcheck=\"false\">Add a Title</h2><br/><div class=\"dfree-body mce-content-body\" contenteditable=\"true\" style=\"position: relative;\" spellcheck=\"false\"><p><img src=\"\" style=\"display: block; margin-left: auto; margin-right: auto; width: 100%;\" data-mce-style=\"display: block; margin-left: auto; margin-right: auto;\" data-mce-selected=\"1\">Add Image</p><br/><h2>Add header.</h2><p>Have you heard about Tiny Cloud?   It’s the first step in our journey to help you deliver great content creation experiences, no matter your level of expertise. 50,000 developers already agree. They get free access to our global CDN, image proxy services and auto updates to the TinyMCE editor. They’re also ready for some exciting updates coming soon.</p>  <p>One of these enhancements is <strong>Tiny Drive</strong>: imagine file management for TinyMCE, in the cloud, made super easy. Learn more at <a href='https://www.tiny.cloud/tinydrive/'>tiny.cloud/tinydrive</a>, where you’ll find a working demo and an opportunity to provide feedback to the product team. </p><h3>An editor for every project</h3> <p>  Here are some of our customer’s most common use cases for TinyMCE:  <ul><li>Content Management Systems (<em>e.g. WordPress, Umbraco</em>)</li> <li>Learning Management Systems (<em>e.g. Blackboard</em>)</li>  <li>Customer Relationship Management and marketing automation (<em>e.g. Marketo</em>)</li> <li>Email marketing (<em>e.g. Constant Contact</em>)</li><li>Content creation in SaaS systems (<em>e.g. Eventbrite, Evernote, GoFundMe, Zendesk</em>)</li></ul> </p> <p>  And those use cases are just the start. TinyMCE is incredibly flexible, and with hundreds of APIs there’s likely a solution for your editor project.    If you haven’t experienced Tiny Cloud, get started today.   You’ll even get a free trial of our premium plugins – no credit card required! </p></div>"
               };
            blogpagecontext.Add(blogitem);
              _theContext.SaveChanges();
              var newpage =_theContext.BlogPages.Where(s=>s.CreationDate==timestamp ).FirstOrDefault<BlogPage>();
              
              
                 var blogCollection=new BlogCollection
                 {
                    ProfileID=profileid,
                    BlogPageID=newpage.BlogPageID,
                    PersonalStatement="Statement",
                    ArchiveID=1
                 };
                 blogcollectioncontext.Add(blogCollection);
                  _theContext.SaveChanges();


              return newpage.BlogPageID;
             }
             public async Task<bool> DeleteVideo(int id, string user)
             {
                  var videocontext =  _theContext.Video;
              var videocollectioncontext =  _theContext.VideoCollections;
                  var videoitem =  _theContext.Video.Where(s=>s.VideoID==id ).FirstOrDefault<Video>();
              var videocollectionitem =  _theContext.VideoCollections.Where(s=>s.VideoID==id ).FirstOrDefault<VideoCollection>();
                  videocontext.Remove(videoitem);
                  videocollectioncontext.Remove(videocollectionitem);
                  _theContext.SaveChanges();
                  return true;
             }
             public int CreateVideo(int profileid,string filename,string filepath)
             {
              var videocontext =  _theContext.Video;
              var videocollectioncontext =  _theContext.VideoCollections;
               var timestamp=DateTime.Now;
               var videoitem = new Video
               {
                  
                  VideoFormat="mp4",
                  VideoTitle=filename,
                  CreationDate=timestamp,
                  VideoLength=DateTime.Now,
                  VideoFilePath=filepath,
               };
            videocontext.Add(videoitem);
              _theContext.SaveChanges();
             var newvideo =_theContext.Video.Where(s=>s.CreationDate==timestamp ).FirstOrDefault<Video>();
              
              
                 var VideoCollection=new VideoCollection
                 {  
                    
                    ProfileID=profileid,
                    VideoID=newvideo.VideoID,
                    CreativePurpose="Statement"
                    
                 };
                 videocollectioncontext.Add(VideoCollection);
                  _theContext.SaveChanges();


              return newvideo.VideoID;
             }
        } 
}