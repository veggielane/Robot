using System.IO.Ports;

namespace Robot.Core.Devices
{
    public class Serial : SerialPort
    {
    
        public Serial(string portName)
            : base(portName)
        {

        }

        public Serial(string portName, int baudRate)
            : base(portName, baudRate)
        {

        }

        public Serial(string portName, int baudRate, Parity parity)
            : base(portName, baudRate, parity)
        {

        }

        public Serial(string portName, int baudRate, Parity parity, int dataBits)
            : base(portName, baudRate, parity, dataBits)
        {

        }

        public Serial(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
            : base(portName, baudRate, parity, dataBits, stopBits)
        {

        }

        public virtual bool Connect()
        {
            Open();
            //if (PortName == "COM4" && IsOpen == true) RemapCOM4();
            return IsOpen;
        }

        private void InitializeComponent()
        {

        }


    }
}
