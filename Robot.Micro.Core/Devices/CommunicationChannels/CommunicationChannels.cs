using Robot.Micro.Core.Messaging;

namespace Robot.Micro.Core.Devices.CommunicationChannels
{
    public class CommunicationChannels
    {
        private readonly MessageBus _bus;
        public CommunicationChannels(MessageBus bus)
        {
            _bus = bus;
        }
        public void Add(IChannel channel)
        {
            channel.Connect();
            channel.ReceiveMessage += msg => _bus.OnNext(msg);
            _bus.Subscribe(obj => channel.SendMessage((IMessage)obj));
        }
    }
}
