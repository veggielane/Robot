using System;
using System.IO.Ports;
using Microsoft.SPOT;
using Robot.Micro.Core.Devices;
using Robot.Micro.Core.Reactive;
using Robot.Micro.Core.Serialisation;

namespace Robot.Micro.Core.Messaging.Gateways
{
    public class BluetoothGateway:Gateway
    {
        private readonly Bluetooth _device;
        public BluetoothGateway(Bluetooth device, ISerialiser serialiser)
        {
            _device = device;
            serialiser.Message += Add;
            this.Where(obj => ((IMessage)obj).Remote).Subscribe(obj => _device.Write(serialiser.Serialise(obj as IMessage)));
            _device.DataReceived += (sender, e) =>
            {
                if (e == null || e.EventType != SerialData.Chars || _device.BytesToRead <= 0) return;
                var receiveBuffer = new byte[_device.BytesToRead];
                _device.Read(receiveBuffer, 0, receiveBuffer.Length);
                serialiser.Deserialise(receiveBuffer);
            };
        }
    }
}
