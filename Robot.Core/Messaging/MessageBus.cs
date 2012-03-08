using System;
using Robot.Core.Reactive;

namespace Robot.Core.Messaging
{
    public interface IMessageBus : IObservable<IMessage>
    {
        void Add(IMessage message);
    }

    public class MessageBus : Observable<IMessage>, IMessageBus
    {
        public void Add(IMessage message)
        {
            OnNext(message);
        }
    }
}
