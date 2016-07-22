using NearestMark.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NearestMark.Core
{
    public static class Distance
    {
        private static List<Coordinate> calcDistances(Coordinate coordinate, List<Coordinate> coordinates)
        {
            // get/store distance from coord for each coordinate in allCoordinates
            foreach (var c in coordinates)
            {
                c.Distance = Math.Sqrt(coordinate.Points.Zip(c.Points, (a, b) => (a - b) * (a - b)).Sum());
            }
            return coordinates;
        }

        private static void validateParms(Coordinate coordinate, List<Coordinate> allCoordinates)
        {
            if (allCoordinates == null)
            {
                throw new ArgumentNullException("allCoordinates");
            }
            if (coordinate == null)
            {
                throw new ArgumentNullException("coordinate");
            }
            if (allCoordinates.Count == 0)
            {
                throw new ArgumentException("No coordinates in allCoordinates parm");
            }
        }

        public static Coordinate GetNearestCoordinate(Coordinate coordinate, List<Coordinate> allCoordinates)
        {
            validateParms(coordinate, allCoordinates);

            allCoordinates = calcDistances(coordinate, allCoordinates);

            // find shortest Distance in allCoordinates by sorting ASC and taking the first element
            return allCoordinates.OrderBy(c => c.Distance).ToList()[0];
        }

        public static Coordinate GetFarthestCoordinate(Coordinate coordinate, List<Coordinate> allCoordinates)
        {
            validateParms(coordinate, allCoordinates);

            allCoordinates = calcDistances(coordinate, allCoordinates);
            
            // find shortest Distance in allCoordinates by sorting DESC and taking the first element
            return allCoordinates.OrderByDescending(c => c.Distance).ToList()[0];
        }
    }
}
