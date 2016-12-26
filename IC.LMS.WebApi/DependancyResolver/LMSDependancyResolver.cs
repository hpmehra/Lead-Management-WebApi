using IC.LMS.Business;
using IC.LMS.Business.Contract;
using Microsoft.Practices.Unity;

namespace IC.LMS.WebApi.DependancyResolver
{
    public class LMSDependancyResolver
    {
        public static void RegisterType(IUnityContainer container)
        {
            container.RegisterType<ICompanyInfo, CompanyInfoImpl>(new HierarchicalLifetimeManager());
            container.RegisterType<IProjectRequirement, ProjectRequirementImpl>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserDetail, UserDetailImpl>(new HierarchicalLifetimeManager());
            container.RegisterType<IProject, ProjectImpl>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserLogin, UserLoginImpl>(new HierarchicalLifetimeManager());
        }
    }
}