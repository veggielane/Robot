using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robot.Core.FiniteStateMachine.States
{
    public class IdleState:IState
    {
        public string Name { get; private set; }
        
        public IdleState()
        {
            Name = "Idle";
        }

        public void Start()
        {
            Console.WriteLine("Starting State: " + Name);
        }

        public void Stop()
        {
            Console.WriteLine("Stopping State: " + Name);
        }
    }

    public class StartCommand : IStateCommand {}
    public class StopCommand : IStateCommand { }
    
}
