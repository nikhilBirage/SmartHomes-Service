using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartHome.API.Dtos;
using SmartHome.API.Models;

namespace SmartHome.API.Repositories
{
    public class TransactionRepository : Repository<TransactionDetail>, ITransactionRepository
    {
        protected readonly DbSet<MeterReading> Db_MeterReading;
        public TransactionRepository(SmartHomeContext context) : base(context)
        {
            Db_MeterReading = context.Set<MeterReading>();
        }

        public IEnumerable<TransactionDetail> GetTransactionDetails()
        {
            IEnumerable<TransactionDetail> data =
                                            (from details in DbSet
                                                   select new TransactionDetail
                                                   {
                                                       Id = details.Id,
                                                       Amount = details.Amount,
                                                       MeterNumber = details.MeterNumber,
                                                       Status = details.Status,
                                                       TransactionId = details.TransactionId,
                                                       Date = details.Date
                                                   }).ToList();
            return data;
        }

        public IEnumerable<TransactionDetail> GetTransactionDetailsByMeterNumber(string meterNumber)
        {
            IEnumerable<TransactionDetail> data =
                                            (from details in DbSet
                                             where details.MeterNumber == meterNumber
                                             select new TransactionDetail
                                             {
                                                 Id = details.Id,
                                                 Amount = details.Amount,
                                                 MeterNumber = details.MeterNumber,
                                                 Status = details.Status,
                                                 TransactionId = details.TransactionId,
                                                 Date = details.Date
                                             }).ToList();
            return data;
        }

        public string UpdateTransactionInfo(UpdateTransactionInfo transactionInfo)
        {
            var meterReadingInfo = Db_MeterReading.Where(x => x.MeterNumber == transactionInfo.MeterNumber).FirstOrDefault();
           

            TransactionDetail transactionDetail = new TransactionDetail
            {
                Amount = transactionInfo.Amount,
                MeterNumber = transactionInfo.MeterNumber,
                TransactionId = transactionInfo.TransactionId,
                Date = DateTime.Now,
                Status = transactionInfo.Status
            };

            Add(transactionDetail);
            return SaveChanges().ToString();
        }
    }
}
