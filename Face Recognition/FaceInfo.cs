using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Recognition
{
    public class FaceInfo
    {
        public string Label { get; set; }
        public string Distance { get; set; }

        public FaceInfo(string label,string distance)
        {
            Label = label;
            Distance = distance;
        }
        public FaceInfo(string label, float distance)
        {
            Label = label;
            Distance = distance.ToString();
        }
        public FaceInfo(string label, double distance)
        {
            Label = label;
            Distance = distance.ToString();
        }
    }
}
