using System;
using System.IO.Ports;
using System.Text;
using GHIElectronics.NETMF.Hardware.LowLevel;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Devices
{
    public class ExtendedSerialPort : SerialPort
    {
        public ExtendedSerialPort(string portName)
            : base(portName)
        {
            
        }

        public ExtendedSerialPort(string portName, int baudRate)
            : base(portName, baudRate)
        {

        }

        public ExtendedSerialPort(string portName, int baudRate, Parity parity)
            : base(portName, baudRate, parity)
        {

        }

        public ExtendedSerialPort(string portName, int baudRate, Parity parity, int dataBits)
            : base(portName, baudRate, parity, dataBits)
        {

        }

        public ExtendedSerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
            : base(portName, baudRate, parity, dataBits, stopBits)
        {

        }
        public virtual bool Connect()
        {
            Open();
            //if (PortName == "COM4" && IsOpen == true) RemapCOM4();
            return IsOpen;
        }


        public void Write(String data)
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            Write(buffer, 0, buffer.Length);
        }

        public void Write(Char data)
        {
            Write(data.ToString());
        }

        public String Read()
        {
            if (BytesToRead > 0)
            {
                var receiveBuffer = new byte[BytesToRead];
                Read(receiveBuffer, 0, receiveBuffer.Length);
                return new String(Encoding.UTF8.GetChars(receiveBuffer));
            }
            return null;
        }

        private void RemapCOM4()
        {
            Debug.Print("remapping COM4");
            // remap COM4 RX (in)  pin from P4.29/DIO17 to P0.26 (that is An3)
            // remap COM4 TX (out) pin from P4.28/DIO13 to P0.25 (that is An2)
            var pinsel9 = new Register(0xE002C024);
            pinsel9.Write(0); // COM4 is now disconnected from P4.28 and P4.29
            var pinsel1 = new Register(0xE002C004);
            pinsel1.SetBits(0xf << 18); // COM4 is now connected to An3 and An4
        }



    }
}
