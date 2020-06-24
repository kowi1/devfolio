using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace gtbweb.Models
{
    public static class AboutInitializer 
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            AboutDbContext context = serviceScope.ServiceProvider.GetRequiredService<AboutDbContext>();
            var profiles = new List<Profile>
            {
            new Profile{UserID="1055",About="Alex",Image="/img/testimonial-2.jpg", RegistrationDate=DateTime.Parse("2005-09-01"),Designation="FrontEnd"},
            new Profile{UserID="1040",About="Alexander",Image="/img/testimonial-2.jpg", RegistrationDate=DateTime.Parse("2007-02-07"),Designation="Backend Developer"}
            };

            profiles.ForEach(s => context.Profiles.Add(s));
            context.SaveChanges();
            var skills = new List<Skill>
            {
            new Skill{Title="HTML"},
            new Skill{Title="PHP"}
            };
            skills.ForEach(s => context.Skills.Add(s));
            context.SaveChanges();
            var proficiencies = new List<Proficiency>
            {
            new Proficiency{ProfileID=13,SkillID=11,PercentageScore=0},
            new Proficiency{ProfileID=14,SkillID=12,PercentageScore=100},
            };
            proficiencies.ForEach(s => context.Proficiencies.Add(s));
            context.SaveChanges();
        }
    }
}