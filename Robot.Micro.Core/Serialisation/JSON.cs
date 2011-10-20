using System;
using System.Reflection;

namespace Robot.Micro.Core.Serialisation
{
    public class JSON
    {
        public string Encode(object obj)
        {
            var type = obj.GetType();
            var json = "{\"" + type.Name + "\":{";
            var first = true;

            foreach (var info in type.GetMethods())
            {
                if (info.Name.Substring(0, 4) != "get_") continue;
                if(!first)json += ",";
                json += "\"" + info.Name.Substring(4) + "\":";
                var m = type.GetMethod(info.Name, BindingFlags.Public | BindingFlags.Instance);
                if(m.ReturnType == typeof(string))
                {
                    json += "\"" + m.Invoke(obj, null)+ "\"";
                }
                else if (m.ReturnType == typeof(DateTime))
                {
                    json += "\"" + ((DateTime)m.Invoke(obj, null)).ToString("HH:mm:ss") + "\"";

                }else
                {
                    json += m.Invoke(obj, null);
                }
                first = false;
            }
            json += "}}\r\n";
            return json;
        }
        public object Decode(string json, Type type)
        {
            /*
            ConstructorInfo constructor = type.GetConstructor(null);
            Hashtable t = ParseObject(json);
            char c;
            string buffer = "";
            for (int i = 0; i < json.Length; i++)
            {
                c = json[i];
                if (c == '{')
                {
                    buffer += "";
                }
            }

            
            if (constructor != null) constructor.Invoke(null);
             */ 
            return new object();
        }
    }
}
