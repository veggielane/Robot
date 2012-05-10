#if MICRO
using Robot.Micro.Core.Reactive;
namespace Robot.Micro.Core.Messaging
{
    public class MessageBus : Observable, IMessageBus
    {
        public void Add(IMessage message)
        {
            OnNext(message);
        }

        //public void AddGateway(IGateway gateway)
        //{
        //    gateway.Subscribe(obj => Add(obj as IMessage));
        //    this.Where(obj => ((IMessage)obj).Remote).Subscribe(obj => gateway.Add(obj as IMessage));
        //}
    }
}
#else
using Robot.Core.Reactive;
namespace Robot.Core.Messaging
{
    public class MessageBus : Observable<IMessage>, IMessageBus
    {
        public void Add(IMessage message)
        {
            OnNext(message);
        }
    }
}

#endif

