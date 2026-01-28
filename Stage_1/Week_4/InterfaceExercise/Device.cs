using System;

namespace Stage_1.Week_4.InterfaceExercise
{
    public abstract class Device
    {
        public string DeviceType { get; set; }
        public string Location { get; set; }
        public string UserName { get; set; }

        public Device(string _userName, string _deviceType, string _location)
        {
            DeviceType = _deviceType;
            Location = _location;
            UserName = _userName;
        }
        public Device()
        {
            UserName = string.Empty;
            Location = string.Empty;
            DeviceType = string.Empty;
        }
        // Devault Zoom Id
        public abstract Guid DevaultMessage();
    }
}