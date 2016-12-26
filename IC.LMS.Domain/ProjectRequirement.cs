using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.LMS.Domain
{
    public class ProjectRequirement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectReqId { get; set; }
        public string ProjectName { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public DateTime RequirementDate { get; set; }
        public string Technology { get; set; }
        [ForeignKey("CompanyId")]
        public virtual CompanyInfo CompanyInfo { get; set; }
        public virtual ICollection<ProjectReqComment> ProjectReqComment { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
        public virtual ICollection<Project> Project { get; set; }

    }
}
