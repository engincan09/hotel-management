using HotelManagement.Dal.EfCore.Abstract;
using HotelManagement.Entity.Models.Users;

namespace HotelManagement.Bll.EntityCore.Abstract.Users
{
    public interface IRoleRepository : IEntityBaseRepository<Role>
    {
    }
}