using HotelManagement.Bll.EntityCore.Abstract.Users;
using HotelManagement.Dal.EfCore;
using HotelManagement.Dal.EfCore.Concrete;
using HotelManagement.Entity.Models.Users;

namespace HotelManagement.Bll.EntityCore.Concrete.Users
{
    public class UserRoleRepository : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(HotelManagementContext context) : base(context)
        {
        }
    }
}