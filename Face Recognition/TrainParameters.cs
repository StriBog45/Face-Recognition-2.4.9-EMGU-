using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Recognition
{
    public class TrainParameters
    {
        public LBPHData LBPH;
        public EigenData Eigen;
        public FisherData Fisher;
        public string RecognizerType { get; set; }

        public TrainParameters()
        {
            LBPH = new LBPHData();
            Eigen = new EigenData();
            Fisher = new FisherData();
        }
    }
}
