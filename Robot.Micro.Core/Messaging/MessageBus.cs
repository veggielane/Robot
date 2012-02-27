using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Reactive;
namespace Robot.Micro.Core.Messaging
{
    public interface IMessageBus : IObservable
    {
        void Add(IMessage message);
 }

    public class MessageBus : Observable, IMessageBus
    {
        public void Add(IMessage message)
        {
            OnNext(message);
        }
    }
}
