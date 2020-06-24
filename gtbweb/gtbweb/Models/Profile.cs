using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace gtbweb.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string UserID { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public string Designation { get; set; }
        public virtual ICollection<Proficiency> Proficiencies { get; set; }
        public virtual ICollection<BlogCollection> BlogCollections { get; set; }
     
    }
}