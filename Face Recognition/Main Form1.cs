using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Face_Recognition
{
    public partial class Form1 : Form
    {
        #region variables
        Image<Bgr, Byte> currentFrame; //current image aquired from webcam for display
        Image<Gray, byte> result; //used to store the result image
        Image<Gray, byte> gray_frame = null; //grayscale current image aquired from webcam for processing

        Capture grabber; //This is our capture variable

        //Our face detection method
        public static string FRONTALFACE = "/Cascades/haarcascade_frontalface_default.xml";
        public CascadeClassifier Face = new CascadeClassifier(Application.StartupPath + FRONTALFACE); 

        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5); //Our fount for writing within the frame

        float brightness;
        ImageBrightness imageBrightness = new ImageBrightness();

        //Classifier with default training location
        Classifier_Train classifierRecognize;
        public TrainParameters trainParameters;

        public bool recordingUnlimited = false;
        public bool recordingLimited = false;
        public bool needRetrain = false;
        public int amountRecord = 0;
        List<ListViewItem> itemsRecognition;
        #endregion
        public Form1()
        {
            InitializeComponent();

            //Load of previus trainned faces and labels for each image
            itemsRecognition = new List<ListViewItem>();
            classifierRecognize = new Classifier_Train();

            trainParameters = new TrainParameters();
            if (classifierRecognize.IsTrained)
            {
                message_bar.Text = "Training Data loaded";
            }
            else
            {
                message_bar.Text = "No training data found, please train program using Train menu option";
            }
            Initialise_capture();
            
        }

        public void AddRecognition(string result)
        {
            if (recordingUnlimited || recordingLimited)
            {
                if (recordingLimited)
                    amountRecord--;

                ListViewItem item = new ListViewItem((itemsRecognition.Count+1).ToString());
                item.SubItems.Add(result);
                itemsRecognition.Add(item);

                if (amountRecord <= 0)
                {
                    recordingLimited = false;
                    RecordRecognizedResults();
                }
            }
        }
        public void RecordRecognizedResults()
        {
            ListViewItem[] rangeItems = new ListViewItem[itemsRecognition.Count];
            for (int i = 0; i < itemsRecognition.Count; i++)
                rangeItems[i] = itemsRecognition[i];
            listViewRecognition.Items.AddRange(rangeItems);
            CalculateAccuracyRecognition();
        }
        public void CalculateAccuracyRecognition()
        {
            int amountRecognized = 0;
            foreach (var item in itemsRecognition)
                if (String.Compare(item.SubItems[1].Text,"Uknown") < 0)
                    amountRecognized++;
            string result = (Math.Round(((double)amountRecognized / itemsRecognition.Count),2)).ToString();
            labelResult.Text = string.Format("Result: {0} AmountElements: {1} AmountRecognized: {2}",result,itemsRecognition.Count,amountRecognized);
        }

        //Open training form and pass this
        private void trainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stop Camera
            Stop_capture();

            //OpenForm
            Training_Form TF = new Training_Form(this);
            TF.Show();
        }
        public void Retrain()
        {

            classifierRecognize = new Classifier_Train();
            if (classifierRecognize.IsTrained)
            {
                message_bar.Text = "Training Data loaded";
            }
            else
            {
                message_bar.Text = "No training data found, please train program using Train menu option";
            }
        }

        //Camera
        public void Initialise_capture()
        {
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber_Parrellel);
        }
        private void Stop_capture()
        {
            Application.Idle -= new EventHandler(FrameGrabber_Parrellel);
            if(grabber!= null)
                grabber.Dispose();
        }
        void FaceApproximate(ref Rectangle rect)
        {
            rect.X += (int)(rect.Height * 0.15);
            rect.Y += (int)(rect.Width * 0.22);
            rect.Height -= (int)(rect.Height * 0.3);
            rect.Width -= (int)(rect.Width * 0.35);
        }

        //Process Frame
        void FrameGrabber_Parrellel(object sender, EventArgs e)
        {
            if (needRetrain)
                classifierRecognize.Retrain(trainParameters);
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            //Clear_Faces_Found();
            if(radioButtonBrightess.Checked)
            currentFrame = 
                new Image<Bgr, Byte>(imageBrightness.ChangeBrightness(currentFrame.ToBitmap(), brightness));

            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();
                //Face Detector
                Rectangle[] facesDetected = Face.DetectMultiScale(gray_frame, 1.2, 10, new Size(50, 50), Size.Empty);

                //Action for each element detected
                Parallel.For(0, facesDetected.Length, i =>
                    {
                        try
                        {
                            if(checkBoxFaceApproximate.Checked)
                                FaceApproximate(ref facesDetected[i]);

                            result = currentFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                            result._EqualizeHist();
                            //draw the face detected in the 0th (gray) channel with blue color
                            currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                            if (classifierRecognize.IsTrained)
                            {
                                FaceInfo name = classifierRecognize.Recognise(result);
                                int match_value = (int)classifierRecognize.Get_Eigen_Distance;

                                //Draw the label for each face detected and recognized
                                currentFrame.Draw(name.Label + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.LightGreen));
                                currentFrame.Draw(name.Distance + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Bottom + 10), new Bgr(Color.LightGreen));
                                ADD_Face_Found(result, name.Label, match_value);
                            }
                            
                        }
                        catch
                        {
                            //do nothing as parrellel loop buggy
                            //No action as the error is useless, it is simply an error in 
                            //no data being there to process and this occurss sporadically 
                        }
                    });
                //Show the faces procesed and recognized
                image_PICBX.Image = currentFrame.ToBitmap();
            }
        }

        //ADD Picture box and label to a panel for each face
        int faces_count = 0;
        int faces_panel_Y = 0;
        int faces_panel_X = 0;

        void Clear_Faces_Found()
        {
            this.Faces_Found_Panel.Controls.Clear();
            faces_count = 0;
            faces_panel_Y = 0;
            faces_panel_X = 0;
        }
        void ADD_Face_Found(Image<Gray, Byte> img_found, string name_person, int match_value)
        {
            PictureBox PI = new PictureBox();
            PI.Location = new Point(faces_panel_X, faces_panel_Y);
            PI.Height = 80;
            PI.Width = 80;
            PI.SizeMode = PictureBoxSizeMode.StretchImage;
            PI.Image = img_found.ToBitmap();
            Label LB = new Label();
            LB.Text = name_person + " " + match_value.ToString();
            LB.Location = new Point(faces_panel_X, faces_panel_Y + 80);
            //LB.Width = 80;
            LB.Height = 15;
           
            this.Faces_Found_Panel.Controls.Add(PI);
            this.Faces_Found_Panel.Controls.Add(LB);
            faces_count++;
            if (faces_count == 2)
            {
                faces_panel_X = 0;
                faces_panel_Y += 100;
                faces_count = 0;
            }
            else faces_panel_X += 85;

            if (Faces_Found_Panel.Controls.Count > 10)
            {
                Clear_Faces_Found();
            }
            AddRecognition(name_person);
        }

        void IsLBPHFaceRecognizer(bool answer)
        {
            labelRadius.Visible = answer;
            labelNeighbors.Visible = answer;
            labelGridX.Visible = answer;
            labelGridY.Visible = answer;
            textBoxRadius.Visible = answer;
            textBoxNeighbors.Visible = answer;
            textBoxGridX.Visible = answer;
            textBoxGridY.Visible = answer;
            labelComponents.Visible = !answer;
            textBoxComponents.Visible = !answer;
        }

        //Menu Opeartions
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SF = new SaveFileDialog();
            //As there is no identification in files to recogniser type we will set the extension ofthe file to tell us
            switch (classifierRecognize.trainParameters.RecognizerType)
            {
                case ("EMGU.CV.LBPHFaceRecognizer"):
                    SF.Filter = "LBPHFaceRecognizer File (*.LBPH)|*.LBPH";
                    break;
                case ("EMGU.CV.FisherFaceRecognizer"):
                    SF.Filter = "FisherFaceRecognizer File (*.FFR)|*.FFR";
                    break;
                case ("EMGU.CV.EigenFaceRecognizer"):
                    SF.Filter = "EigenFaceRecognizer File (*.EFR)|*.EFR";
                    break;
            }
            if (SF.ShowDialog() == DialogResult.OK)
            {
                classifierRecognize.Save_Eigen_Recogniser(SF.FileName);
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OF = new OpenFileDialog();
            OF.Filter = "EigenFaceRecognizer File (*.EFR)|*.EFR|LBPHFaceRecognizer File (*.LBPH)|*.LBPH|FisherFaceRecognizer File (*.FFR)|*.FFR";
            if (OF.ShowDialog() == DialogResult.OK)
            {
                classifierRecognize.Load_Eigen_Recogniser(OF.FileName);
            }
        }
        private void testRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestRoom testRoom = new TestRoom(this);
            testRoom.Show();
        }
        private void eigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncheck other menu items
            fisherToolStripMenuItem.Checked = false;
            lBPHToolStripMenuItem.Checked = false;

            classifierRecognize.trainParameters.RecognizerType = RecognizerType.Eigen;
            classifierRecognize.Retrain();

            IsLBPHFaceRecognizer(false);
        }
        private void fisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncheck other menu items
            lBPHToolStripMenuItem.Checked = false;
            eigenToolStripMenuItem.Checked = false;

            classifierRecognize.trainParameters.RecognizerType = RecognizerType.Fisher;
            classifierRecognize.Retrain();

            IsLBPHFaceRecognizer(false);
        }
        private void lBPHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncheck other menu items
            fisherToolStripMenuItem.Checked = false;
            eigenToolStripMenuItem.Checked = false;

            classifierRecognize.trainParameters.RecognizerType = RecognizerType.LBPH;
            classifierRecognize.Retrain();

            IsLBPHFaceRecognizer(true);
        }
        

        private void MainForm_Load(object sender, EventArgs e)
        {

            #region ListView Settings
            // Set the view to show details.
            listViewRecognition.View = View.Details;
            // Allow the user to edit item text.
            listViewRecognition.LabelEdit = true;
            // Select the item and subitems when selection is made.
            listViewRecognition.FullRowSelect = true;
            // Display grid lines.
            listViewRecognition.GridLines = true;
            #endregion

            brightness = (float)Convert.ToDouble(textBoxBrightess.Text);

            IsLBPHFaceRecognizer(false);
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            recordingUnlimited = true;
            listViewRecognition.Items.Clear();
            itemsRecognition.Clear();
        }
        private void stopRecordButton_Click(object sender, EventArgs e)
        {
            if (recordingUnlimited)
            {
                RecordRecognizedResults();
                recordingUnlimited = false;
            }
        }
        private void buttonRecordAmount_Click(object sender, EventArgs e)
        {
            recordingLimited = true;
            amountRecord = Convert.ToInt32(textBoxRecordAmount.Text);
        }

        private void textBoxComponents_TextChanged(object sender, EventArgs e)
        {
            try
            {
                classifierRecognize.trainParameters.Eigen.Components = Math.Abs(Convert.ToInt32(textBoxComponents.Text));
                classifierRecognize.trainParameters.Fisher.Components = Math.Abs(Convert.ToInt32(textBoxComponents.Text));
                classifierRecognize.Retrain();
                message_bar.Text = classifierRecognize.trainParameters.RecognizerType;
            }
            catch
            {
                message_bar.Text = "Error in Components input please use int";
            }
        }
        private void textBoxRadius_TextChanged(object sender, EventArgs e)
        {
            try
            {
                classifierRecognize.trainParameters.LBPH.Radius = Math.Abs(Convert.ToInt32(textBoxRadius.Text));
                classifierRecognize.Retrain();
                message_bar.Text = classifierRecognize.trainParameters.RecognizerType;
            }
            catch
            {
                message_bar.Text = "Error in Radius input please use int";
            }
        }
        private void textBoxNeighbors_TextChanged(object sender, EventArgs e)
        {
            try
            {
                classifierRecognize.trainParameters.LBPH.Neighbors = Math.Abs(Convert.ToInt32(textBoxNeighbors.Text));
                classifierRecognize.Retrain();
                message_bar.Text = classifierRecognize.trainParameters.RecognizerType;
            }
            catch
            {
                message_bar.Text = "Error in Neighbors input please use int";
            }
        }
        private void textBoxGridX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                classifierRecognize.trainParameters.LBPH.GridX = Math.Abs(Convert.ToInt32(textBoxGridX.Text));
                classifierRecognize.Retrain();
                message_bar.Text = classifierRecognize.trainParameters.RecognizerType;
            }
            catch
            {
                message_bar.Text = "Error in GridX input please use int";
            }
        }
        private void textBoxGridY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                classifierRecognize.trainParameters.LBPH.GridY = Math.Abs(Convert.ToInt32(textBoxGridY.Text));
                classifierRecognize.Retrain();
                message_bar.Text = classifierRecognize.trainParameters.RecognizerType;
            }
            catch
            {
                message_bar.Text = "Error in GridY input please use int";
            }
        }
        private void textBoxTreshold_TextChanged(object sender, EventArgs e)
        {
            try
            {
                classifierRecognize.Set_Eigen_Threshold = Math.Abs(Convert.ToInt32(textBoxTreshold.Text));
                classifierRecognize.trainParameters.Eigen.Treshold = Math.Abs(Convert.ToDouble(textBoxTreshold.Text));
                classifierRecognize.trainParameters.Fisher.Treshold = Math.Abs(Convert.ToDouble(textBoxTreshold.Text));
                classifierRecognize.trainParameters.LBPH.Treshold = Math.Abs(Convert.ToDouble(textBoxTreshold.Text));
                classifierRecognize.Retrain();

                message_bar.Text = classifierRecognize.trainParameters.RecognizerType;
            }
            catch
            {
                message_bar.Text = "Error in Threshold input please use int";
            }
        }
        private void textBoxBrightess_TextChanged(object sender, EventArgs e)
        {
            try
            {
                brightness = (float)Convert.ToDouble(textBoxBrightess.Text);
            }
            catch
            {
                message_bar.Text = "Error in Birhtness input please use float";
            }
        }
    }
}
