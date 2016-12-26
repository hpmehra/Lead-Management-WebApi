using IC.LMS.Business.Contract;
using IC.LMS.Business.FileCabinetCS;
using IC.LMS.Data.Tier.Repository;
using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IC.LMS.Business
{
    public class ProjectRequirementImpl: IProjectRequirement
    {
        private readonly ProjectRequirementRepository objProjectRequirement;
        private readonly ProjectRepository objProject;
        private readonly DocumentRepository objDocument;
     
        public ProjectRequirementImpl()
        {
            objProjectRequirement = new ProjectRequirementRepository();
            objDocument = new DocumentRepository();
            objProject = new ProjectRepository();
          
        }
        public IEnumerable<ProjectRequirement>  GetProjectRequirementAll()
        {
            
            return objProjectRequirement.GetAll();
           
        }

        public int AddProjectRequirement(ProjectRequirementDto projectReqDto)
        {
            if(projectReqDto != null)
            {
                var projectRequirement = Mapper.Map<ProjectRequirement>(projectReqDto);
                
                var projectReqId= objProjectRequirement.Add(projectRequirement).ProjectReqId;
                if (projectReqId > 0)
                {
                    Documents document = new Documents
                    {
                        FK_PrimaryID = projectReqId,
                        DocumentName = projectReqDto.DocumentName,
                        DocumentPath = projectReqDto.DocumentPath,
                        DocumentTypeID = projectReqDto.DocumentTypeID,
                    };
                    objDocument.Add(document);
                    return projectReqId;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return 0;
            }

           
        }


        public ProjectRequirement GetProjectRequirementById(int projectReqId)
        {

            return objProjectRequirement.GetById(projectReqId);
        }

        public IEnumerable<ProjectRequirementDto> GetProjectReqByCompanyId(int companyId)
        {
           
            var projectReq= objProjectRequirement.GetAll();
           var project= objProject.GetAll();
           var data = projectReq.Join(project.Where(x => x.CompanyId == companyId), pr => pr.ProjectReqId, p => p.ProjectReqId, (pr, p) => 
           new ProjectRequirementDto
           {
               ProjectReqId=pr.ProjectReqId,
               ProjectName = pr.ProjectName,         
               Description = pr.Description,
               RequirementDate=pr.RequirementDate,
               Technology = pr.Technology,
               CompanyId = p.CompanyId,
               StartDate = p.StartDate,
               CompletionDate = p.CompletionDate,
               DeadLine = p.DeadLine,
               Estimation=p.Estimation,
               ResourceWorking = p.ResourceWorking,
               ProjectStatus = p.ProjectStatus
           });

            return data;        
        }

        public int UpdateProjectRequirement(ProjectRequirement projectRequirement)
        {
            return objProjectRequirement.Update(projectRequirement);
        }

        public int DeleteProjectRequirement(int projectReqId)
        {
            ProjectRequirement result = objProjectRequirement.GetById(projectReqId);
            if (result != null)
            {
                return objProjectRequirement.Delete(result);
            }
            else
            {
                return 0;
            }
        }
    }
}
