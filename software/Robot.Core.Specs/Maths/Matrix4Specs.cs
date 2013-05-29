using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Machine.Specifications;
using Robot.Core.Maths;
using developwithpassion.specifications.fakeiteasy;

namespace Robot.Core.Specs.Maths
{

    public class should_equal_identity : with_matrix4 
    {
        It should_equal = () => sut.ShouldEqual(Matrix4.Identity);
    }

    public class XYZ_access : with_matrix4
    {
        Because of = () =>
        {
            sut.X = 2;
            sut.Y = 3;
            sut.Z = 5;
        };
        It should_set_x = () => sut.X.ShouldEqual(2);
        It should_set_y = () => sut.Y.ShouldEqual(3);
        It should_set_z = () => sut.Z.ShouldEqual(5);
        It should_not_set_any_others = () => sut.ShouldEqual(Matrix4.Translate(2, 3, 5));
    }

    public class failed_array_set_access : with_matrix4
    {
        Because of = () => exception = Catch.Exception(()=>sut[5, 5] = 5);
        It should_not_set_any_others = () => exception.ShouldBeOfType<ArgumentOutOfRangeException>();
        static Exception exception;
    }
    public class failed_array_get_access : with_matrix4
    {
        Because of = () => exception = Catch.Exception(() =>
            {
                var temp = sut[5, 5];
            });
        It should_not_set_any_others = () => exception.ShouldBeOfType<ArgumentOutOfRangeException>();
        static Exception exception;
    }

    public class when_length_is_calculated : with_matrix4
    {
        Because of = () => result = Matrix4.Translate(4,4,2);
        It identiy_should_have_zero_length = () => sut.Length.ShouldBeCloseTo(0);
        It should_have_correct_length = () => result.Length.ShouldBeCloseTo(6);
        It should_be_sign_agnostic = () => result.Length.ShouldBeCloseTo(Matrix4.Translate(-4, 4, -2).Length);
        It should_have_correct_length_squared = () => result.LengthSquared.ShouldBeCloseTo(36);
    }

    public class multiplication:with_matrix4
    {
        Because of = () => result = Matrix4.Translate(2, 3, 5) * Matrix4.Translate(7, 11, 13);
        It should_equal = () => result.ShouldEqual(Matrix4.Translate(9, 14, 18));
    }


    public class Inverse:with_matrix4
    {
        private Because of =
            () =>
            result =
            Matrix4.RotateX(Angle.FromRadians(Math.PI))*Matrix4.RotateY(Angle.FromRadians(Math.PI))*
            Matrix4.RotateZ(Angle.FromRadians(Math.PI))*Matrix4.Translate(2, 3, 5);
        It should_invert_translation = () => Matrix4.Translate(9, 14, 18).Inverse().ShouldEqual(Matrix4.Translate(-9, -14, -18));
       //It should_invert_all = () => result.ShouldEqual(Matrix4.Identity);

    }
}
