using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;

namespace Robot.Core.Devices
{
    public class SSC32:SerialPort,IServoController
    {
        public IDictionary<int, Servo> Servos { get; private set; }

        public SSC32(string portName)
            : base(portName, 115200)
        {
            Servos = new Dictionary<int,Servo>();
        }

        public bool Connect()
        {
            if (!GetPortNames().ToList().Contains(PortName)) return false;
            Open();
            Execute();
            return IsOpen;
        }

        public void Execute()
        {
            if (!IsOpen) return;
            Write(Convert.ToChar(13).ToString(CultureInfo.InvariantCulture));
        }

        public void Update()
        {
            if (!IsOpen) return;
            foreach (var kvp in Servos)
            {
                Write("#" + kvp.Key + " P" + kvp.Value.Pulse);
            }
            Execute();
        }

        public void Update(ServoMove move, int param)
        {
            if (!IsOpen) return;
            foreach (var kvp in Servos)
            {
                Write("#" + kvp.Key + " P" + kvp.Value.Pulse);
            }
            switch (move)
            {
                case ServoMove.Speed:
                    Write(" S" + param);
                    break;
                case ServoMove.Time:
                    Write(" T" + param);
                    break;
            }
            Execute();
        }

        public void Free()
        {
            if (!IsOpen) return;
            foreach (var kvp in Servos)
            {
                Write("#" + kvp.Key + "P0");
            }
            Execute();
        }
    }
}
