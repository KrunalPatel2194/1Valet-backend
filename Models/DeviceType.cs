using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            Devices = new HashSet<Device>();
        }

        public int DeviceTypeId { get; set; }
        public string? DeviceType1 { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
