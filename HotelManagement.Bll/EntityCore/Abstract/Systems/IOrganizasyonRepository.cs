using HotelManagement.Core.Utilities.Results.Abstract;
using HotelManagement.Dal.EfCore.Abstract;
using HotelManagement.Dto.Systems;
using HotelManagement_Entity.Models.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.Bll.EntityCore.Abstract.Systems
{
    public interface IOrganizasyonRepository : IEntityBaseRepository<Organizasyon>
    {
        IDataResult<IQueryable<Organizasyon>> GetAllOrganizasyon();

        IDataResult<Organizasyon> GetById(int id);

        IResult AddOrganizasyon(Organizasyon organizasyon);

        IResult UpdateOrganizasyon(Organizasyon organizasyon);

        IResult DeleteOrganizasyon(int id);

        IDataResult<IQueryable<OrganizasyonDto>> GetAllOrganizasyoneDetailTable();


    }
}
