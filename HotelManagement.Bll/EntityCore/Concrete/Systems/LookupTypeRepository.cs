using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Bll.EntityCore.Abstract.Systems;
using HotelManagement.Dal.EfCore;
using HotelManagement.Dal.EfCore.Concrete;
using HotelManagement.Entity.Models.Systems;

namespace HotelManagement.Bll.EntityCore.Concrete.Systems
{
    public class LookupTypeRepository : EntityBaseRepository<LookupType>, ILookupTypeRepository
    {
        public LookupTypeRepository(HotelManagementContext context) : base(context)
        {
        }
    }
}
