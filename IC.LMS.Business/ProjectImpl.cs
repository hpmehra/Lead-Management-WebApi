using IC.LMS.Business.Contract;
using IC.LMS.Data.Tier.Repository;
using IC.LMS.Domain;
using IC.LMS.Domain.Dto;
using Omu.ValueInjecter;
using System.Collections.Generic;

namespace IC.LMS.Business
{
    public class ProjectImpl:IProject
    {
        private readonly ProjectRepository projectObj;

        public ProjectImpl()
        {
            projectObj = new ProjectRepository();
        }
        public IEnumerable<Project> GetProjectAll()
        {
            return projectObj.GetAll();
        }

        public int AddProject(ProjectRequirementDto projectReqDto)
        {
            if (projectReqDto != null)
            {
                var project = Mapper.Map<Project>(projectReqDto);
                return projectObj.Add(project).ProjectId;
            }
            else
            {
                return 0;
            }         
        }


        public Project GetProjectById(int projectId)
        {
            return projectObj.GetById(projectId);
        }

        public Project GetProjectByProjectReqId(int projectReqId)
        {

            return projectObj.GetById(projectReqId);
        }

        public int UpdateProject(Project project)
        {
            return projectObj.Update(project);
        }

        public int DeleteProject(int projectId)
        {
            Project result = projectObj.GetById(projectId);
            if (result != null)
            {
                return projectObj.Delete(result);
            }
            else
            {
                return 0;
            }
        }
    }
}
