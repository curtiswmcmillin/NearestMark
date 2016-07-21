﻿using NearestMark.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearestMark.Core
{
    public static class Distance
    {
        public static Coordinate GetNearestCoordinate(Coordinate coordinate, List<Coordinate> allCoordinates)
        {
            var point1 = coordinate.Points;

            // get/store distance from coord for each coordinate in the set
            foreach ( var c in allCoordinates )
            {
                c.Distance = Math.Sqrt(point1.Zip(c.Points, (a, b) => (a - b) * (a - b)).Sum());
            }

            // find shortest Distance in allCoordinates
            return allCoordinates.OrderBy(c => c.Distance).Take(1).ToList()[0];
        }        
    }
}