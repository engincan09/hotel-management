using HotelManagement.Bll.EntityCore.Abstract.Employees;
using HotelManagement_Entity.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Api.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _service;

        /// <summary>
        /// Yapıcı
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _service = employeeRepository;
        }

        /// <summary>
        /// Tüm çalışan verilerini getirir.
        /// </summary>
        [HttpGet, Route("GetAllEmployee")]
        [Produces("application/json")]
        public IActionResult GetAllEmployee()
        {
            var result = _service.GetAllEmployee();
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Tekil bilgisine göre çalışan döndürür
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
        /// Yeni Çalışan kaydı
        /// </summary>
        [HttpPost, Route("PostEmployee")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult PostEmployee([FromBody] Employee val)
        {
            var result = _service.AddEmployee(val);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Çalışan kaydını değişen alanlara göre günceller.
        /// </summary>
        [HttpPost, Route("UpdateEmployee")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult UpdateEmployee([FromBody] Employee val)
        {
            var result = _service.UpdateEmployee(val);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Çalışan kaydını siler
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet, Route("DeleteEmployee/{key:int}")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult DeleteEmployee([FromRoute] int key)
        {
            var result = _service.DeleteEmployee(key);
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// Tüm personelleri gride basmak amacıyla detay bilgileri ile birlikte döndürür.
        /// </summary>
        [HttpGet, Route("GetAllEmployeeDetailTable")]
        [Authorize]
        [Produces("application/json")]
        public IActionResult GetAllEmployeeDetailTable()
        {
            var result = _service.GetAllEmployeeDetailTable();
            if (result.Success)
                return Ok(result);
            else
                return Ok(result);
        }
    }
}
