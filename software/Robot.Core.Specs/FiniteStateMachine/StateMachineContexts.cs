using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using Robot.Core.FiniteStateMachine;
using Robot.Core.Maths;
using developwithpassion.specifications.fakeiteasy;

namespace Robot.Core.Specs.FiniteStateMachine
{
    [Subject(typeof(StateMachine))]
    public class with_state_machine : Observes<StateMachine>
    {
        Establish c = () => sut_setup.run(sm =>
            {
                sm.AddStates(new TestState(),new EndState());

                sm.AddTransition<TestState, TestCommand, EndState>();


            });
    }

    public class should_equal_identity : with_state_machine
    {
        Because of = () =>
            {
                sut.Start<TestState>();



                sut.Next<TestCommand>();
            };
        // It should_equal = () => sut.ShouldEqual(Matrix4.Identity);
    }

    public class TestState : IState
    {
        public string Name { get; private set; }
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }

    public class EndState : IState
    {
        public string Name { get; private set; }

        public void Start()
        {

        }

        public void Stop()
        {

        }
    }


    public class TestCommand : IStateCommand { }
}
