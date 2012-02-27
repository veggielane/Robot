using Robot.Micro.Core.Messaging.Gateways;
using Robot.Micro.Core.Reactive;
namespace Robot.Micro.Core.Messaging
{
    public interface IMessageBus : IObservable
    {
        void Add(IMessage message);
        void AddGateway(IGateway gateway);

    }

    public class MessageBus : Observable, IMessageBus
    {
        public void Add(IMessage message)
        {
            OnNext(message);
        }

        public void AddGateway(IGateway gateway)
        {
            gateway.Subscribe(obj => Add(obj as IMessage));
            this.Where(obj => ((IMessage)obj).Remote).Subscribe(obj => gateway.Add(obj as IMessage));
        }
    }
}
