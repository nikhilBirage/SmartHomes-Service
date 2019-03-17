using SmartHome.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.API.Dtos
{
    public class UserMeterDetail : User
    {
        public string MeterNumber { get; set; }
    }
}
