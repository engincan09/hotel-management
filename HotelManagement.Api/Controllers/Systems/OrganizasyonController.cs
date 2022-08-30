using HotelManagement.Bll.EntityCore.Abstract.Systems;
using HotelManagement_Entity.Models.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Api.Controllers.Systems
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizasyonController : ControllerBase
    {
        private readonly IOrganizasyonRepository _service;

        /// <summary>
        /// Yapıcı
        /// </summary>
        /// <param name="employeeRepository"></param>
        public OrganizasyonController(IOrganizasyonRepository employeeRepository)
        {
            _service = employeeRepository;
        }

        /// <summary>
        /// Tüm organizasyon verilerini getirir.
        /// </summary>
        [HttpGet, Route("GetAllOrganizasyon")]
        [Produces("application/json")]
        public IActionResult GetAllOrganizasyon()
        {
            var result = _service.GetAllOrganizasyon();
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Tüm organizasyon verilerini getirir.
        /// </summary>
        [HttpGet, Route("GetAllOrganizasyoneDetailTable")]
        [Produces("application/json")]
        public IActionResult GetAllOrganizasyoneDetailTable()
        {
            var result = _service.GetAllOrganizasyoneDetailTable();
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Tekil bilgisine göre organizasyon döndürür
        /// </summary>
        [HttpGet, Route("GetById/{key:int}")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult GetById([FromRoute] int key)
        {
            var result = _service.GetById(key);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Yeni organizasyon kaydı
        /// </summary>
        [HttpPost, Route("PostOrganizasyon")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult PostOrganizasyon([FromBody] Organizasyon val)
        {
            var result = _service.AddOrganizasyon(val);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// organizasyon kaydını değişen alanlara göre günceller.
        /// </summary>
        [HttpPost, Route("UpdateOrganizasyon")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult UpdateOrganizasyon([FromBody] Organizasyon val)
        {
            var result = _service.UpdateOrganizasyon(val);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// organizasyon kaydını siler
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet, Route("DeleteOrganizasyon/{key:int}")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult DeleteOrganizasyon([FromRoute] int key)
        {
            var result = _service.DeleteOrganizasyon(key);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }
    }
}
