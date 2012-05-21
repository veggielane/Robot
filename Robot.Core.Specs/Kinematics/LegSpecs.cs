using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakeItEasy;
using Machine.Specifications;
using Robot.Core.Kinematics;
using Robot.Core.Maths;
using developwithpassion.specifications.fakeiteasy;

namespace Robot.Core.Specs.Kinematics
{

    public class LegSetup : LegContext
    {
        //Establish context = () => body.Position = Matrix4.Identity;
        Because of = () =>
        {
            body.Position = Matrix4.Identity;
        };
        private It should_be_equal_to_translation = () => leg.BasePosition.ShouldEqual(Matrix4.Translate(10.0, 0.0, 0.0));
    }

    public class LegInverseHome : LegContext
    {
        Because of = () =>
        {
            body.Position = Matrix4.Translate(0, 0.0, 6.0);
            leg.Inverse();
        };
        private It should_make_coxa_zero = () => leg.CoxaServo.Angle.ShouldEqual(Angle.Zero);
        private It should_make_femur_zero = () => leg.FemurServo.Angle.ShouldEqual(Angle.Zero);
        private It should_make_tibia_zero = () => leg.TibiaServo.Angle.ShouldEqual(Angle.FromDegrees(0));
    }

    public class LegInverseBodyAbove : LegContext
    {
        Because of = () =>
        {
            body.Position = Matrix4.Translate(0, 0.0, 10.0);
            leg.Inverse();
        };
        private It should_make_coxa_zero = () => leg.CoxaServo.Angle.ShouldEqual(Angle.Zero);
        private It should_make_femur_zero = () => leg.FemurServo.Angle.ShouldEqual(Angle.FromDegrees(-30.9008741726517));
        private It should_make_tibia_zero = () => leg.TibiaServo.Angle.ShouldEqual(Angle.FromDegrees(-41.8103149));
    }

    public class LegInverseBodyBelow : LegContext
    {
        Because of = () =>
        {
            body.Position = Matrix4.Translate(0, 0.0, 4.0);
            leg.Inverse();
        };
        private It should_make_coxa_zero = () => leg.CoxaServo.Angle.ShouldEqual(Angle.Zero);
        private It should_make_femur_zero = () => leg.FemurServo.Angle.ShouldEqual(Angle.FromDegrees(14.4381484204));
        private It should_make_tibia_zero = () => leg.TibiaServo.Angle.ShouldEqual(Angle.FromDegrees(12.0246992));
    }

    public abstract class LegContext
    {
        protected static IBody body;
        protected static Leg3DOF leg;

        Establish context = () =>
                                {
            body = new Body();
            leg = new Leg3DOF(body)
            {
                Offset = Matrix4.Translate(10, 0.0, 0),
                CoxaLength = 5.0,
                FemurLength = 8.0,
                TibiaLength = 6.0,
                //FemurInvert = true,

                TibiaOffset = Angle.FromDegrees(-90.0),
                //TibiaInvert = true,
                FootPosition = Matrix4.Translate(23, 0.0, 0),
            };
        };
    }
}
