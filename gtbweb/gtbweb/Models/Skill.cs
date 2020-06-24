using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string Title { get; set; }
        
        public virtual ICollection<Proficiency> Proficiencies { get; set; }
        
     
    }
}