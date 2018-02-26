using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing.Imaging;
using System.Drawing;
using Face_Recognition;

/// <summary>
/// Desingned to remove the training a EigenObjectRecognizer code from the main form
/// </summary>
class Classifier_Train: IDisposable
{

    #region Variables

    //Eigen
    //EigenObjectRecognizer recognizer;
    FaceRecognizer recognizer;

    //training variables
    List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();//Images
    //TODO: see if this can be combined in Ditionary format this will remove support for old data
    List<string> Names_List = new List<string>(); //labels
    List<int> Names_List_ID = new List<int>();
    public TrainParameters trainParameters;
    int contTrain, numLabels;
    float eigen_Distance = 0;
    string eigen_label;
    int eigen_threshold = 2000;
    static string DIRECTORYDATABASE = "\\TrainedFaces";
    static string LABELSXML = "/Labels.xml";
    static string TRAINEDLABELS = "\\TrainedLabels.xml";

    //Class Variables
    string Error;
    bool _IsTrained = false;
    #endregion

    #region Constructors
    /// <summary>
    /// Default Constructor, Looks in (Application.StartupPath + DIRECTORYDATABASE) for traing data.
    /// </summary>
    public Classifier_Train()
    {
        trainParameters = new TrainParameters();
        trainParameters.RecognizerType = "EMGU.CV.EigenFaceRecognizer";
        trainParameters.Eigen.Components = 80;
        trainParameters.Eigen.Treshold = 2500;
        trainParameters.Fisher.Treshold = 2500;
        trainParameters.Fisher.Components = 0;
        trainParameters.LBPH.Treshold = 2500;
        trainParameters.LBPH.Neighbors = 8;
        trainParameters.LBPH.Radius = 1;
        trainParameters.LBPH.GridX = 8;
        trainParameters.LBPH.GridY = 8;
        _IsTrained = LoadTrainingData(Application.StartupPath + DIRECTORYDATABASE);
    }
    public Classifier_Train(TrainParameters trainParameters)
    {
        if (string.IsNullOrEmpty(trainParameters.RecognizerType))
            trainParameters.RecognizerType = RecognizerType.Eigen;
        this.trainParameters = trainParameters;
        _IsTrained = LoadTrainingData(Application.StartupPath + DIRECTORYDATABASE);
    }
    public Classifier_Train(LBPHData lBPHData)
    {
        trainParameters.LBPH = lBPHData;
        _IsTrained = LoadTrainingData(Application.StartupPath + DIRECTORYDATABASE);
    }
    public Classifier_Train(FisherData fisherData)
    {
        trainParameters.Fisher = fisherData;
        _IsTrained = LoadTrainingData(Application.StartupPath + DIRECTORYDATABASE);
    }
    public Classifier_Train(EigenData eigenData)
    {
        trainParameters.Eigen = eigenData;
        _IsTrained = LoadTrainingData(Application.StartupPath + DIRECTORYDATABASE);
    }
    //public Classifier_Train(
    //    int treshold,
    //    int components,
    //    int neighbors,
    //    int radius,
    //    int gridX,
    //    int gridY)
    //{
    //    UserTreshold = treshold;
    //    Components = components;
    //    Neighbors = neighbors;
    //    Radius = radius;
    //    GridX = gridX;
    //    GridY = gridY;

    //    _IsTrained = LoadTrainingData(Application.StartupPath + DIRECTORYDATABASE);
    //}
    /// <summary>
    /// Takes String input to a different location for training data
    /// </summary>
    /// <param name="Training_Folder"></param>
    //public Classifier_Train(
    //    string training_Folder,
    //    int treshold,
    //    int components,
    //    int neighbors,
    //    int radius,
    //    int gridX,
    //    int gridY)
    //{
    //    UserTreshold = treshold;
    //    Components = components;
    //    Neighbors = neighbors;
    //    Radius = radius;
    //    GridX = gridX;
    //    GridY = gridY;
        
    //    _IsTrained = LoadTrainingData(training_Folder);
    //}
    #endregion

    #region Public
    /// <summary>
    /// Retrains the recognizer witout resetting variables like recognizer type.
    /// </summary>
    /// <returns></returns>
    public bool Retrain()
    {
        return _IsTrained = LoadTrainingData(Application.StartupPath + DIRECTORYDATABASE);
    }
    public bool Retrain(TrainParameters train)
    {
        trainParameters = train;
        return _IsTrained = LoadTrainingData(Application.StartupPath + DIRECTORYDATABASE);
    }
    /// <summary>
    /// Retrains the recognizer witout resetting variables like recognizer type.
    /// Takes String input to a different location for training data.
    /// </summary>
    /// <returns></returns>
    public bool Retrain(string Training_Folder)
    {
        return _IsTrained = LoadTrainingData(Training_Folder);
    }

    /// <summary>
    /// <para>Return(True): If Training data has been located and Eigen Recogniser has been trained</para>
    /// <para>Return(False): If NO Training data has been located of error in training has occured</para>
    /// </summary>
    public bool IsTrained
    {
        get { return _IsTrained; }
    }

