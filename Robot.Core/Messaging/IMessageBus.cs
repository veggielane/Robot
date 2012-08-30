using System;
namespace Robot.Core.Messaging
{
    public interface IMessageBus : IObservable<IMessage>
    {
        void Add(IMessage message);
    }
}

