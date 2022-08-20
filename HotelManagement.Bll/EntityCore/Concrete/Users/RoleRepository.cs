using HotelManagement.Bll.EntityCore.Abstract.Users;
using HotelManagement.Dal.EfCore;
using HotelManagement.Dal.EfCore.Concrete;
using HotelManagement.Entity.Models.Users;

namespace HotelManagement.Bll.EntityCore.Concrete.Users
{
    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(HotelManagementContext context) : base(context)
        {
        }
    }
}