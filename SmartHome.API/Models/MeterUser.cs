using System;
using System.Collections.Generic;

namespace SmartHome.API.Models
{
    public partial class MeterUser
    {
        public MeterUser()
        {
            MeterReading = new HashSet<MeterReading>();
        }

        public string MeterNumber { get; set; }
        public int UserId { get; set; }
        public bool IsValid { get; set; }

        public ICollection<MeterReading> MeterReading { get; set; }
    }
}
