using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using HotelManagement.Bll.EntityCore.Abstract.Employees;
using HotelManagement.Bll.EntityCore.Abstract.Systems;
using HotelManagement.Bll.EntityCore.Abstract.Users;
using HotelManagement.Bll.EntityCore.Concrete.Employees;
using HotelManagement.Bll.EntityCore.Concrete.Systems;
using HotelManagement.Bll.EntityCore.Concrete.Users;
using HotelManagement.Core.Helpers.Interceptors;
using HotelManagement.Core.Middleware;

namespace HotelManagement.Bll.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            #region Systems
            builder.RegisterType<CustomHttpContextAccessor>().As<ICustomHttpContextAccessor>().SingleInstance();
            builder.RegisterType<LookupRepository>().As<ILookupRepository>().SingleInstance();
            builder.RegisterType<LookupTypeRepository>().As<ILookupTypeRepository>().SingleInstance();
            builder.RegisterType<PageRepository>().As<IPageRepository>().SingleInstance();
            builder.RegisterType<PagePermissionRepository>().As<IPagePermissionRepository>().SingleInstance();
            builder.RegisterType<OrganizasyonRepository>().As<IOrganizasyonRepository>().SingleInstance();
            #endregion

            #region User
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<UserRoleRepository>().As<IUserRoleRepository>().SingleInstance();
            #endregion
            #region Employee
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();
            #endregion

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
