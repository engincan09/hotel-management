using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Bll.EntityCore.Abstract.Systems;
using HotelManagement.Dal.EfCore;
using HotelManagement.Dal.EfCore.Concrete;
using HotelManagement.Entity.Models.Systems;

namespace HotelManagement.Bll.EntityCore.Concrete.Systems
{
    public class LookupRepository : EntityBaseRepository<Lookup>, ILookupRepository
    {
        public LookupRepository(HotelManagementContext context) : base(context)
        {
        }
    }
}
