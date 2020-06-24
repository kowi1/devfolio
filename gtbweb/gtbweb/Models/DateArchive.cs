using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class DateArchive
    {
        public int DateArchiveID { get; set; }

         [DataType(DataType.Date)]
        public DateTime DateArchiveName { get; set; }
        
        public virtual ICollection<Archive> Archives{ get; set; }
        
     
    }
}