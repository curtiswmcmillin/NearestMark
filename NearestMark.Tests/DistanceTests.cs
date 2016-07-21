using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NearestMark.Core.Model;
using System.Collections.Generic;

namespace NearestMark.Core.Tests
{
    [TestClass]
    public class DistanceTests
    {
        
        /// <summary>
        /// Given the initial input set: (1.0,1.4)(10.344,0) 
        /// followed by an input of 0,0 the program should return that 1.0,1.4 is the closest point.
        /// </summary>
        [TestMethod()]
        public void Test_InputSet_2D()
        {
            // arrange
            var default2DCoordinate = new Coordinate();
            default2DCoordinate.Points.Add(0);
            default2DCoordinate.Points.Add(0);

            // create the initial set of 2D coordinates
            var initialSet = new List<Coordinate>();
            var c1 = new Coordinate("1.0,1.4");
            var c2 = new Coordinate("10.344,0");

            initialSet.Add(c1);
            initialSet.Add(c2);

            // act
            var nearest = Distance.GetNearestCoordinate(default2DCoordinate, initialSet);

            // assert
            Assert.AreEqual(nearest, c1);
        }

        /// <summary>
        /// Given the initial input set: (1,1,1)(10,0,0)(2,2,2) 
        /// followed by an input of 0,0,0 the program should return that 1,1,1 is the closest point.
        /// </summary>
        [TestMethod()]
        public void Test_InputSet_3D()
        {
            // arrange
            var default3DCoordinate = new Coordinate();
            default3DCoordinate.Points.Add(0);
            default3DCoordinate.Points.Add(0);
            default3DCoordinate.Points.Add(0);

            // create the initial set of 2D coordinates
            var initialSet = new List<Coordinate>();
            var c3 = new Coordinate("1,1,1");
            var c2 = new Coordinate("10,0,0");
            var c1 = new Coordinate("2,2,2");

            initialSet.Add(c1);
            initialSet.Add(c2);
            initialSet.Add(c3);

            // act
            var nearest = Distance.GetNearestCoordinate(default3DCoordinate, initialSet);

            // assert
            Assert.AreEqual(nearest, c3);
        }
    }
}
