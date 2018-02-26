using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Face_Recognition
{
    public partial class TestRoom : Form
    {
        #region Variables
        //Camera specific
        Capture grabber;

        //Images for finding face
        Image<Bgr, Byte> currentFrame;
        Image<Gray, byte> result = null;
        Image<Gray, byte> gray_frame = null;

        //Classifier
        CascadeClassifier Face;

        //For aquiring images in a row
        List<Image<Gray, byte>> resultGrayImages = new List<Image<Gray, byte>>();
        List<Image<Bgr, Byte>> imagesBeforeFilters = new List<Image<Bgr, byte>>();
        int amountFacesToAcquire = 100;
        bool Record = false;
        bool IsReadyFaces = false;

        //Saving XAML Data file
        List<string> NamestoWrite = new List<string>();
        List<string> NamesforFile = new List<string>();
        XmlDocument docu = new XmlDocument();

        //Classifier with default training location
        Classifier_Train classifierRecognize;
        TrainParameters trainParameters;

        //Filters
        ImageBrightness imageBrightness = new ImageBrightness();
        #endregion

        public TestRoom(Form1 parent)
        {
            InitializeComponent();

            trainParameters = parent.trainParameters;
            Face = parent.Face;
            Initialise_capture();
        }
        private void Stop_capture()
        {
            Application.Idle -= new EventHandler(FrameGrabber);
            if (grabber != null)
            {
                grabber.Dispose();
            }
        }
        
        //Process Frame
        void FrameGrabber(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                //MCvAvgComp[][] facesDetected = gray_frame.DetectHaarCascade(Face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20)); //old method
                Rectangle[] facesDetected = Face.DetectMultiScale(gray_frame, 1.2, 10, new Size(50, 50), Size.Empty);

                //Action for each element detected
                for (int i = 0; i < facesDetected.Length; i++)// (Rectangle face_found in facesDetected)
                {
                    if(checkBoxFaceApproximate.Checked)
                        FaceApproximate(ref facesDetected[i]);

                    result = currentFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    result._EqualizeHist();
                    //face_PICBX.Image = result.ToBitmap();
                    
                    

                    if (Record && facesDetected.Length > 0 && imagesBeforeFilters.Count < amountFacesToAcquire)
                    {
                        imagesBeforeFilters.Add(currentFrame.Copy(facesDetected[i]));
                        SaveImage.Text = string.Format("We have {0} images", imagesBeforeFilters.Count);
                        if (imagesBeforeFilters.Count == amountFacesToAcquire)
                        {
                            Record = false;
                            IsReadyFaces = true;
                        }
                    }

                    //draw the face detected in the 0th (gray) channel
                    currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);
                }                

                pictureBoxCamera.Image = currentFrame.ToBitmap();
            }
        }

        //Camera
        public void Initialise_capture()
        {
            grabber = new Capture();
            grabber.QueryFrame();
            Application.Idle += new EventHandler(FrameGrabber);
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
                if (codec.FormatID == format.Guid)
                    return codec;
            return null;
        }
        void FaceApproximate(ref Rectangle rect)
        {
            rect.X += (int)(rect.Height * 0.15);
            rect.Y += (int)(rect.Width * 0.22);
            rect.Height -= (int)(rect.Height * 0.3);
            rect.Width -= (int)(rect.Width * 0.35);
        }

        private void buttonSaveParameters_Click(object sender, EventArgs e)
        {
            if (IsReadyFaces)
            {
                trainParameters.Eigen.Components = Convert.ToInt32(textBoxEigenComponents.Text);
                trainParameters.Eigen.Treshold = Convert.ToDouble(textBoxEigenTreshold.Text);

                trainParameters.Fisher.Treshold = Convert.ToDouble(textBoxFisherTreshold.Text);
                trainParameters.Fisher.Components = Convert.ToInt32(textBoxFisherComponents.Text);

                trainParameters.LBPH.Treshold = Convert.ToDouble(textBoxLBPHTreshold.Text);
                trainParameters.LBPH.Radius = Convert.ToInt32(textBoxLBPHRadius.Text);
                trainParameters.LBPH.Neighbors = Convert.ToInt32(textBoxLBPHNeighbors.Text);
                trainParameters.LBPH.GridX = Convert.ToInt32(textBoxLBPHGridX.Text);
                trainParameters.LBPH.GridY = Convert.ToInt32(textBoxLBPHGridY.Text);


                classifierRecognize = new Classifier_Train(trainParameters);
                var testResults = new List<RecognizeTestResult>();

                if (checkBoxNoModificate.Checked)
                    testResults.Add(ConductTest(checkBoxNoModificate.Text, delegate(Bitmap bitmap) { return bitmap; }));
                if (checkBoxDark.Checked)
                    testResults.Add(ConductTest(checkBoxDark.Text, delegate(Bitmap bitmap)
                    { return imageBrightness.ChangeBrightness(bitmap, 0.5f); }));
                if (checkBoxLight.Checked)
                    testResults.Add(ConductTest(checkBoxLight.Text, delegate (Bitmap bitmap)
                    { return imageBrightness.ChangeBrightness(bitmap, 2.0f); }));
                if (checkBoxVeryDark.Checked)
                    testResults.Add(ConductTest(checkBoxVeryDark.Text, delegate (Bitmap bitmap)
                    { return imageBrightness.ChangeBrightness(bitmap, 0.05f); }));
                if (checkBoxVeryLight.Checked)
                    testResults.Add(ConductTest(checkBoxVeryLight.Text, delegate (Bitmap bitmap)
                    { return imageBrightness.ChangeBrightness(bitmap, 5.0f); }));

                if (testResults.Count != 0)
                {
                    HystogramsForm hystogramsForm = new HystogramsForm(testResults);
                    hystogramsForm.Show();
                }
                else
                    MessageBox.Show("Samples no selected");
            }
            else
                MessageBox.Show("Data is empty");
        }
        RecognizeTestResult ConductTest(string nameOfTest,Func<Bitmap,Bitmap> Filter)
        {
            var results = new RecognizeTestResult(nameOfTest);
            List<Image<Bgr,byte>> imagesWithFilter = imagesBeforeFilters
                .Select(x => new Image<Bgr, Byte>(Filter(x.Bitmap)))
                .ToList();
            var eigenList = RecognizeFaces(RecognizerType.Eigen, imagesWithFilter);
            var fisherList = RecognizeFaces(RecognizerType.Fisher, imagesWithFilter);
            var lbphList = RecognizeFaces(RecognizerType.LBPH, imagesWithFilter);
            results.Eigen = getRatio(eigenList);
            results.Fisher = getRatio(fisherList);
            results.LBPH = getRatio(lbphList);
            results.eigenList = eigenList;
            results.fisherList = fisherList;
            results.lbphList = lbphList;
            return results;
        }
        List<FaceInfo> RecognizeFaces(string type,List<Image<Bgr, byte>> imagesWithFilter)
        {
            classifierRecognize.trainParameters.RecognizerType = type;
            classifierRecognize.Retrain();

            return imagesWithFilter
                .Select(x => classifierRecognize.Recognise(x.Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)))
                .ToList();
        }
        double getRatio(List<FaceInfo> list)
        {
            return list.Where(x => x.Label.CompareTo("Unknown") != 0)
                .Count() / (double)list.Count;
        }
        private void SaveImage_Click(object sender, EventArgs e)
        {
            amountFacesToAcquire = Convert.ToInt32(textBoxAmountRecord.Text);
            IsReadyFaces = false;

            if (Record)
                Record = false;
            else
                if (imagesBeforeFilters.Count == amountFacesToAcquire)
                imagesBeforeFilters.Clear();
            Record = true;
        }
    }
}
