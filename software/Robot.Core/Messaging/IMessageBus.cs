using System;
namespace Robot.Core.Messaging
{
    public interface IMessageBus
    {
        IObservable<IMessage> Messages { get; }
        void Add(IMessage message);
    }
}
