using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Title { get; set; }
        
        public virtual ICollection<BlogPage> BlogPage{ get; set; }
        
     
    }
}