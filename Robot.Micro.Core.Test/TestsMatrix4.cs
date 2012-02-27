using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Maths;
namespace Robot.Micro.Core.Test
{
    public class TestsMatrix4
    {
        public void TestMatrix4Equality()
        {
            Assert.IsTrue(Matrix4.Identity == Matrix4.Identity, "Equality Fail");
        }

        public void TestMatrix4Identity()
        {
            Assert.IsTrue(Matrix4.Identity== new Matrix4(new[]{
                new[]{ 1.0, 0.0, 0.0, 0.0 }, 
                new[]{ 0.0, 1.0, 0.0, 0.0 },
                new[]{ 0.0, 0.0, 1.0, 0.0 },
                new[]{ 0.0, 0.0, 0.0, 1.0 }}), "Identity Fail");
        }
        
        public void TestMatrix4RotateX()
        {
            Assert.IsTrue(Matrix4.RotateX(Angle.FromRadians(MathsHelper.Pi)) == new Matrix4(new[]{
                new[]{ 1.0, 0.0, 0.0, 0.0 }, 
                new[]{ 0.0, -1.0, 0.0, 0.0 },
                new[]{ 0.0, 0.0, -1.0, 0.0 },
                new[]{ 0.0, 0.0, 0.0, 1.0 }}), "RotateX Fail");
        }

        public void TestMatrix4RotateY()
        {
            Assert.IsTrue(Matrix4.RotateY(Angle.FromRadians(MathsHelper.Pi)) == new Matrix4(new[]{
                new[]{ -1.0, 0.0, 0.0, 0.0 }, 
                new[]{ 0.0, 1.0, 0.0, 0.0 },
                new[]{ 0.0, 0.0, -1.0, 0.0 },
                new[]{ 0.0, 0.0, 0.0, 1.0 }}), "RotateY Fail");
        }

        public void TestMatrix4RotateZ()
        {
            Assert.IsTrue(Matrix4.RotateZ(Angle.FromRadians(MathsHelper.Pi)) == new Matrix4(new[]{
                new[]{ -1.0, 0.0, 0.0, 0.0 }, 
                new[]{ 0.0, -1.0, 0.0, 0.0 },
                new[]{ 0.0, 0.0, 1.0, 0.0 },
                new[]{ 0.0, 0.0, 0.0, 1.0 }}), "RotateZ Fail");
        }

        public void TestMatrix4Rotates()
        {
            Assert.IsTrue(Matrix4.RotateX(Angle.FromRadians(MathsHelper.TwoPi)) == Matrix4.Rotate(Axis.X, Angle.FromRadians(MathsHelper.TwoPi)), "RotateX Fail");
            Assert.IsTrue(Matrix4.RotateY(Angle.FromRadians(MathsHelper.TwoPi)) == Matrix4.Rotate(Axis.Y, Angle.FromRadians(MathsHelper.TwoPi)), "RotateY Fail");
            Assert.IsTrue(Matrix4.RotateZ(Angle.FromRadians(MathsHelper.TwoPi)) == Matrix4.Rotate(Axis.Z, Angle.FromRadians(MathsHelper.TwoPi)), "RotateZ Fail");
        }
    }
}
