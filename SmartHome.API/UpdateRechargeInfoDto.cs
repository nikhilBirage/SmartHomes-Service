
namespace SmartHome.API
{
    public class UpdateRechargeInfoDto
    {
        public string MeterNumber { get; set; }
        public decimal ReadingVolt { get; set; }
        public decimal ReadingWatt { get; set; }
        public decimal Amount { get; set; }
    }
}
