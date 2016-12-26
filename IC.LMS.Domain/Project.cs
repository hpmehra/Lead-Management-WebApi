using IC.LMS.Domain.EnumContract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.LMS.Domain
{
   
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }      
        public int ProjectReqId { get; set; }
        public int CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string Estimation { get; set; }
        public string ResourceWorking { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        [ForeignKey("ProjectReqId")]
        public virtual ProjectRequirement ProjectRequirement { get; set; }
        
    }
}
