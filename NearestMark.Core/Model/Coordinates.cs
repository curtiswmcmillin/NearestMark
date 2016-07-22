using System;
using System.Collections.Generic;
using System.Linq;

namespace NearestMark.Core.Model
{
    public class Coordinates : List<Coordinate>
    {
        private void calcDistances(Coordinate coordinate)
        {
            // get/store distance from coord for each coordinate in allCoordinates
            foreach (var c in this)
            {
                c.Distance = Math.Sqrt(coordinate.Points.Zip(c.Points, (a, b) => (a - b) * (a - b)).Sum());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
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
