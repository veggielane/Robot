using System;
using System.Collections;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Devices
{
    public class SSC32:Serial
    {
        public readonly Hashtable Servos = new Hashtable(32);
        private readonly Char _cr = Convert.ToChar(13);

        public enum MoveTypes { Normal, Speed, Time };

        public SSC32(string portName)
            : base(portName, 115200)
        {

        }

        public SSC32(string portName, int baudRate)
            : base(portName, baudRate)
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
            Write(_cr);
        }

        public void FreeServos()
        {
            foreach (DictionaryEntry de in Servos)
            {
                Write("#" + de.Key + "P0");
            }
            Execute();
        }

        public new void Dispose()
        {
            if (IsOpen)
            {
                FreeServos();
            }
            base.Dispose();
        }
    }
}
