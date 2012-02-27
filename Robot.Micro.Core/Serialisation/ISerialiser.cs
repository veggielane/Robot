using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Messaging;

namespace Robot.Micro.Core.Serialisation
{
    public delegate void MessageDelegate(IMessage message);
    
    public interface ISerialiser
    {
        event MessageDelegate Message;
        void Deserialise(Byte[] data);
        Byte[] Serialise(IMessage message);
    }
}
