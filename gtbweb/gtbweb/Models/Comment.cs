using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public  int ProfileID { get; set; }
        public string Text { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public int? ReplyID { get; set; }


        public virtual Comment Reply { get; set; }
        public virtual Profile Profile { get; set; }

        public virtual ICollection<BlogPage> BlogPages{ get; set; }
        
     
    }
}