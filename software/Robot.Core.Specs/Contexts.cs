using FakeItEasy;
using Machine.Specifications;
using Robot.Core.Messaging;
using Robot.Core.Timing;
using developwithpassion.specifications.fakeiteasy;

namespace Robot.Core.Specs
{

    //[Subject(typeof(BaseRobot))]
    //public class timer_should_start : Observes<BaseRobot>
    //{
    //    Establish c = () => { };
    //    Because of = () => sut.Start();
    //    It should = () => A.CallTo(() => sut.Timer.Start()).MustHaveHappened();
    //}


    [Subject(typeof(BootStrap))]
    public class with_a_new_BootStrap : Observes<BootStrap>
    {
        Establish c = () =>{ };
    }

    public class robot_is_started:with_a_new_BootStrap
    {
       // It should_start_the_robot = () => A.CallTo(() => sut.Robot.Start()).MustHaveHappened();
    }






}
