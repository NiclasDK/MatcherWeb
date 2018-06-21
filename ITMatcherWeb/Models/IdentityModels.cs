using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using ITMatcherWeb.DataContexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITMatcherWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public Boolean Available { get; set; } = true;
        [Display(Name = "Actively seeking")]
        public Boolean ActivelySeeking { get; set; } = true;
        [Display(Name = "Accepted data use")]
        public Boolean AcceptedUseOfData { get; set; } = true;
        [Display(Name = "Expected hourly salary")]
        public int ExpectedHourlySalary { get; set;}
        public Gender Gender { get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "First name")]
        public String FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        public virtual ICollection<JobExperience> JobExperiences { get; set; }
        public virtual ICollection<UserLanguages> Languages { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Clause> Clauses { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }

        private ApplicationDbContext db = new ApplicationDbContext();


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        internal void ExtracttoCsv(string id)
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"First name\",\"Last name\",\"Subjects\",\"Titles\",\"Environments\"");

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=exportedConsultents.csv");
            HttpContext.Current.Response.ContentType = "text/csv";

            var user = db.Users.Find(id);

            sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                user.FirstName,
                user.LastName,
                string.Join(",", user.JobExperiences.SelectMany(j => j.Subjects).Select(s => s.Name).ToList()),
                string.Join(",", user.JobExperiences.SelectMany(j => j.Titles).Select(s => s.TitleName).ToList()),
                string.Join(",", user.JobExperiences.SelectMany(j => j.Environments).Select(s => s.EnvironmentName).ToList())

                ));

            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.End();
        }
    }

    public enum Gender
    {
        Male, Female
    }

}