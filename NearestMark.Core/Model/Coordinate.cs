using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearestMark.Core.Model
{
    public class Coordinate
    {
        private List<long> _points = new List<long>();
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
