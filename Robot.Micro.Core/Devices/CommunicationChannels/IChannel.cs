using Robot.Micro.Core.Messaging;

namespace Robot.Micro.Core.Devices.CommunicationChannels
{
    public delegate void Message(IMessage message);
    public interface IChannel
    {
        event Message ReceiveMessage;
        void SendMessage(IMessage message);
        bool Connect();
        void Close();
    }
}
