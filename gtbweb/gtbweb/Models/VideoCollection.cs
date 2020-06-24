using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class VideoCollection
    {
        public int VideoCollectionID { get; set; }
        public int ProfileID { get; set; }
        public int VideoID { get; set; }
        public string CreativePurpose { get; set; }
        
        public virtual Profile Profile { get; set; }
        public virtual Video Video { get; set; }
        
        
     
    }
}