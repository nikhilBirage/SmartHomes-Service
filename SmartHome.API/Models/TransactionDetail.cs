using System;

namespace SmartHome.API.Models
{
    public partial class TransactionDetail
    {
        public int Id { get; set; }
        public string MeterNumber { get; set; }
        public string TransactionId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}
