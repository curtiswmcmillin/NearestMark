using NearestMark.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NearestMark.Core
{
    public static class Distance
    {
        private static List<Coordinate> setDistances(Coordinate coordinate, List<Coordinate> coordinates)
        {
            // get/store distance from coord for each coordinate in allCoordinates
            foreach (var c in coordinates)
            {
                c.Distance = Math.Sqrt(coordinate.Points.Zip(c.Points, (a, b) => (a - b) * (a - b)).Sum());
            }
            return coordinates;
        }

        public static Coordinate GetNearestCoordinate(Coordinate coordinate, List<Coordinate> allCoordinates)
        {
            allCoordinates = setDistances(coordinate, allCoordinates);

            // find shortest Distance in allCoordinates by sorting ASC and taking the first element
            return allCoordinates.OrderBy(c => c.Distance).ToList()[0];
        }

        public static Coordinate GetFarthestCoordinate(Coordinate coordinate, List<Coordinate> allCoordinates)
        {
            allCoordinates = setDistances(coordinate, allCoordinates);
            
            // find shortest Distance in allCoordinates by sorting DESC and taking the first element
            return allCoordinates.OrderByDescending(c => c.Distance).ToList()[0];
        }
    }
}
