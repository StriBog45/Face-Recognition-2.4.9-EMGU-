using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Recognition
{
    public class RecognizeTestResult
    {
        public string NameOfTest { get; set; }
        public double Eigen { get; set; }
        public double Fisher { get; set; }
        public double LBPH { get; set; }

        public List<FaceInfo> eigenList;
        public List<FaceInfo> fisherList;
        public List<FaceInfo> lbphList;

        public RecognizeTestResult(string nameOfTest)
        {
            NameOfTest = nameOfTest;
            eigenList = new List<FaceInfo>();
            fisherList = new List<FaceInfo>();
            lbphList = new List<FaceInfo>();
        }
    }
}
