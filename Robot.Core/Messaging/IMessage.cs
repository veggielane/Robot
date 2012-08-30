using System;
namespace Robot.Core.Messaging
{
    public interface IMessage
    {
        DateTime Time { get; }
      //  bool Remote { get; }
    }
}