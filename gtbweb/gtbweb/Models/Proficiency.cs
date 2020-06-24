using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class Proficiency
    {
        public int ProficiencyID { get; set; }
        public int ProfileID { get; set; }
        public int? SkillID { get; set; }
        public int? PercentageScore  { get; set; }
        
        public virtual Skill Skill { get; set; }
        public virtual Profile Profile { get; set; }
       
        public virtual ICollection<ServiceCollection> ServiceCollections { get; set; }
    }
}