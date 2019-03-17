
namespace SmartHome.API.Dtos
{
    public class UpdateTransactionInfo
    {
        public string MeterNumber { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}
