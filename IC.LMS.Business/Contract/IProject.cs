using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using System.Collections.Generic;

namespace IC.LMS.Business.Contract
{
   public interface IProject
    {
        IEnumerable<Project> GetProjectAll();
        int AddProject(ProjectRequirementDto projectReqDto);
        Project GetProjectById(int projectId);
        Project GetProjectByProjectReqId(int projectReqId);
        int UpdateProject(Project project);
        int DeleteProject(int projectId);
    }
}
