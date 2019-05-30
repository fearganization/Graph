using System.Text.RegularExpressions;
using NUnit.Framework;
using Graph.Math.Equations;
using Graph.Math;

namespace Tests
{
    public class EquationsPlaneTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1,1,1,2,4,6,-1,3,8,11,-17,8,-2)]
        [TestCase(1,0,1,1,1,0,0,1,1,1,1,1,-2)]
        [TestCase(1,0,0,0,1,0,0,0,1,1,1,1,-1)]
        [TestCase(1,1,-1,1,-1,1,-1,1,1,4,4,4,-4)]
        public void Test1(params double[] coords)
        {
            EquationsPlane e = new EquationsPlane(
                new Point(
                    coords[0],
                    coords[1],
                    coords[2]),
                new Point(
                    coords[3],
                    coords[4],
                    coords[5]),
                new Point(
                    coords[6],
                    coords[7],
                    coords[8]));
            Assert.IsTrue(System.Math.Round(e.A,1)  == coords[9], e.ToString());
            Assert.IsTrue(System.Math.Round(e.B,1) == coords[10], e.ToString());
            Assert.IsTrue(System.Math.Round(e.C,1) == coords[11], e.ToString());
            Assert.IsTrue(System.Math.Round(e.D,1) == coords[12], e.ToString());
            Assert.Pass();
        }

    }
}