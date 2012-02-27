using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Reactive;

namespace Robot.Micro.Core.Messaging.Gateways
{
    public abstract class Gateway : Observable, IGateway
    {
        public void Add(IMessage message)
        {
            OnNext(message);
        }
    }
}
