using System;
using System.Collections.Generic;
using System.Linq;

namespace NearestMark.Core.Model
{
    public class Coordinates : List<Coordinate>
    {
        /// <summary>
        /// Iterates through each Coordinate in the list, calculating the 
        /// Distance between each using Euclidean distance
        /// </summary>
        /// <param name="coordinate"></param>
        private void calcDistances(Coordinate coordinate)
        {
            // get/store distance from coord for each coordinate in the List<Coordinate> (this)
            foreach (var c in this)
            {
                c.Distance = Math.Sqrt(coordinate.Points.Zip(c.Points, (a, b) => (a - b) * (a - b)).Sum());
            }
        }

        public Coordinates() { }
        /// <summary>
        /// Parses the string of coordinates into Coordinate objects
        /// Expected format of string is '(12, 13)(-12.1, 13.5)'
        /// </summary>
        /// <param name="rawCoordinates"></param>
        public Coordinates(string rawCoordinates)
        {
            // parse string into coordinates
            var formattedCoordString = rawCoordinates.Replace(")(", "|");
            formattedCoordString = formattedCoordString.Replace("(", "");
            formattedCoordString = formattedCoordString.Replace(")", "");

            foreach (var rawCoordinate in formattedCoordString.Split(new char[] { '|' }))
            {
                this.Add(new Coordinate(rawCoordinate));
            }
        }

        /// <summary>
        /// Calculates using Euclidean distance the farthest coordinate from the set/list
        /// </summary>
        /// <param name="coordinate">A Coordinate object with 1 or more points</param>
        /// <returns></returns>
        public Coordinate GetFarthestCoordinate(Coordinate coordinate)
        {
            calcDistances(coordinate);

            // find farthest Distance in allCoordinates by sorting DESC and taking the first element
            return this.OrderByDescending(c => c.Distance).ToList()[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Coordinate GetNearestCoordinate(Coordinate coordinate)
        {
            calcDistances(coordinate);

            // find nearest Distance in allCoordinates by sorting ASC and taking the first element
            return this.OrderBy(c => c.Distance).ToList()[0];
        }
    }
}
