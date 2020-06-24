using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string    Title { get; set; } 
        public string ServiceDescription { get; set; }    
        public virtual ICollection<ServiceCollection> ServiceCollections { get; set; }
    }
}