using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartHome.API.Dtos;
using SmartHome.API.Models;
using SmartHome.API.Repositories;

namespace SmartHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RechargeController : ControllerBase
    {
        private IRechargeRepository _rechargeRepository;
        public RechargeController(IRechargeRepository rechargeRepository)
        {
            _rechargeRepository = rechargeRepository;
        }

        /// <summary>
        /// get recharge amount based on meter number
        /// </summary>
        /// <param name="meterNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getRechargeAmount/{meterNumber}")]
        public decimal? GetRechargeAmountBasedOnMeterNumber(string meterNumber)
        {
            return _rechargeRepository.GetRechargeBasedOnMeterNumber(meterNumber);
        }

        /// <summary>
        /// get recharge amount based on meter number
        /// </summary>
        /// <param name="meterNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getBalance/{meterNumber}")]
        public string getBalance(string meterNumber)
        {
            return  "*" + _rechargeRepository.GetRechargeBasedOnMeterNumber(meterNumber) + "#";
        }

        /// <summary>
        /// Update recharge amount and meter reading
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST / recharge amount info
        ///     {
        ///        "MeterNumber": "TEST123",
        ///        "ReadingVolt": 2.33,
        ///        "ReadingWatt": 1.25,
        ///        "Amount": 10.00
        ///     }
        ///
        /// </remarks>
        /// <param name="updateRechargeInfoDto"></param>
        /// <returns>*0# when update failed</returns>
        /// <returns>*1# when update successfull</returns>
        [HttpPost]
        [Route("updateInfo")]
        public string UpdateInformation(UpdateRechargeInfoDto updateRechargeInfoDto)
        {
            return _rechargeRepository.UpdateInformation(updateRechargeInfoDto);
        }

        
        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Recharge> GetRecharges()
        {
            return _rechargeRepository.GetRecharges();
        }

        [HttpGet]
        [Route("get/{id}")]
        public Recharge GetRechargeDetails([FromRoute] int id)
        {
            return _rechargeRepository.GetRechargeDetails(id);
        }

        [HttpGet]
        [Route("getByUserId/{userId}")]
        public Recharge GetRechargeDetailsByUserId([FromRoute] int userId)
        {
            return _rechargeRepository.GetRechargeDetails(userId);
        }

        [HttpPost]
        [Route("save")]
        public int SaveRechargeInfo([FromBody] Recharge recharge)
        {
            return _rechargeRepository.SaveRechargeInfo(recharge);
        }

        [HttpPut]
        [Route("update")]
        public int UpdateRechargeInfo([FromBody] Recharge recharge)
        {
            return _rechargeRepository.UpdateRechargeInfo(recharge);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public int DeleteRechargeInfo([FromRoute] int id)
        {
            return _rechargeRepository.DeleteRechargeInfo(id);
        }
    }
}