using System;
using System.Collections.Generic;

namespace SmartHome.API.Models
{
    public partial class Recharge
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
