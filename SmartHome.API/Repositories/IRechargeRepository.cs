using SmartHome.API.Dtos;
using SmartHome.API.Models;
using System.Collections.Generic;

namespace SmartHome.API.Repositories
{
    public interface IRechargeRepository : IRepository<Recharge>
    {
        IEnumerable<Recharge> GetRecharges();
        Recharge GetRechargeDetails(int rechargeId);
        int SaveRechargeInfo(Recharge recharge);
        int UpdateRechargeInfo(Recharge recharge);
        int DeleteRechargeInfo(int rechargeId);
        decimal? GetRechargeBasedOnMeterNumber(string meterNumber);
        string UpdateInformation(UpdateRechargeInfoDto updateRechargeInfoDto);
        Recharge GetRechargeDetailsByUserId(int userId);
    }
}
