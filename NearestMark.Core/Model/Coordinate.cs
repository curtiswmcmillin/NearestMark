using System;
using System.Collections.Generic;

namespace NearestMark.Core.Model
{
    /// <summary>
    /// Holds one or more Points and a Distance
    /// </summary>
    public class Coordinate
    {
        private double _distance;
        private List<double> _points = new List<double>();

        public Coordinate() { }

        private void loadPoints(string[] points)
        {
            foreach (var p in points)
            {
                double result;
                if (double.TryParse(p, out result))
                {
                    _points.Add(result);
                }
                else
                {
                    throw new ApplicationException(string.Format("Unable to parse the point '{0}'.  Points must be numbers.", p));
                }
            }
        }

        public Coordinate(string[] points)
        {
            loadPoints(points);
        }

        public Coordinate(string points)
        {
            loadPoints(points.Split(new char[] { ',' }));
        }

        public double Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                _distance = value;
            }
        }

        public List<double> Points
        {
            get
            {
                return _points;
            }
        }

        public override string ToString()
        {
            return string.Format("({0})", String.Join(",", Points.ToArray()));
        }
    }
}
