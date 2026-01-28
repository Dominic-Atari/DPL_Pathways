using System;

namespace Stage_1.Week_4.InterfaceExercise
{
    public class Computer : Device, IDevice
    {
        //public string UserName { get; set; }
        public string Time { get; }

        // If user Joined
        public Computer(string _userName, string _deviceType, string _location, string _time) : base(_userName, _deviceType, _location)
        {
            Time = _time;
        }
        public Computer()
        {
            UserName = string.Empty;
            Location = string.Empty;
            DeviceType = string.Empty;
            Time = string.Empty;
        }
        public bool Joined()
        {
            return false;
        }

        public override Guid DevaultMessage()
        {
            return Guid.NewGuid();
        }
        // Override string method from the base class
        public override string ToString()
        {
            return $"\nUser Name: {UserName}\nDevice Type: {DeviceType}\nLocation: {Location}\nJoined at: {DateTime.Now.ToString()}\n";
        }
    }
}