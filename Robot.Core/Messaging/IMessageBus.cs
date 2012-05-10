using System;
#if MICRO
using Robot.Micro.Core.Reactive;
namespace Robot.Micro.Core.Messaging{
    public interface IMessageBus : IObservable
    {
        void Add(IMessage message);
        //void AddGateway(IGateway gateway);
    }
}
#else
namespace Robot.Core.Messaging
{
    public interface IMessageBus : IObservable<IMessage>
    {
        void Add(IMessage message);
    }
}
#endif

