using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Linus.SolarRiedi.BackEnd.Service.Repositories;
using Linus.SolarRiedi.BackEnd.Service.Models;
using Linus.SolarRiedi.BackEnd.Service.ViewModels;

namespace Linus.SolarRiedi.BackEnd.Service.Controller
{
    [Route("api/[controller]")]
    public class MeasurementController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IMeasurementRepository measurementRepository;

        public MeasurementController(IMeasurementRepository measurementRepository)
        {
            this.measurementRepository = measurementRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.measurementRepository.GetAll().Select(x => Mapper.Map<MeasurementViewModel>(x)));
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] MeasurementItem item)
        {
            try
            {
                var newItem = this.measurementRepository.Add(item);

                return Ok(Mapper.Map<MeasurementViewModel>(newItem));
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Single(int id)
        {
            try
            {
                var item = this.measurementRepository.GetSingle(id);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<MeasurementViewModel>(item));
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var item = this.measurementRepository.GetSingle(id);

                if (item == null)
                {
                    return NotFound();
                }

                this.measurementRepository.Delete(id);
                return NoContent();
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody]MeasurementItem foodItem)
        {
            try
            {
                var itemToCheck = this.measurementRepository.GetSingle(id);

                if (itemToCheck == null)
                {
                    return NotFound();
                }

                if (id != itemToCheck.Id)
                {
                    return BadRequest("Ids do not match");
                }

                var update = measurementRepository.Update(id, foodItem);

                return Ok(Mapper.Map<MeasurementViewModel>(update));
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
