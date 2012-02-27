using System;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Serialisation
{
    public class BinarySerialiser:ISerialiser
    {
        public event MessageDelegate Message;

        public void Deserialise(byte[] data)
        {
            
        }
    }
}
