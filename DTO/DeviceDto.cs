namespace Backend.DTO
{
    public class DeviceDto
    {
        public int DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public bool? DeviceStatus { get; set; }
        public string? DeviceImage { get; set; }
        public double? DeviceTemperature { get; set; }
        public bool IsActive { get; set; }

    }
}
