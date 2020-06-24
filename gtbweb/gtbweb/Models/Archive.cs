using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class Archive
    {
        public int ArchiveID { get; set; }
        public int DateArchiveID { get; set; }
        public int  CategoryArchiveID{ get;set;}
        
        public virtual DateArchive DateArchive{get;set;}
        public virtual CategoryArchive CategoryArchive{get;set;}
        
        public virtual ICollection<BlogCollection> BlogCollections { get; set; }
     
    }
}