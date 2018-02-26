using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Recognition
{
    public class LBPHData
    {
        public double Treshold { get; set; }
        public int Neighbors { get; set; }
        public int Radius { get; set; }
        public int GridX { get; set; }
        public int GridY { get; set; }
    }
}
