using System;
using System.Collections.Generic;

namespace SmartHome.API.Models
{
    public partial class MeterReading
    {
        public int Id { get; set; }
        public string MeterNumber { get; set; }
        public decimal? ReadingWatt { get; set; }
        public decimal? ReadingVolt { get; set; }
        public DateTime? Date { get; set; }
        public bool IsActive { get; set; }

        public MeterUser MeterNumberNavigation { get; set; }
    }
}
