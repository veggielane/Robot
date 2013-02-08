using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Robot.Core.Devices;
using Robot.Core.Messaging;

namespace Robot.Core
{
    public abstract class BaseRobot:IRobot
    {
        private readonly IMessageOutput[] _output;
        public IMessageBus Bus { get; private set; }

        protected BaseRobot(IMessageBus bus)
        {
            Bus = bus;

        }

        public abstract void Start();
        public abstract void Stop();
        public abstract void Dispose();
    }
}
