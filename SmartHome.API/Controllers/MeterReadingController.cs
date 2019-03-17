using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartHome.API.Models;
using SmartHome.API.Repositories;

namespace SmartHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {
        public IMeterReadingRepository _meterReadingRepository;
        public MeterReadingController(IMeterReadingRepository meterReadingRepository)
        {
            _meterReadingRepository = meterReadingRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<MeterReading> GetMeterReading()
        {
            return _meterReadingRepository.GetMeterReading();
        }

        [HttpGet]
        [Route("get/{id}")]
        public MeterReading GetMeterReadingById([FromRoute] int id)
        {
            return _meterReadingRepository.GetMeterReadingById(id);
        }

        [HttpGet]
        [Route("getByMeterNumber/{meterNumber}")]
        public MeterReading GetMeterReadingById([FromRoute] string meterNumber)
        {
            return _meterReadingRepository.GetMeterReadingByMeterNumber(meterNumber);
        }

        [HttpPost]
        [Route("save")]
        public int SaveMeterReading([FromBody] MeterReading meterReading)
        {
            return _meterReadingRepository.SaveMeterReading(meterReading);
        }

        [HttpPut]
        [Route("update")]
        public int UpdateMeterReading([FromBody] MeterReading meterReading)
        {
            return _meterReadingRepository.UpdateMeterReading(meterReading);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public int DeleteMeterReading([FromRoute] int id)
        {
            return _meterReadingRepository.DeleteMeterReading(id);
        }
    }
}