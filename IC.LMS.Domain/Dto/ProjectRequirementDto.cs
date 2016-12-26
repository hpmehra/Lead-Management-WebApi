using IC.LMS.Domain.EnumContract;
using System;

namespace IC.LMS.Domain.Dto
{
   public class ProjectRequirementDto
    {
        public int ProjectReqId { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public DateTime RequirementDate { get; set; }
        public int ProjectId { get; set; }        
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string Estimation { get; set; }
        public string ResourceWorking { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public string Technology { get; set; }
      
        public int DocumentId { get; set; }
        public DocumentTypeId DocumentTypeID { get; set; }
        public int FK_PrimaryID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string File { get; set; }
      
        
    }
}