    /// <summary>
    /// Recognise a Grayscale Image using the trained Eigen Recogniser
    /// </summary>
    /// <param name="Input_image"></param>
    /// <returns></returns>
    public FaceInfo Recognise(Image<Gray, byte> Input_image)
    {
        if (_IsTrained)
        {
            FaceRecognizer.PredictionResult ER = recognizer.Predict(Input_image);

            if (ER.Label == -1)
            {
                eigen_label = "Unknown";
                eigen_Distance = 0;
                return new FaceInfo(eigen_label,Get_Eigen_Distance);
            }
            else
            {
                eigen_label = Names_List[ER.Label];
                eigen_Distance = (float)ER.Distance;

                //Only use the post threshold rule if we are using an Eigen Recognizer 
                //since Fisher and LBHP threshold set during the constructor will work correctly 
                switch (trainParameters.RecognizerType)
                {
                    case ("EMGU.CV.EigenFaceRecognizer"):
                        //if (Eigen_Distance > Eigen_threshold) return new FaceInfo(Eigen_label,ER.Distance);
                        //else return new FaceInfo("Unknown", ER.Distance);
                        return new FaceInfo(eigen_label, ER.Distance);
                    case ("EMGU.CV.LBPHFaceRecognizer"):
                        return new FaceInfo(eigen_label, ER.Distance);
                    case ("EMGU.CV.FisherFaceRecognizer"):
                        return new FaceInfo(eigen_label, ER.Distance);
                    default:
                        return new FaceInfo(eigen_label, ER.Distance); //the threshold set in training controls unknowns
                }




            }

        }
        else return new FaceInfo("", "");
    }

    /// <summary>
    /// Sets the threshold confidence value for string Recognise(Image<Gray, byte> Input_image) to be used.
    /// </summary>
    public int Set_Eigen_Threshold
    {
        set
        {
            //NOTE: This is still not working correctley 
            //recognizer.EigenDistanceThreshold = value;
            eigen_threshold = value;
        }
    }

    /// <summary>
    /// Returns a string containg the recognised persons name
    /// </summary>
    public string Get_Eigen_Label
    {
        get
        {
            return eigen_label;
        }
    }

    /// <summary>
    /// Returns a float confidence value for potential false clasifications
    /// </summary>
    public float Get_Eigen_Distance
    {
        get
        {
            //get eigenDistance
            return eigen_Distance;
        }
    }

    /// <summary>
    /// Returns a string contatining any error that has occured
    /// </summary>
    public string Get_Error
    {
        get { return Error; }
    }

