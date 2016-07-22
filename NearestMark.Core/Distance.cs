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

        /// <summary>
        /// Validates input and throws ApplicationExceptions when invalid.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="allCoordinates"></param>
        private static void validateInputParms(Coordinate coordinate, List<Coordinate> allCoordinates)
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
                throw new ArgumentException("No coordinates", "allCoordinates");
            }
            if(coordinate.Points == null || coordinate.Points.Count == 0)
            {
                throw new ArgumentException("No points", "allCoordinates");
            }
        }

        /// <summary>
        /// Using Euclidean distance, this calculates point separation (http://en.wikipedia.org/wiki/Euclidean_distance)
        /// between the Coordinate and allCoordinates, returning the point farthest from the set.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="allCoordinates"></param>
        /// <returns></returns>
        public static Coordinate GetNearestCoordinate(Coordinate coordinate, List<Coordinate> allCoordinates)
        {
            validateInputParms(coordinate, allCoordinates);

            allCoordinates = calcDistances(coordinate, allCoordinates);

            // find shortest Distance in allCoordinates by sorting ASC and taking the first element
            return allCoordinates.OrderBy(c => c.Distance).ToList()[0];
        }

        /// <summary>
        /// Using Euclidean distance, this calculates point separation (http://en.wikipedia.org/wiki/Euclidean_distance)
        /// between the Coordinate and allCoordinates, returning the point farthest from the set.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="allCoordinates"></param>
        /// <returns></returns>
        public static Coordinate GetFarthestCoordinate(Coordinate coordinate, List<Coordinate> allCoordinates)
        {
            validateInputParms(coordinate, allCoordinates);

            allCoordinates = calcDistances(coordinate, allCoordinates);
            
            // find shortest Distance in allCoordinates by sorting DESC and taking the first element
            return allCoordinates.OrderByDescending(c => c.Distance).ToList()[0];
        }
    }
}
