using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITMatcherWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public Boolean Available { get; set; }
        public Boolean ActivelySeeking { get; set; }
        public Boolean AcceptedUseOfData { get; set; }
        [Display(Name = "Expected hourly salary")]
        public int ExpectedHourlySalary { get; set;}
        public Boolean Gender { get; set;}
        public DateTime? DateOfBirth { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<JobExperience> JobExperiences { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Education> Educations { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


    }

}