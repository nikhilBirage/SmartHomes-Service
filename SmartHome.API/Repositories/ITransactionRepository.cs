using SmartHome.API.Dtos;
using SmartHome.API.Models;
using System.Collections.Generic;

namespace SmartHome.API.Repositories
{
    public interface ITransactionRepository
    {
        string UpdateTransactionInfo(UpdateTransactionInfo transactionInfo);
        IEnumerable<TransactionDetail> GetTransactionDetails();
        IEnumerable<TransactionDetail> GetTransactionDetailsByMeterNumber(string meterNumber);
    }
}
