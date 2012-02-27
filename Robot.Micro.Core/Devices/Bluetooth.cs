using System;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Messaging.Messages;

namespace Robot.Micro.Core.Devices
{
    public class Bluetooth : ExtendedSerialPort
    {
        //public event Message ReceiveMessage;
        public Bluetooth(String port, int baudRate)
            : base(port, baudRate)
        {

            /*
            DataReceived += (sender, e) =>
            {
                if (e != null && e.EventType == SerialData.Chars && BytesToRead > 0 && ReceiveMessage != null)
                    ReceiveMessage(ParseMessage(Read()));
            };*/
        }

        private IMessage ParseMessage(string data)
        {
            return new RemoteMessage{ Msg =  data };
        }
        /*
        public void SendMessage(IMessage message)
        {
            Write(_json.Encode(message));
        }*/
    }
}
