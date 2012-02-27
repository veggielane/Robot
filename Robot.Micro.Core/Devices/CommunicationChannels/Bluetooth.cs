using System;
using System.IO.Ports;
using System.Text;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Messaging.Messages;
using Robot.Micro.Core.Serialisation;
using Robot.Micro.Core.Timing;

namespace Robot.Micro.Core.Devices.CommunicationChannels
{
    public class Bluetooth : ExtendedSerialPort, IChannel
    {
        public event Message ReceiveMessage;
        
        private readonly JSON _json = new JSON();
        public Bluetooth(String port, int baudRate)
            : base(port, baudRate)
        {

            DataReceived += (sender, e) =>
            {
                if (e != null && e.EventType == SerialData.Chars && BytesToRead > 0 && ReceiveMessage != null)
                    ReceiveMessage(ParseMessage(Read()));
            };
        }

        private IMessage ParseMessage(string data)
        {
            return new RemoteMessage{ Msg =  data };
        }

        public void SendMessage(IMessage message)
        {
            Write(_json.Encode(message));
        }
    }
}
