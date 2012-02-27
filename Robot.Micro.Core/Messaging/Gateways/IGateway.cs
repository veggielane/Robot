using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Devices.CommunicationChannels;

namespace Robot.Micro.Core.Messaging.Gateways
{
    public interface IGateway
    {
        event Message ReceiveMessage;

    }
}
