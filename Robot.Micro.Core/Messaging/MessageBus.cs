using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Reactive;
namespace Robot.Micro.Core.Messaging
{
    public class MessageBus : Observable
    {
        public void Add(IMessage message)
        {
            OnNext(message);
        }
    }
}