    /// <summary>
    /// Saves the trained Eigen Recogniser to specified location
    /// </summary>
    /// <param name="filename"></param>
    public void Save_Eigen_Recogniser(string filename)
    {
        recognizer.Save(filename);

        //save label data as this isn't saved with the network
        string direct = Path.GetDirectoryName(filename);
        FileStream Label_Data = File.OpenWrite(direct + LABELSXML);
        using (XmlWriter writer = XmlWriter.Create(Label_Data))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Labels_For_Recognizer_sequential");
            for (int i = 0; i < Names_List.Count; i++)
            {
                writer.WriteStartElement("LABEL");
                writer.WriteElementString("POS", i.ToString());
                writer.WriteElementString("NAME", Names_List[i]);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
        Label_Data.Close();
    }

    /// <summary>
    /// Loads the trained Eigen Recogniser from specified location
    /// </summary>
    /// <param name="filename"></param>
    public void Load_Eigen_Recogniser(string filename)
    {
        //Lets get the recogniser type from the file extension
        string ext = Path.GetExtension(filename);
        switch (ext)
        {
            case (".LBPH"):
                trainParameters.RecognizerType = "EMGU.CV.LBPHFaceRecognizer";
                recognizer = new LBPHFaceRecognizer(
                    trainParameters.LBPH.Radius, 
                    trainParameters.LBPH.Neighbors, 
                    trainParameters.LBPH.GridX, 
                    trainParameters.LBPH.GridY,
                    trainParameters.LBPH.Treshold); // 1,8,8,8,100
                break;
            case (".FFR"):
                trainParameters.RecognizerType = "EMGU.CV.FisherFaceRecognizer";
                recognizer = new FisherFaceRecognizer(
                    trainParameters.Fisher.Components, 
                    trainParameters.Fisher.Treshold); // 0,3500
                break;
            case (".EFR"):
                trainParameters.RecognizerType = "EMGU.CV.EigenFaceRecognizer";
                recognizer = new EigenFaceRecognizer(
                    trainParameters.Eigen.Components, 
                    trainParameters.Eigen.Treshold); // 80,double.PositiveInfinity
                break;
        }

        //introduce error checking
        recognizer.Load(filename);

        //Now load the labels
        string direct = Path.GetDirectoryName(filename);
        Names_List.Clear();
        if (File.Exists(direct + LABELSXML))
        {
            FileStream filestream = File.OpenRead(direct + LABELSXML);
            long filelength = filestream.Length;
            byte[] xmlBytes = new byte[filelength];
            filestream.Read(xmlBytes, 0, (int)filelength);
            filestream.Close();

            MemoryStream xmlStream = new MemoryStream(xmlBytes);

            using (XmlReader xmlreader = XmlTextReader.Create(xmlStream))
            {
                while (xmlreader.Read())
                {
                    if (xmlreader.IsStartElement())
                    {
                        switch (xmlreader.Name)
                        {
                            case "NAME":
                                if (xmlreader.Read())
                                {
                                    Names_List.Add(xmlreader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }
            contTrain = numLabels;
        }
        _IsTrained = true;

    }

        /// <summary>
    /// Dispose of Class call Garbage Collector
    /// </summary>
    public void Dispose()
    {
        recognizer = null;
        trainingImages = null;
        Names_List = null;
        Error = null;
        GC.Collect();
    }

    #endregion

    #region Private
    /// <summary>
    /// Loads the traing data given a (string) folder location
    /// </summary>
    /// <param name="Folder_location"></param>
    /// <returns></returns>
    /// 
    private void ChooseFaceRecognizer()
    {
        switch (trainParameters.RecognizerType)
        {
            case ("EMGU.CV.LBPHFaceRecognizer"):
                recognizer = new LBPHFaceRecognizer(trainParameters.LBPH.Radius, 
                    trainParameters.LBPH.Neighbors, 
                    trainParameters.LBPH.GridX, 
                    trainParameters.LBPH.GridY, 
                    trainParameters.LBPH.Treshold); //было(1, 8, 8, 8, 100)
                break;
            case ("EMGU.CV.FisherFaceRecognizer"):
                recognizer = new FisherFaceRecognizer(
                    trainParameters.Fisher.Components, 
                    trainParameters.Fisher.Treshold); //было (0, 3500)
                break;
            case ("EMGU.CV.EigenFaceRecognizer"):
            default:
                recognizer = new EigenFaceRecognizer(
                    trainParameters.Eigen.Components, 
                    trainParameters.Eigen.Treshold); //было (80, double.PositiveInfinity)
                break;
        }
    }

    private bool LoadTrainingData(string Folder_location)
    {
        if (File.Exists(Folder_location +TRAINEDLABELS))
        {
            try
            {
                Names_List.Clear();
                Names_List_ID.Clear();
                trainingImages.Clear();
                FileStream filestream = File.OpenRead(Folder_location + TRAINEDLABELS);
                long filelength = filestream.Length;
                byte[] xmlBytes = new byte[filelength];
                filestream.Read(xmlBytes, 0, (int)filelength);
                filestream.Close();

                MemoryStream xmlStream = new MemoryStream(xmlBytes);

                using (XmlReader xmlreader = XmlTextReader.Create(xmlStream))
                {
                    while (xmlreader.Read())
                    {
                        if (xmlreader.IsStartElement())
                        {
                            switch (xmlreader.Name)
                            {
                                case "NAME":
                                    if (xmlreader.Read())
                                    {
                                        Names_List_ID.Add(Names_List.Count);
                                        Names_List.Add(xmlreader.Value.Trim());
                                        numLabels += 1;
                                    }
                                    break;
                                case "FILE":
                                    if (xmlreader.Read())
                                    {
                                        trainingImages.Add(new Image<Gray, byte>(
                                            Application.StartupPath + DIRECTORYDATABASE + "\\" + xmlreader.Value.Trim()));
                                    }
                                    break;
                            }
                        }
                    }
                }
                contTrain = numLabels;

                if (trainingImages.ToArray().Length != 0)
                {

                    //Eigen face recognizer
                    //Parameters:	
                    //      num_components – The number of components (read: Eigenfaces) kept for this Prinicpal 
                    //          Component Analysis. As a hint: There’s no rule how many components (read: Eigenfaces) 
                    //          should be kept for good reconstruction capabilities. It is based on your input data, 
                    //          so experiment with the number. Keeping 80 components should almost always be sufficient.
                    //
                    //      threshold – The threshold applied in the prediciton. This still has issues as it work inversly to LBH and Fisher Methods.
                    //          if you use 0.0 recognizer.Predict will always return -1 or unknown if you use 5000 for example unknow won't be reconised.
                    //          As in previous versions I ignore the built in threhold methods and allow a match to be found i.e. double.PositiveInfinity
                    //          and then use the eigen distance threshold that is return to elliminate unknowns. 
                    //
                    //NOTE: The following causes the confusion, sinc two rules are used. 
                    //--------------------------------------------------------------------------------------------------------------------------------------
                    //Eigen Uses
                    //          0 - X = unknown
                    //          > X = Recognised
                    //
                    //Fisher and LBPH Use
                    //          0 - X = Recognised
                    //          > X = Unknown
                    //
                    // Where X = Threshold value


                    ChooseFaceRecognizer();

                    recognizer.Train(trainingImages.ToArray(), Names_List_ID.ToArray());

                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return false;
            }
        }
        else return false;
    }

    #endregion
}

