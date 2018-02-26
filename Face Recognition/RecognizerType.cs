using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Recognition
{
    public static class RecognizerType
    {
        public static string Eigen = "EMGU.CV.EigenFaceRecognizer";
        public static string Fisher = "EMGU.CV.FisherFaceRecognizer";
        public static string LBPH = "EMGU.CV.LBPHFaceRecognizer";
    }
}
