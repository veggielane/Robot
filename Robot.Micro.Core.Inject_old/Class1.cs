using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Robot.Micro.Core.Inject
{
    public class Kernal : IKernel
    {
        public object Get(Type T)
        {
            var constructor = T.GetConstructor(null);

            if (constructor != null)
            {
                var paraminfo = constructor.GetParameters();
                foreach (ParameterInfo parameterInfo in paraminfo)
                {
                    Debug.Write(parameterInfo.Name);
                }
            }

            return 4;
        }
    }

    public interface IKernel
    {
        object Get(Type T);
    }
}

