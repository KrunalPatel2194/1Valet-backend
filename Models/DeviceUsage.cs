using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class DeviceUsage
    {
        public int? DeviceTypeId { get; set; }
        public DateTime? DeviceUsageFromDateTime { get; set; }
        public string? DeviceUsageToDateTime { get; set; }
    }
}
