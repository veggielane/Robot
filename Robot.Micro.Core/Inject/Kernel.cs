using System;
using System.Reflection;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Inject
{
    
    //cant get constuction parameters
    //ConstructorInfo.GetParameters
    public class Kernal : IKernel
    {
        public object Get(Type T)
        {
            ConstructorInfo constructor = T.GetConstructor(null);

            if (constructor != null)
            {
                //var paraminfo = constructor.
            }

            return 4;
        }
    }

    public interface IKernel
    {
        object Get(Type T);
    }
}
