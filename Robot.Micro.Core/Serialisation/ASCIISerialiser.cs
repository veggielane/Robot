using System;
using System.Reflection;
using System.Text;
using Microsoft.SPOT;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Messaging.Messages;

namespace Robot.Micro.Core.Serialisation
{
    public class ASCIISerialiser : ISerialiser
    {
        /*
         * ASCII Protocol
         *   Char     Meaning
         *   [        Start
         *   ]        End
         *   
         * [DebugMessage|Msg="test"]
         */ 

        public event MessageDelegate Message;


        private ASCIIMessage _msg = null;


        private void Consume(char c)
        {
            if (_msg != null)
            {
                _msg.Buffer += c;
                if (c == ']')
                {
                    if (Message != null)
                    {
                        Message(_msg.ToMessage());
                    }
                    _msg = null;
                }
            }
            else
            {
                if (c == '[')
                {
                    _msg = new ASCIIMessage();
                    _msg.Buffer += c;
                }
            }
        }


        public void Deserialise(byte[] data)
        {
            foreach (byte b in data)
            {
                Consume((char)b);
            }
        }

        public byte[] Serialise(IMessage message)
        {
            return Encoding.UTF8.GetBytes(message.ToString());
        }
    }

    public class ASCIIMessage
    {
        public short Length = 0;
        public String Buffer = "";
        public IMessage ToMessage()
        {
            String[] split = Buffer.Trim(new[]{'[',']'}).Split('|');
            String[] parameters = split[1].Split(',');
            Type type = Type.GetType("Robot.Micro.Core.Messaging.Messages." + split[0]);
            if (type != null)
            {
                Debug.Write("creating");
                var constructor = type.GetConstructor(new Type[] { });
                if (constructor != null)
                {
                    var obj = constructor.Invoke(null);
                    foreach (var parameter in parameters)
                    {
                        Debug.Write(parameter);
                        var temp = parameter.Split('=');
                        MethodInfo m = type.GetMethod("set_" + temp[0]);
                        if (m != null)
                        {
                            Debug.Write("invoke");
                            m.Invoke(obj, new object[] { temp[1] });
                        }
                    }
                    return obj as IMessage;
                }
            }
            return new DebugMessage
            {
                Msg = "Could Not Parse Message"
            };
        }
    }
}
