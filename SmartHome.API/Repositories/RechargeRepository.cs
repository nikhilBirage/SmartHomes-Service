using Microsoft.EntityFrameworkCore;
using SmartHome.API.Dtos;
using SmartHome.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHome.API.Repositories
{
    public class RechargeRepository : Repository<Recharge>, IRechargeRepository
    {
        protected readonly DbSet<MeterReading> Db_MeterReading;
        protected readonly DbSet<MeterUser> Db_MeterUser;
        protected readonly DbSet<TransactionDetail> Db_TransactionDetail;

        public RechargeRepository(SmartHomeContext context) : base(context)
        {
            Db_MeterReading = context.Set<MeterReading>();
            Db_MeterUser = context.Set<MeterUser>();
            Db_TransactionDetail = context.Set<TransactionDetail>();
        }

        public int DeleteRechargeInfo(int rechargeId)
        {
            Remove(rechargeId);
            return SaveChanges();
        }

        public Recharge GetRechargeDetails(int rechargeId)
        {
            return DbSet.Where(x => x.Id == rechargeId).FirstOrDefault();
        }

        public Recharge GetRechargeDetailsByUserId(int userId)
        {
            return DbSet.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public IEnumerable<Recharge> GetRecharges()
        {
            IEnumerable<Recharge> data = (from recharge in DbSet
                                          select new Recharge
                                          {
                                              Id = recharge.Id,
                                              Amount = recharge.Amount,
                                              StartDate = recharge.StartDate,
                                              Status = recharge.Status,
                                              IsActive = recharge.IsActive,
                                              Date = recharge.Date,
                                              UserId = recharge.UserId
                                          }).ToList();
            return data;
        }

        public int SaveRechargeInfo(Recharge recharge)
        {
            Add(recharge);
            return SaveChanges();
        }

        public int UpdateRechargeInfo(Recharge recharge)
        {
            Update(recharge);
            return SaveChanges();
        }

        public decimal? GetRechargeBasedOnMeterNumber(string meterNumber)
        {
            var meterUser = Db_MeterUser.Where(x => x.MeterNumber == meterNumber).FirstOrDefault();
            var rechargeInfo = DbSet.Where(x => x.UserId == meterUser.UserId).FirstOrDefault();
            if(meterUser != null)
            {
                if (rechargeInfo != null)
                    return rechargeInfo.Amount;
                else
                    return 0;
            }
           
            return -1;
        }

        public string UpdateInformation(UpdateRechargeInfoDto updateRechargeInfoDto)
        {
            try
            {

                var meterUser = Db_MeterUser.Where(x => x.MeterNumber == updateRechargeInfoDto.MeterNumber).FirstOrDefault();

                if (meterUser == null)
                    return "invalid meterNumber";

                var meterReadingInfo = Db_MeterReading.Where(x => x.MeterNumber == updateRechargeInfoDto.MeterNumber).FirstOrDefault();
                if (meterReadingInfo == null)
                {
                    MeterReading meterReading = new MeterReading();
                    meterReading.MeterNumber = updateRechargeInfoDto.MeterNumber;
                    meterReading.ReadingVolt = 0;
                    meterReading.ReadingWatt = 0;
                    meterReading.Date = DateTime.Now;
                    meterReading.IsActive = true;
                    Db_MeterReading.Add(meterReading);
                }

                var rechargeInfo = DbSet.Where(x => x.UserId == meterUser.UserId).FirstOrDefault();
                if (rechargeInfo == null)
                {
                    Recharge newRecharge = new Recharge();
                    newRecharge.Amount = updateRechargeInfoDto.Amount;
                    newRecharge.IsActive = true;
                    newRecharge.Status = "done";
                    newRecharge.UserId = meterUser.UserId;
                    newRecharge.Date = DateTime.Now;
                    newRecharge.StartDate = DateTime.Now;

                    Add(newRecharge);
                }
                else
                {
                    if (rechargeInfo.Amount == 0)
                        rechargeInfo.StartDate = DateTime.Now;

                    rechargeInfo.Amount = updateRechargeInfoDto.Amount;

                    Update(rechargeInfo);
                }

                var result = SaveChanges();
                if (result > 0)
                {
                    if(meterReadingInfo == null)
                    {
                        meterReadingInfo = Db_MeterReading.Where(x => x.MeterNumber == updateRechargeInfoDto.MeterNumber).FirstOrDefault();
                    }

                    meterReadingInfo.ReadingVolt = updateRechargeInfoDto.ReadingVolt;
                    meterReadingInfo.ReadingWatt = updateRechargeInfoDto.ReadingWatt;
                    meterReadingInfo.Date = DateTime.Now;
                    Db_MeterReading.Update(meterReadingInfo);
                    return SaveChanges() == 1 ? "*1#" : "*0#";
                }
            }catch(Exception ex)
            {
                return $"error {ex.Message}";
            }
            return "*0#";
        }

        

    }
}
