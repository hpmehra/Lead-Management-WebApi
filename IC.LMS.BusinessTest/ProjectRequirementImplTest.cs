using Microsoft.VisualStudio.TestTools.UnitTesting;
using IC.LMS.Business;
using IC.LMS.Domain;
using IC.LMS.Domain.Dto;

namespace IC.LMS.BusinessTest
{

    [TestClass]
    public class ProjectRequirementImplTest
    {
        ProjectRequirementImpl projectReqImplObj;
        [TestInitialize]
        public void UnitTest1Initialize()
        {
            projectReqImplObj = new ProjectRequirementImpl();
        }

        [TestMethod]
        public void GetProjectRequirementAll()
        {
            var result = projectReqImplObj.GetProjectRequirementAll();
            Assert.IsTrue(result != null, "Get record");
        }

        [TestMethod]
        public void AddProjectRequirement()
        {
            ProjectRequirementDto projectRequirementDto = new ProjectRequirementDto
            {
                ProjectName = "New LMS ",
                CompanyId = 5,
                Description = "Lead management system end to end full description",             
                RequirementDate = System.DateTime.Now,
                Technology="Mvc, Entity",
            };
            var result = projectReqImplObj.AddProjectRequirement(projectRequirementDto);
            Assert.IsTrue(result > 0, "Add successfully");
        }
        [TestMethod]
        public void GetProjectRequirementById()
        {
            ProjectRequirement projectRequirement = new ProjectRequirement
            {
                ProjectReqId = 29
            };
            var result = projectReqImplObj.GetProjectRequirementById(projectRequirement.ProjectReqId);
            Assert.IsTrue(result != null, "get record");
        }

        [TestMethod]
        public void GetProjectReqByCompanyId()
        {
            ProjectRequirementDto projectReqDto = new ProjectRequirementDto
            {
               CompanyId = 5
            };
            var result = projectReqImplObj.GetProjectReqByCompanyId(projectReqDto.CompanyId);
            Assert.IsTrue(result !=null, "get record");
        }

        [TestMethod]
        public void UpdateProjectRequirement()
        {
            ProjectRequirement projectRequirement = new ProjectRequirement
            {
                ProjectReqId=1,
                CompanyId = 4,
                Description = "Lead management system end to end full description",
                RequirementDate = System.DateTime.Now

            };
            var result = projectReqImplObj.UpdateProjectRequirement(projectRequirement);
            Assert.IsTrue(result > 0, "updated");
        }


        [TestMethod]
        public void DeleteProjectRequirement()
        {
            ProjectRequirement projectRequirement = new ProjectRequirement
            {
                ProjectReqId = 1,
            };
            var result = projectReqImplObj.DeleteProjectRequirement(projectRequirement.ProjectReqId);
            Assert.IsTrue(result > 0, "get record");
        }
    }
}
