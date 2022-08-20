using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Dal.EfCore.Abstract;
using HotelManagement.Dto.Shared;
using HotelManagement.Entity.Models.Systems;

namespace HotelManagement.Bll.EntityCore.Abstract.Systems
{
    public interface IPagePermissionRepository : IEntityBaseRepository<PagePermission>
    {
        Task<Response> CustomPost(CustomPostPagePermission val);

        string GetFisrtFireLink(int[] allUserRoles);

        List<PagePermission> GetPagePermissionListCache(bool isRefresh);

        List<MenuPage> GetMenuPageListCache(bool isRefresh);
    }
}
