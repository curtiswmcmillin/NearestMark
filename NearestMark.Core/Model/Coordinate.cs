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
        private List<long> _points = new List<long>();

        public double Distance
        {
            get
            {
                return Distance1;
            }

            set
            {
                Distance1 = value;
            }
        }

        public double Distance1
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

        public List<long> Points
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
