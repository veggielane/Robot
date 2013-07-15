using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;

namespace Robot.Core.Devices
{
    public class SSC32:IDisposable
    {
        private readonly SerialPort _port;

        public IDictionary<int, Servo> Servos { get; private set; }

        //public SSC32GroupMove GroupMove { get { return new SSC32GroupMove(this); } }
        public string Version { get { return WriteRead("VER"); } }

        public SSC32(string portName)
        {
            _port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
            Servos = new Dictionary<int, Servo>(32);
        }

        public void Connect()
        {
            _port.Open();
            Execute();
        }

        public string ReadData()
        {
            var sb = new StringBuilder();
            Thread.Sleep(100);
            while (_port.BytesToRead > 0)
            {
                sb.Append(_port.ReadExisting());
                Thread.Sleep(100);
            }
            return sb.ToString();
        }

        public string WriteRead(string data)
        {
            Execute(data);
            return ReadData();
        }

        public void REPL()
        {
            Console.WriteLine("Staring REPL (type 'exit' to stop)");
            Console.WriteLine("Version: {0}",Version);
            while (true)
            {
                var line = Console.ReadLine();
                if(line != null && line.ToUpper() == "EXIT") break;
                Console.WriteLine("pi >> SSC32: {0}", line);
                Console.WriteLine("pi << SSC32: {0}", WriteRead(line));
            }
        }

        public void Execute()
        {
            _port.Write(Convert.ToChar(13).ToString(CultureInfo.InvariantCulture));
        }
        public void Execute(string command)
        {
            _port.Write(command + Convert.ToChar(13).ToString(CultureInfo.InvariantCulture));
        }

        public void Stop()
        {
            Execute("STOP");
        }

        public void Update(int? speed = null, int? time = null)
        {
            var bw = new BinaryWriter(_port.BaseStream);
            foreach (var kvp in Servos)
            {
                bw.Write(new[] { (byte)(0x80 + kvp.Key), (byte)((kvp.Value.Pulse >> 8) & 0xff), (byte)(kvp.Value.Pulse & 0xff) });
            }
            if (speed != null)
            {
                bw.Write(new[] { (byte)0xA0, (byte)((speed >> 8) & 0xff), (byte)(speed & 0xff) });
            }
            if (time != null)
            {
                bw.Write(new[] { (byte)0xA1, (byte)((time >> 8) & 0xff), (byte)(time & 0xff) });
            }
            Execute();
        }

        public void Dispose()
        {
            
        }
    }
}
