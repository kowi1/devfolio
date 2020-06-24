using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class ServiceCollection
    {
        public int ServiceCollectionID { get; set; }
        public int ServiceID { get; set; }
        public int? ProficiencyID { get; set; }
        
   
    
        
        public virtual Service Service { get; set; }
        public virtual Proficiency Proficiency { get; set; }
     
    }
}