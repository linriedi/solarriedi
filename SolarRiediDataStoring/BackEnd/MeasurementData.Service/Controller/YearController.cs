using AutoMapper;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Linus.SolarRiedi.BackEnd.Service.Repositories;

namespace Linus.SolarRiedi.BackEnd.Service.Controller
{
    [Route("api/[controller]")]
    public class YearController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IMeasurementRepository measurementRepository;

        public YearController(IMeasurementRepository measurementRepository)
        {
            this.measurementRepository = measurementRepository;
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            try
            {
                var list = this.measurementRepository.GetYearMeasurements();
                return Ok(list.Select(x => Mapper.Map<List<string>>(x)));
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
