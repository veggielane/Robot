using System;
using System.Reactive.Linq;
using Robot.Core.Devices;
using Robot.Core.Extensions;
using Robot.Core.Maths;
using Robot.Core.Messaging.Messages;
using Robot.Core.States;

namespace Robot.Stompy.States
{
    class MainState:IState
    {
        private readonly StompyRobot _robot;
        public string Name { get; private set; }

        public MainState(StompyRobot robot)
        {
            _robot = robot;
            Name = "Main";
        }

        public void Dispose()
        {

        }

        public void Start()
        {
            _robot.Bus.OfType<KeyPress>().Subscribe(m =>
                {
                    switch (m.Key)
                    {

                        case ConsoleKey.LeftArrow:
                            _robot.RightMiddle.FootOffset += new Vect3(5, 0, 0);
                            break;
                        case ConsoleKey.UpArrow:
                            _robot.RightMiddle.FootOffset += new Vect3(0, 5, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            _robot.RightMiddle.FootOffset += new Vect3(-5, 0, 10);
                            break;
                        case ConsoleKey.DownArrow:
                            _robot.RightMiddle.FootOffset += new Vect3(0, -5, 0);
                            break;
                        
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    _robot.ServoController.Update(ServoMove.Time, 500);
                });

            _robot.Bus.Add(new DebugMessage("Moving"));
            _robot.ServoController.Update(ServoMove.Time, 4000);
        }

        public void Stop()
        {

        }
    }
}
