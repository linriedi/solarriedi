using AutoMapper;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Linus.SolarRiedi.BackEnd.Service.Repositories;
using Linus.SolarRiedi.BackEnd.Service.Models;

namespace Linus.SolarRiedi.BackEnd.Service.Controller
{
    [Route("api/[controller]")]
    public class MonthController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IMeasurementRepository measurementRepository;

        public MonthController(IMeasurementRepository measurementRepository)
        {
            this.measurementRepository = measurementRepository;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var date = this.Map(id);
                var list = this.measurementRepository.GetMonthMeasurements(date);
                return Ok(list.Select(x => Mapper.Map<List<string>>(x)));
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }
        }

        private ReportDate Map(string id)
        {
            var split = id.Split('.');
            int day = int.Parse(split[0]);
            int month = int.Parse(split[1]);
            int year = int.Parse(split[2]);

            return new ReportDate(year, month, day);
        }
    }
}
