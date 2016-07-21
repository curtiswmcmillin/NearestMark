using NearestMark.Core.Model;
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
            // get/store distance from coord for each coordinate in the allCoordinates
            foreach ( var c in allCoordinates )
            {
                c.Distance = Math.Sqrt(coordinate.Points.Zip(c.Points, (a, b) => (a - b) * (a - b)).Sum());
            }

            // find shortest Distance in allCoordinates by sorting ASC and taking the first element
            return allCoordinates.OrderBy(c => c.Distance).ToList()[0];
        }        
    }
}
