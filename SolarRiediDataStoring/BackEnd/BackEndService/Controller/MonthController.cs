using AutoMapper;
using Linus.SolarRiedi.BackEnd.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Linus.SolarRiedi.BackEnd.Service.Controller
{
    [Route("api/[controller]")]
    public class MonthController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IMonthService monthService;

        public MonthController(IMonthService monthService)
        {
            this.monthService = monthService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.monthService.GetAll().Select(month => Mapper.Map<MonthDto>(month)));
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }
            return Ok();
        }
    }
}
