using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class BlogCollection
    {
        public int BlogCollectionID { get; set; }
        public int ProfileID { get; set; }
        public int BlogPageID { get; set; }
        public int ArchiveID  { get; set; }
        public string PersonalStatement { get; set; }
        
        
        public virtual BlogPage BlogPage { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Archive Archive { get; set; }
       
    }
}