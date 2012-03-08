using System;
using System.Text;
using Microsoft.SPOT;
using Robot.Micro.Core.Messaging;

namespace Robot.Micro.Core.Serialisation
{
    /*
     * Binary Protocol
     * 
     * 
     * */


    public class BinarySerialiser:ISerialiser
    {
        public event MessageDelegate Message;

        public void Deserialise(byte[] data)
        {
            Debug.Write(new String(Encoding.UTF8.GetChars(data)));
        }

        public byte[] Serialise(IMessage message)
        {
            return new byte[0];
        }
    }
}
