using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class Video
    {
        public int VideoID { get; set; }
        public string VideoTitle { get; set; }
        public string VideoFormat { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime CreationDate {get;set;}
        public DateTime VideoLength {get;set;}
        public string VideoFilePath{get;set;}
        
        public virtual ICollection<VideoCollection> VideoCollections { get; set; }
        
     
    }
}