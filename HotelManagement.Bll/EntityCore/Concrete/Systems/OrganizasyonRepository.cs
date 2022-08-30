using HotelManagement.Aspects.Autofac.Caching;
using HotelManagement.Bll.EntityCore.Abstract.Systems;
using HotelManagement.Bll.Helpers;
using HotelManagement.Bll.ValidationRule.FluentValidation.Systems;
using HotelManagement.Core.Aspects.Autofac.Validation;
using HotelManagement.Core.Utilities.Results.Abstract;
using HotelManagement.Core.Utilities.Results.Concrete;
using HotelManagement.Dal.EfCore;
using HotelManagement.Dal.EfCore.Concrete;
using HotelManagement.Dto.Systems;
using HotelManagement.Entity.Shared;
using HotelManagement_Entity.Models.Systems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.Bll.EntityCore.Concrete.Systems
{
    public class OrganizasyonRepository : EntityBaseRepository<Organizasyon>, IOrganizasyonRepository
    {
        public OrganizasyonRepository(HotelManagementContext context) : base(context)
        {
        }

        /// <summary>
        /// Yeni organizasyon kaydı oluşturur.
        /// </summary>
        /// <param name="organizasyon"></param>
        /// <returns></returns>
        [ValidationAspect(typeof(OrganizasyonValidator))]
        [CacheRemoveAspect("IOrganizasyonRepository.Get")]
        public IResult AddOrganizasyon(Organizasyon organizasyon)
        {
            if (FindBy(x => x.DataStatus == DataStatus.Activated && x.Name.ToLower() == organizasyon.Name.ToLower()).Any())
                return new ErrorResult("Bu isime ait bir kayıt zaten mevcut!");

            try
            {
                Add(organizasyon);
                Commit();
                return new SuccessResult(SystemConstants.AddedMessage);
            }
            catch (Exception e)
            {
                return new ErrorResult(SystemConstants.AddedErrorMessage);
            }
        }

        /// <summary>
        /// organizasyon kaydını siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IOrganizasyonRepository.Get")]
        public IResult DeleteOrganizasyon(int id)
        {
            var result = FindBy(a => a.Id == id).FirstOrDefault();
            if (result == null)
                return new ErrorResult(SystemConstants.NoData);

            else
            {
                try
                {
                    Delete(result);
                    Commit();
                    return new SuccessResult(SystemConstants.DeletedMessage);
                }
                catch (Exception)
                {
                    return new ErrorResult(SystemConstants.DeletedErrorMessage);
                }
            }
        }

        /// <summary>
        /// Aktif olan tüm organizasyon getirir.
        /// </summary>
        /// <returns></returns>
        [CacheAspect(duration: 10)]
        public IDataResult<IQueryable<Organizasyon>> GetAllOrganizasyon()
        {
            var result = FindBy(m => m.DataStatus == DataStatus.Activated);
            return new SuccessDataResult<IQueryable<Organizasyon>>(result);
        }

        public IDataResult<IQueryable<OrganizasyonDto>> GetAllOrganizasyoneDetailTable()
        {
            var orgList = FindBy(m => m.DataStatus == DataStatus.Activated)
                          .Select(s => new OrganizasyonDto
                          {
                              Code = s.Code,
                              Name = s.Name,
                              Id = s.Id,
                              IsBirimMudur = s.IsBirimMudur,
                              NumberOfStaff = s.NumberOfStaff,
                              ParentName = s.Parent.Name
                          }).AsNoTracking();
            return new SuccessDataResult<IQueryable<OrganizasyonDto>>(orgList);

        }

        /// <summary>
        /// Tekil biglisine göre organizasyon getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [CacheAspect(duration: 10)]
        public IDataResult<Organizasyon> GetById(int id)
        {
            var result = FindBy(m => m.DataStatus == DataStatus.Activated &&
                                    m.Id == id)
                        .FirstOrDefault();

            if (result != null)
                return new SuccessDataResult<Organizasyon>(result);
            else
                return new ErrorDataResult<Organizasyon>(null, SystemConstants.NoData);
        }


        /// <summary>
        /// organizasyon güncellemesi yapar
        /// </summary>
        /// <param name="organizasyon"></param>
        /// <returns></returns>
        [ValidationAspect(typeof(OrganizasyonValidator))]
        [CacheRemoveAspect("IOrganizasyonRepository.Get")]
        public IResult UpdateOrganizasyon(Organizasyon organizasyon)
        {
            var hasData = FindBy(m => m.DataStatus == DataStatus.Activated &&
                                      m.Id == organizasyon.Id)
                          .FirstOrDefault();
            if (hasData == null)
                return new ErrorDataResult<Organizasyon>(null, SystemConstants.NoData);

            try
            {
                hasData.Name = organizasyon.Name;
                hasData.ParentId = organizasyon.ParentId;
                hasData.IsBirimMudur = organizasyon.IsBirimMudur;
                hasData.NumberOfStaff = organizasyon.NumberOfStaff;
                hasData.Code = organizasyon.Code;

                Update(hasData);
                Commit();

                return new SuccessResult(SystemConstants.UpdatedMessage);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Organizasyon>(null, SystemConstants.UpdatedErrorMessage);
            }
        }
    }
}
