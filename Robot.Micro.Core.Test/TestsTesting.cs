using System;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Test
{
    public class TestsTesting
    {
         public void TestIsTrue()
         {
             Assert.IsTrue(true, "This should not throw an exception");
         }
         public void TestIsFalse()
         {
             Assert.IsFalse(false, "This should not throw an exception");
         }
         public void TestEquals()
         {
             Assert.IsEqual(10,10);
         }
         public void TestNearlyEquals()
         {
             Assert.IsEqual(10, 10);
         }
    }
}
