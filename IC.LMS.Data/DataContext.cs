using IC.LMS.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IC.LMS.Data
{
  public class DataContext: DbContext
    {
        public DataContext() : base("name=LMSdbconnection") { }

        public DbSet<CompanyInfo> CompanyInfo { get; set; }

        public DbSet<CompanyContactInfo> CompanyContactInfo { get; set; }

      

        public DbSet<CompanyPersonContact> CompanyPersonContact { get; set; }

        public DbSet<ProjectRequirement> ProjectRequirement { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<ProjectReqComment> ProjectReqComment { get; set; }

        public DbSet<Documents> Documents { get; set; }

    }
}
