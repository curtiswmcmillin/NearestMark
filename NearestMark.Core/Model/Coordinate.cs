using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearestMark.Core.Model
{
    public class Coordinate
    {
        private double _distance;
        private List<double> _points = new List<double>();

        public Coordinate() { }
        public Coordinate(string points)
        {            
            foreach (var p in points.Split(new char[] { ',' }))
            {
                _points.Add(double.Parse(p));
            }
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
