using System;
using System.Text;
using Microsoft.SPOT;
using Robot.Micro.Core.Messaging;

namespace Robot.Micro.Core.Serialisation
{
    public class ASCIISerialiser : ISerialiser
    {
        public event MessageDelegate Message;

        private string _buffer = "";

        public void Deserialise(byte[] data)
        {
            
        }

        public byte[] Serialise(IMessage message)
        {
            return Encoding.UTF8.GetBytes(message.ToString());
        }
    }
}
