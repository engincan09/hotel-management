using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Dal.EfCore.Abstract;
using HotelManagement.Entity.Models.Systems;

namespace HotelManagement.Bll.EntityCore.Abstract.Systems
{
    public interface ILookupTypeRepository : IEntityBaseRepository<LookupType>
    {
    }
}
