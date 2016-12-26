using IC.LMS.Domain.EnumContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.LMS.Domain
{
 
   
    public class CompanyInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }     
        public string CompanyName { get; set; }
        public int? CompanyTinNo { get; set; }     
        public string CompanyWebsite { get; set; }
        public string SourceName { get; set; }   
        public int? SuccessScore { get; set; }
        public Status? Status { get; set; }
        public Priority? Priority { get; set; }
        public string ContactChannel { get; set; }
        public Stage? Stage { get; set; }
        public string DeadReason { get; set; }
        public string Creator { get; set; }
        public DateTime CreateOn { get; set; }
        public int? EnggOwner { get; set; }
        public int? SalesOwner { get; set; }
        public string Tags { get; set; }
        public string Unavaible { get; set; }
        public int TimeZone { get; set; }
        public virtual ICollection<CompanyContactInfo> CompanyContactInfo { get; set; }
        public virtual ICollection<CompanyPersonContact> CompanyPersonContact { get; set; }
        public virtual ICollection<ProjectRequirement> ProjectRequirement { get; set; }

    }
}
