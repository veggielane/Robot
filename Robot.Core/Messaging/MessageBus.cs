using Robot.Core.Reactive;
namespace Robot.Core.Messaging
{
    public class MessageBus : ConcurrentObservable<IMessage>, IMessageBus
    {
        public void Add(IMessage message)
        {
            OnNext(message);
        }
    }
}

