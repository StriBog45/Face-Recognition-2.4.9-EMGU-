using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Face_Recognition
{
    public partial class HystogramsForm : Form
    {
        List<RecognizeTestResult> recognizeTestResults;
        ListViewItem[] CreateListOfListView(List<FaceInfo> resultList)
        {
            var itemsRecognition = new List<ListViewItem>();
            foreach(var faceInfo in resultList)
            {
                ListViewItem item = new ListViewItem((itemsRecognition.Count + 1).ToString());
                item.SubItems.Add(faceInfo.Label);
                item.SubItems.Add(faceInfo.Distance);
                itemsRecognition.Add(item);
            }
            return itemsRecognition.ToArray();
        }
        public HystogramsForm(List<RecognizeTestResult> recognizeTestResults)
        {
            this.recognizeTestResults = recognizeTestResults;
            InitializeComponent();
        }

        private void HystogramsForm_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            foreach(var recResult in recognizeTestResults)
            {
                var page = new TabPage(recResult.NameOfTest);
                var chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
                var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                chartArea.Axes[1].Title = "% recognized";
                chartArea.Axes[1].ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
                var series = new System.Windows.Forms.DataVisualization.Charting.Series();
                page.Size = new Size(tabControl1.Size.Width-8, tabControl1.Height-94);

                series.Name = recResult.NameOfTest;
                series.Points.Add(recResult.Eigen);
                series.Points.Add(recResult.Fisher);
                series.Points.Add(recResult.LBPH);
                series.Points[0].Label = RecognizerType.Eigen;
                series.Points[1].Label = RecognizerType.Fisher;
                series.Points[2].Label = RecognizerType.LBPH;

                chart.ChartAreas.Add(chartArea);
                chart.Series.Add(series);
                chart.Location = new Point(7, 7);
                chart.Size = new Size(571, 257);

                #region ListViews Settings
                var listViewEigen = new ListView();
                var listViewFisher = new ListView();
                var listViewLBPH = new ListView();


                var columnHeader1 = new ColumnHeader();
                var columnHeader2 = new ColumnHeader();
                var columnHeader3 = new ColumnHeader();
                var columnHeader4 = new ColumnHeader();
                var columnHeader5 = new ColumnHeader();
                var columnHeader6 = new ColumnHeader();
                var columnHeader7 = new ColumnHeader();
                var columnHeader8 = new ColumnHeader();
                var columnHeader9 = new ColumnHeader();
                columnHeader1.Text = "Iter";
                columnHeader1.Width = 30;
                columnHeader2.Text = "Name";
                columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                columnHeader2.Width = 60;
                columnHeader3.Text = "Distance";
                columnHeader4.Text = "Iter";
                columnHeader4.Width = 30;
                columnHeader5.Text = "Name";
                columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                columnHeader5.Width = 60;
                columnHeader6.Text = "Distance";
                columnHeader7.Text = "Iter";
                columnHeader7.Width = 30;
                columnHeader8.Text = "Name";
                columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                columnHeader8.Width = 60;
                columnHeader9.Text = "Distance";

                listViewEigen.Columns.AddRange(new ColumnHeader[] {
                    columnHeader1,
                    columnHeader2,
                    columnHeader3 });
                listViewEigen.Location = new Point(7, 270);
                listViewEigen.Name = "listView1";
                listViewEigen.Size = new Size(121, 109);
                listViewEigen.TabIndex = 1;
                listViewEigen.UseCompatibleStateImageBehavior = false;
                listViewEigen.View = View.Details;
                listViewEigen.LabelEdit = true;
                listViewEigen.FullRowSelect = true;
                listViewEigen.GridLines = true;

                listViewFisher.Columns.AddRange(new ColumnHeader[] {
                    columnHeader4,
                    columnHeader5,
                    columnHeader6 });
                listViewFisher.Location = new System.Drawing.Point(134, 270);
                listViewFisher.Name = "listView2";
                listViewFisher.Size = new System.Drawing.Size(121, 109);
                listViewFisher.TabIndex = 1;
                listViewFisher.UseCompatibleStateImageBehavior = false;
                listViewFisher.View = View.Details;
                listViewFisher.LabelEdit = true;
                listViewFisher.FullRowSelect = true;
                listViewFisher.GridLines = true;

                listViewLBPH.Columns.Clear();
                listViewLBPH.Columns.AddRange(new ColumnHeader[] {
                    columnHeader7,
                    columnHeader8,
                    columnHeader9 });
                listViewLBPH.Location = new System.Drawing.Point(261, 270);
                listViewLBPH.Name = "listView3";
                listViewLBPH.Size = new System.Drawing.Size(121, 109);
                listViewLBPH.TabIndex = 1;
                listViewLBPH.UseCompatibleStateImageBehavior = false;
                listViewLBPH.View = View.Details;
                listViewLBPH.LabelEdit = true;
                listViewLBPH.FullRowSelect = true;
                listViewLBPH.GridLines = true;
                
                #endregion

                listViewEigen.Items.AddRange(CreateListOfListView(recResult.eigenList));
                listViewFisher.Items.AddRange(CreateListOfListView(recResult.fisherList));
                listViewLBPH.Items.AddRange(CreateListOfListView(recResult.lbphList));

                page.Controls.Add(chart);
                page.Controls.Add(listViewEigen);
                page.Controls.Add(listViewFisher);
                page.Controls.Add(listViewLBPH);
                tabControl1.TabPages.Add(page);
            }
        }
    }
}
