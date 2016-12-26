using IC.LMS.Business;
using IC.LMS.Domain.Dto;
using IC.LMS.Domain.EnumContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IC.LMS.BusinessTest
{
    
    [TestClass]
    public class ProjectImplTest
    {
        ProjectImpl projectImplObj;
        [TestInitialize]
        public void UnitTest1Initialize()
        {
            projectImplObj = new ProjectImpl();
        }

        [TestMethod]
        public void GetProjectAll()
        {
            var result = projectImplObj.GetProjectAll();
            Assert.IsTrue(result != null, "Get record");
        }

        [TestMethod]
        public void AddProjectRequirement()
        {
            ProjectRequirementDto projectReqDto = new ProjectRequirementDto
            {
                ProjectReqId = 31,
                CompanyId = 5,
                StartDate = System.DateTime.Now,
                CompletionDate = System.DateTime.Now,
                DeadLine = System.DateTime.Now,
                Estimation = "1 month",
                ResourceWorking = "10",
                ProjectStatus = ProjectStatus.Complete
               
            };
            var result = projectImplObj.AddProject(projectReqDto);
            Assert.IsTrue(result > 0, "Add successfully");
        }

        [TestMethod]
        public void GetProjectById()
        {
            ProjectRequirementDto projectReqDto = new ProjectRequirementDto
            {
                ProjectId = 1
            };
            var result = projectImplObj.GetProjectById(projectReqDto.ProjectId);
            Assert.IsTrue(result != null, "get record");
        }
    }
}
