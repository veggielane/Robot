using System;
using System.Collections;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using System.IO.Ports;

namespace Robot.Micro.Core.Devices
{
    public class SSC32 : ExtendedSerialPort
    {
        private readonly Char _cr = Convert.ToChar(13);
        public enum MoveTypes { Normal, Speed, Time };


        public Hashtable Servos = new Hashtable(32);

        public String Version 
        {
            get
            {
                return IsOpen ? WriteRead("VER") : "";
            }
        }


        public SSC32(String port, int baudRate):base(port,baudRate)
        {

        }

        public void AddServo(Int16 pin, Servo servo)
        {
            if (Servos.Contains(pin))
            {
                Servos[pin] = servo;
            }else
            {
                Servos.Add(pin, servo);
            }
        }

        public void Move()
        {
            Move(MoveTypes.Normal, 0);
        }
        public void Move(MoveTypes type, Int32 param)
        {
            foreach (DictionaryEntry de in Servos)
            {
                Write("#" + de.Key + "P" + ((Servo)de.Value).Pulse);
            }
            Execute();
        }

        private void Target(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Chars)
            {
                Debug.Write(Read().Trim());
            }
        }

        public override bool Connect()
        {
 	         base.Connect();
             Reset();
             if (Version != null && Version.IndexOf("SSC32-V2.03XE") != -1)
             {
                 DataReceived += Target;
                 return true;
             }
             return false;
        }

        public void Reset()
        {
            Execute();
        }

        public void Execute()
        {
            Write(_cr);
        }

        public String WriteRead(String data)
        {
            Write(data + _cr);
            Thread.Sleep(50);
            return Read();
        }
    }
}
