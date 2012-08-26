using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Robot.Core.Devices
{
    public class SSC32:SerialPort
    {
        public readonly Hashtable Servos = new Hashtable(32);

        public enum MoveTypes { Normal, Speed, Time };

        public SSC32(string portName)
            : base(portName, 115200)
        {

        }

        public new void Open()
        {
            base.Open();
            Execute();
        }

        public void AddServo(Int16 pin, Servo servo)
        {
            if (Servos.Contains(pin))
            {
                Servos[pin] = servo;
            }
            else
            {
                Servos.Add(pin, servo);
            }
        }

        public void Move(MoveTypes type = MoveTypes.Normal, Int32 param = 0)
        {
            foreach (DictionaryEntry de in Servos)
            {
                Write("#" + de.Key + " P" + ((Servo)de.Value).Pulse);
            }
            switch (type)
            {
                case MoveTypes.Speed:
                    Write(" S" + param);
                    break;
                case MoveTypes.Time:
                    Write(" T" + param);
                    break;
                case MoveTypes.Normal:
                    break;
            }
            Execute();
        }

        public void Execute()
        {
            Write(Convert.ToChar(13).ToString());
        }


        public void FreeServos()
        {
            foreach (DictionaryEntry de in Servos)
            {
                Write("#" + de.Key + "P0");
            }
            Execute();
        }
    }
}
