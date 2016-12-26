using IC.LMS.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IC.LMS.Data
{
  public class LMSDataContext: IdentityDbContext
    {
        public LMSDataContext() : base("LMSdbconnection") {
            Database.SetInitializer<LMSDataContext>(null);
        }

        public DbSet<CompanyInfo> CompanyInfo { get; set; }

        public DbSet<CompanyContactInfo> CompanyContactInfo { get; set; }

      

        public DbSet<CompanyPersonContact> CompanyPersonContact { get; set; }

        public DbSet<ProjectRequirement> ProjectRequirement { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<ProjectReqComment> ProjectReqComment { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }

    }
}
