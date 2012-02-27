using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Reactive;

namespace Robot.Micro.Core.Messaging.Gateways
{
    public interface IGateway : IObservable
    {
        void Add(IMessage message);
    }
}
