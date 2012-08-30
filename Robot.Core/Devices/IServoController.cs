using System.Collections.Generic;

namespace Robot.Core.Devices
{
    public enum ServoMove { Normal, Speed, Time };
    public interface IServoController
    {
        IDictionary<int,Servo> Servos { get; }
        bool Connect();
        void Update();
        void Update(ServoMove move, int param);
        void Free();
    }
}