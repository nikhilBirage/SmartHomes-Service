using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartHome.API.Dtos;
using SmartHome.API.Models;
using SmartHome.API.Repositories;

namespace SmartHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransactionRepository _transactionRepository;
        IRechargeRepository _rechargeRepository;
        IMeterReadingRepository _meterReadingRepository;
        public TransactionController(ITransactionRepository transactionRepository, 
                IRechargeRepository rechargeRepository,
                IMeterReadingRepository meterReadingRepository)
        {
           _transactionRepository = transactionRepository;
           _rechargeRepository = rechargeRepository;
           _meterReadingRepository = meterReadingRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<TransactionDetail> GetTransactionDetails()
        {
            return _transactionRepository.GetTransactionDetails();
        }

        [HttpGet]
        [Route("getAll/{meterNumber}")]
        public IEnumerable<TransactionDetail> GetTransactionDetailsByMeterNumber(string meterNumber)
        {
            return _transactionRepository.GetTransactionDetailsByMeterNumber(meterNumber);
        }

        [HttpPut]
        [Route("updateTransactionInfo")]
        public string UpdateTransactionInfo([FromBody] UpdateTransactionInfo transactionInfo)
        {
            var meterReadingInfo = _meterReadingRepository.GetMeterReadingByMeterNumber(transactionInfo.MeterNumber);
            if (meterReadingInfo == null)
                return "0";

            string result = _transactionRepository.UpdateTransactionInfo(transactionInfo);
            if (result == "1")
            {
                Recharge rechargeInfo = _rechargeRepository.GetRecharges().Where(x => x.UserId == transactionInfo.UserId).FirstOrDefault();
                if (rechargeInfo == null)
                {
                    Recharge newRecharge = new Recharge
                    {
                        Amount = transactionInfo.Amount,
                        IsActive = true,
                        UserId = transactionInfo.UserId,
                        Date = DateTime.Now,
                        StartDate = DateTime.Now
                    };

                    string rechargeResult = _rechargeRepository.SaveRechargeInfo(newRecharge) > 0 ? "1" : "0";

                    return rechargeResult;
                }
                else
                {
                    if (rechargeInfo.Amount == 0)
                        rechargeInfo.StartDate = DateTime.Now;

                    rechargeInfo.Amount = rechargeInfo.Amount + transactionInfo.Amount;

                    string rechargeResult = _rechargeRepository.UpdateRechargeInfo(rechargeInfo) > 0 ? "1" : "0";
                    return rechargeResult;
                }
            }
            return "0";
        }

    }
}