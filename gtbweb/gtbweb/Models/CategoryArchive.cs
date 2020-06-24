using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class CategoryArchive
    {
        public int CategoryArchiveID { get; set; }
        public string CategoryName { get; set; }
        
        public virtual ICollection<Archive> Archives{ get; set; }
        
     
    }
}