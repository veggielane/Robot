using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot.Core.Maths;
namespace Robot.Core.Test.Maths
{
    [TestClass]
    public class AngleTests
    {
        private Angle _angle1;
        private Angle _angle2;
        private Angle _angle3;
        public AngleTests()
        {
            _angle1 = Angle.FromDegrees(30.0);
            _angle2 = Angle.FromDegrees(60.0);
            _angle3 = Angle.FromRadians(Math.PI);
        }

        [TestMethod]
        public void TestStaticConstructors()
        {
            Assert.AreEqual(_angle1.Degrees, 30.0, 0.00001);
            Assert.AreEqual(_angle2.Degrees, 60.0, 0.00001);
            Assert.AreEqual(_angle3.Radians, Math.PI);
        }
        [TestMethod]
        public void TestingConversions()
        {
            Assert.AreEqual(_angle1.Radians, Math.PI / 6.0);
            Assert.AreEqual(_angle2.Radians, Math.PI / 3.0);
            Assert.AreEqual(_angle3.Degrees, 180.0);
        }
        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual((_angle1 + _angle2).Degrees, 90.0);
        }
    }
}
