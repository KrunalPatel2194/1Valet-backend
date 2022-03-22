using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Device
    {
        public int DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public int? DeviceTypeId { get; set; }
        public bool? DeviceStatus { get; set; }
        public string? DeviceImage { get; set; }
        public double? DeviceTemperature { get; set; }
        public bool IsActive { get; set; }

        public virtual DeviceType? DeviceType { get; set; }
        //public virtual DeviceUsage? DeviceUsage { get; set; }   
    }
}
