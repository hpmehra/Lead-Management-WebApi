using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using System.Collections.Generic;

namespace IC.LMS.Business.Contract
{
    public  interface IProjectRequirement
    {
        IEnumerable<ProjectRequirement> GetProjectRequirementAll();
        int AddProjectRequirement(ProjectRequirementDto projectReqDto);
        ProjectRequirement GetProjectRequirementById(int projectReqId);
        IEnumerable<ProjectRequirementDto> GetProjectReqByCompanyId(int companyId);       
        int UpdateProjectRequirement(ProjectRequirement projectRequirement);
        int DeleteProjectRequirement(int projectReqId);
    }
}
