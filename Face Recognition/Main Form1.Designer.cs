namespace Face_Recognition
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eigneRecogniserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recogniserTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fisherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lBPHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.message_bar = new System.Windows.Forms.Label();
            this.image_PICBX = new System.Windows.Forms.PictureBox();
            this.Faces_Found_Panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewRecognition = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stopRecordButton = new System.Windows.Forms.Button();
            this.textBoxTreshold = new System.Windows.Forms.TextBox();
            this.labelTreshold = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelResult = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxRecordAmount = new System.Windows.Forms.TextBox();
            this.buttonRecordAmount = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxGridY = new System.Windows.Forms.TextBox();
            this.labelGridY = new System.Windows.Forms.Label();
            this.textBoxGridX = new System.Windows.Forms.TextBox();
            this.labelGridX = new System.Windows.Forms.Label();
            this.textBoxNeighbors = new System.Windows.Forms.TextBox();
            this.labelNeighbors = new System.Windows.Forms.Label();
            this.textBoxRadius = new System.Windows.Forms.TextBox();
            this.labelRadius = new System.Windows.Forms.Label();
            this.textBoxComponents = new System.Windows.Forms.TextBox();
            this.labelComponents = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxBrightess = new System.Windows.Forms.TextBox();
            this.radioButtonBrightess = new System.Windows.Forms.RadioButton();
            this.radioButtonStandart = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxFaceApproximate = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_PICBX)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.trainToolStripMenuItem,
            this.recogniserTypeToolStripMenuItem,
            this.testRoomToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eigneRecogniserToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // eigneRecogniserToolStripMenuItem
            // 
            this.eigneRecogniserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.eigneRecogniserToolStripMenuItem.Name = "eigneRecogniserToolStripMenuItem";
            this.eigneRecogniserToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.eigneRecogniserToolStripMenuItem.Text = "Recogniser";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // trainToolStripMenuItem
            // 
            this.trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            this.trainToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.trainToolStripMenuItem.Text = "&Train";
            this.trainToolStripMenuItem.Click += new System.EventHandler(this.trainToolStripMenuItem_Click);
            // 
            // recogniserTypeToolStripMenuItem
            // 
            this.recogniserTypeToolStripMenuItem.CheckOnClick = true;
            this.recogniserTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eigenToolStripMenuItem,
            this.fisherToolStripMenuItem,
            this.lBPHToolStripMenuItem});
            this.recogniserTypeToolStripMenuItem.Name = "recogniserTypeToolStripMenuItem";
            this.recogniserTypeToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.recogniserTypeToolStripMenuItem.Text = "Recogniser Type";
            // 
            // eigenToolStripMenuItem
            // 
            this.eigenToolStripMenuItem.Checked = true;
            this.eigenToolStripMenuItem.CheckOnClick = true;
            this.eigenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eigenToolStripMenuItem.Name = "eigenToolStripMenuItem";
            this.eigenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eigenToolStripMenuItem.Text = "Eigen";
            this.eigenToolStripMenuItem.Click += new System.EventHandler(this.eigenToolStripMenuItem_Click);
            // 
            // fisherToolStripMenuItem
            // 
            this.fisherToolStripMenuItem.CheckOnClick = true;
            this.fisherToolStripMenuItem.Name = "fisherToolStripMenuItem";
            this.fisherToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fisherToolStripMenuItem.Text = "Fisher";
            this.fisherToolStripMenuItem.Click += new System.EventHandler(this.fisherToolStripMenuItem_Click);
            // 
            // lBPHToolStripMenuItem
            // 
            this.lBPHToolStripMenuItem.CheckOnClick = true;
            this.lBPHToolStripMenuItem.Name = "lBPHToolStripMenuItem";
            this.lBPHToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lBPHToolStripMenuItem.Text = "LBPH";
            this.lBPHToolStripMenuItem.Click += new System.EventHandler(this.lBPHToolStripMenuItem_Click);
            // 
            // testRoomToolStripMenuItem
            // 
            this.testRoomToolStripMenuItem.Name = "testRoomToolStripMenuItem";
            this.testRoomToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.testRoomToolStripMenuItem.Text = "TestRoom";
            this.testRoomToolStripMenuItem.Click += new System.EventHandler(this.testRoomToolStripMenuItem_Click);
            // 
            // message_bar
            // 
            this.message_bar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.message_bar.AutoSize = true;
            this.message_bar.Location = new System.Drawing.Point(3, 0);
            this.message_bar.Name = "message_bar";
            this.message_bar.Size = new System.Drawing.Size(53, 13);
            this.message_bar.TabIndex = 1;
            this.message_bar.Text = "Message:";
            // 
            // image_PICBX
            // 
            this.image_PICBX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.image_PICBX.Location = new System.Drawing.Point(12, 27);
            this.image_PICBX.Name = "image_PICBX";
            this.image_PICBX.Size = new System.Drawing.Size(658, 421);
            this.image_PICBX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_PICBX.TabIndex = 2;
            this.image_PICBX.TabStop = false;
            // 
            // Faces_Found_Panel
            // 
            this.Faces_Found_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Faces_Found_Panel.AutoScroll = true;
            this.Faces_Found_Panel.Location = new System.Drawing.Point(3, 3);
            this.Faces_Found_Panel.Name = "Faces_Found_Panel";
            this.Faces_Found_Panel.Size = new System.Drawing.Size(194, 236);
            this.Faces_Found_Panel.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Faces_Found_Panel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(676, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.62754F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.37246F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 443);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // listViewRecognition
            // 
            this.listViewRecognition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewRecognition.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewRecognition.Location = new System.Drawing.Point(6, 66);
            this.listViewRecognition.Name = "listViewRecognition";
            this.listViewRecognition.Size = new System.Drawing.Size(181, 100);
            this.listViewRecognition.TabIndex = 4;
            this.listViewRecognition.UseCompatibleStateImageBehavior = false;
            this.listViewRecognition.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Iter";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 117;
            // 
            // stopRecordButton
            // 
            this.stopRecordButton.Location = new System.Drawing.Point(87, 37);
            this.stopRecordButton.Name = "stopRecordButton";
            this.stopRecordButton.Size = new System.Drawing.Size(75, 23);
            this.stopRecordButton.TabIndex = 3;
            this.stopRecordButton.Text = "Stop Record";
            this.stopRecordButton.UseVisualStyleBackColor = true;
            this.stopRecordButton.Click += new System.EventHandler(this.stopRecordButton_Click);
            // 
            // textBoxTreshold
            // 
            this.textBoxTreshold.Location = new System.Drawing.Point(98, 13);
            this.textBoxTreshold.Name = "textBoxTreshold";
            this.textBoxTreshold.Size = new System.Drawing.Size(75, 20);
            this.textBoxTreshold.TabIndex = 1;
            this.textBoxTreshold.Text = "2500";
            this.textBoxTreshold.TextChanged += new System.EventHandler(this.textBoxTreshold_TextChanged);
            // 
            // labelTreshold
            // 
            this.labelTreshold.AutoSize = true;
            this.labelTreshold.Location = new System.Drawing.Point(38, 16);
            this.labelTreshold.Name = "labelTreshold";
            this.labelTreshold.Size = new System.Drawing.Size(54, 13);
            this.labelTreshold.TabIndex = 0;
            this.labelTreshold.Text = "Theshold:";
            this.toolTip1.SetToolTip(this.labelTreshold, "The distance threshold");
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.message_bar);
            this.panel2.Location = new System.Drawing.Point(12, 454);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 16);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.labelResult);
            this.panel3.Location = new System.Drawing.Point(212, 454);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(345, 16);
            this.panel3.TabIndex = 5;
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(3, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(40, 13);
            this.labelResult.TabIndex = 1;
            this.labelResult.Text = "Result:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(676, 272);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 198);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.textBoxRecordAmount);
            this.tabPage1.Controls.Add(this.buttonRecordAmount);
            this.tabPage1.Controls.Add(this.listViewRecognition);
            this.tabPage1.Controls.Add(this.recordButton);
            this.tabPage1.Controls.Add(this.stopRecordButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 172);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Test";
            // 
            // textBoxRecordAmount
            // 
            this.textBoxRecordAmount.Location = new System.Drawing.Point(87, 10);
            this.textBoxRecordAmount.Name = "textBoxRecordAmount";
            this.textBoxRecordAmount.Size = new System.Drawing.Size(100, 20);
            this.textBoxRecordAmount.TabIndex = 6;
            this.textBoxRecordAmount.Text = "50";
            this.toolTip1.SetToolTip(this.textBoxRecordAmount, "amount frame record");
            // 
            // buttonRecordAmount
            // 
            this.buttonRecordAmount.Location = new System.Drawing.Point(6, 8);
            this.buttonRecordAmount.Name = "buttonRecordAmount";
            this.buttonRecordAmount.Size = new System.Drawing.Size(75, 23);
            this.buttonRecordAmount.TabIndex = 5;
            this.buttonRecordAmount.Text = "Record";
            this.toolTip1.SetToolTip(this.buttonRecordAmount, "Record N frame");
            this.buttonRecordAmount.UseVisualStyleBackColor = true;
            this.buttonRecordAmount.Click += new System.EventHandler(this.buttonRecordAmount_Click);
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(6, 37);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(75, 23);
            this.recordButton.TabIndex = 2;
            this.recordButton.Text = "Record";
            this.toolTip1.SetToolTip(this.recordButton, "Record Unlimited");
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.textBoxGridY);
            this.tabPage2.Controls.Add(this.labelGridY);
            this.tabPage2.Controls.Add(this.textBoxGridX);
            this.tabPage2.Controls.Add(this.labelGridX);
            this.tabPage2.Controls.Add(this.textBoxNeighbors);
            this.tabPage2.Controls.Add(this.labelNeighbors);
            this.tabPage2.Controls.Add(this.textBoxRadius);
            this.tabPage2.Controls.Add(this.labelRadius);
            this.tabPage2.Controls.Add(this.textBoxComponents);
            this.tabPage2.Controls.Add(this.labelComponents);
            this.tabPage2.Controls.Add(this.textBoxTreshold);
            this.tabPage2.Controls.Add(this.labelTreshold);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 172);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parameters";
            // 
            // textBoxGridY
            // 
            this.textBoxGridY.Location = new System.Drawing.Point(98, 143);
            this.textBoxGridY.Name = "textBoxGridY";
            this.textBoxGridY.Size = new System.Drawing.Size(75, 20);
            this.textBoxGridY.TabIndex = 1;
            this.textBoxGridY.Text = "8";
            this.textBoxGridY.TextChanged += new System.EventHandler(this.textBoxGridY_TextChanged);
            // 
            // labelGridY
            // 
            this.labelGridY.AutoSize = true;
            this.labelGridY.Location = new System.Drawing.Point(49, 146);
            this.labelGridY.Name = "labelGridY";
            this.labelGridY.Size = new System.Drawing.Size(36, 13);
            this.labelGridY.TabIndex = 0;
            this.labelGridY.Text = "GridY:";
            this.toolTip1.SetToolTip(this.labelGridY, "Grid Y");
            // 
            // textBoxGridX
            // 
            this.textBoxGridX.Location = new System.Drawing.Point(98, 117);
            this.textBoxGridX.Name = "textBoxGridX";
            this.textBoxGridX.Size = new System.Drawing.Size(75, 20);
            this.textBoxGridX.TabIndex = 1;
            this.textBoxGridX.Text = "8";
            this.textBoxGridX.TextChanged += new System.EventHandler(this.textBoxGridX_TextChanged);
            // 
            // labelGridX
            // 
            this.labelGridX.AutoSize = true;
            this.labelGridX.Location = new System.Drawing.Point(49, 120);
            this.labelGridX.Name = "labelGridX";
            this.labelGridX.Size = new System.Drawing.Size(36, 13);
            this.labelGridX.TabIndex = 0;
            this.labelGridX.Text = "GridX:";
            this.toolTip1.SetToolTip(this.labelGridX, "Grid X");
            // 
            // textBoxNeighbors
            // 
            this.textBoxNeighbors.Location = new System.Drawing.Point(98, 91);
            this.textBoxNeighbors.Name = "textBoxNeighbors";
            this.textBoxNeighbors.Size = new System.Drawing.Size(75, 20);
            this.textBoxNeighbors.TabIndex = 1;
            this.textBoxNeighbors.Text = "8";
            this.textBoxNeighbors.TextChanged += new System.EventHandler(this.textBoxNeighbors_TextChanged);
            // 
            // labelNeighbors
            // 
            this.labelNeighbors.AutoSize = true;
            this.labelNeighbors.Location = new System.Drawing.Point(34, 94);
            this.labelNeighbors.Name = "labelNeighbors";
            this.labelNeighbors.Size = new System.Drawing.Size(58, 13);
            this.labelNeighbors.TabIndex = 0;
            this.labelNeighbors.Text = "Neighbors:";
            this.toolTip1.SetToolTip(this.labelNeighbors, "Neighbors");
            // 
            // textBoxRadius
            // 
            this.textBoxRadius.Location = new System.Drawing.Point(98, 65);
            this.textBoxRadius.Name = "textBoxRadius";
            this.textBoxRadius.Size = new System.Drawing.Size(75, 20);
            this.textBoxRadius.TabIndex = 1;
            this.textBoxRadius.Text = "1";
            this.textBoxRadius.TextChanged += new System.EventHandler(this.textBoxRadius_TextChanged);
            // 
            // labelRadius
            // 
            this.labelRadius.AutoSize = true;
            this.labelRadius.Location = new System.Drawing.Point(49, 68);
            this.labelRadius.Name = "labelRadius";
            this.labelRadius.Size = new System.Drawing.Size(43, 13);
            this.labelRadius.TabIndex = 0;
            this.labelRadius.Text = "Radius:";
            this.toolTip1.SetToolTip(this.labelRadius, "Radius");
            // 
            // textBoxComponents
            // 
            this.textBoxComponents.Location = new System.Drawing.Point(98, 39);
            this.textBoxComponents.Name = "textBoxComponents";
            this.textBoxComponents.Size = new System.Drawing.Size(75, 20);
            this.textBoxComponents.TabIndex = 1;
            this.textBoxComponents.Text = "80";
            this.textBoxComponents.TextChanged += new System.EventHandler(this.textBoxComponents_TextChanged);
            // 
            // labelComponents
            // 
            this.labelComponents.AutoSize = true;
            this.labelComponents.Location = new System.Drawing.Point(23, 42);
            this.labelComponents.Name = "labelComponents";
            this.labelComponents.Size = new System.Drawing.Size(69, 13);
            this.labelComponents.TabIndex = 0;
            this.labelComponents.Text = "Components:";
            this.toolTip1.SetToolTip(this.labelComponents, "The number of components");
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.textBoxBrightess);
            this.tabPage3.Controls.Add(this.radioButtonBrightess);
            this.tabPage3.Controls.Add(this.radioButtonStandart);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(192, 172);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Camera";
            // 
            // textBoxBrightess
            // 
            this.textBoxBrightess.Location = new System.Drawing.Point(122, 44);
            this.textBoxBrightess.Name = "textBoxBrightess";
            this.textBoxBrightess.Size = new System.Drawing.Size(64, 20);
            this.textBoxBrightess.TabIndex = 2;
            this.textBoxBrightess.Text = "0,5";
            this.textBoxBrightess.TextChanged += new System.EventHandler(this.textBoxBrightess_TextChanged);
            // 
            // radioButtonBrightess
            // 
            this.radioButtonBrightess.AutoSize = true;
            this.radioButtonBrightess.Location = new System.Drawing.Point(6, 44);
            this.radioButtonBrightess.Name = "radioButtonBrightess";
            this.radioButtonBrightess.Size = new System.Drawing.Size(105, 17);
            this.radioButtonBrightess.TabIndex = 1;
            this.radioButtonBrightess.Text = "ChangeBrightess";
            this.radioButtonBrightess.UseVisualStyleBackColor = true;
            // 
            // radioButtonStandart
            // 
            this.radioButtonStandart.AutoSize = true;
            this.radioButtonStandart.Checked = true;
            this.radioButtonStandart.Location = new System.Drawing.Point(6, 21);
            this.radioButtonStandart.Name = "radioButtonStandart";
            this.radioButtonStandart.Size = new System.Drawing.Size(65, 17);
            this.radioButtonStandart.TabIndex = 0;
            this.radioButtonStandart.TabStop = true;
            this.radioButtonStandart.Text = "Standart";
            this.radioButtonStandart.UseVisualStyleBackColor = true;
            // 
            // checkBoxFaceApproximate
            // 
            this.checkBoxFaceApproximate.AutoSize = true;
            this.checkBoxFaceApproximate.Checked = true;
            this.checkBoxFaceApproximate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFaceApproximate.Location = new System.Drawing.Point(566, 454);
            this.checkBoxFaceApproximate.Name = "checkBoxFaceApproximate";
            this.checkBoxFaceApproximate.Size = new System.Drawing.Size(108, 17);
            this.checkBoxFaceApproximate.TabIndex = 7;
            this.checkBoxFaceApproximate.Text = "FaceApproximate";
            this.checkBoxFaceApproximate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 480);
            this.Controls.Add(this.checkBoxFaceApproximate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.image_PICBX);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "For Якименко А.А.";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_PICBX)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem;
        private System.Windows.Forms.Label message_bar;
        private System.Windows.Forms.PictureBox image_PICBX;
        private System.Windows.Forms.Panel Faces_Found_Panel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem eigneRecogniserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recogniserTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fisherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lBPHToolStripMenuItem;
        private System.Windows.Forms.ListView listViewRecognition;
        private System.Windows.Forms.Button stopRecordButton;
        private System.Windows.Forms.TextBox textBoxTreshold;
        private System.Windows.Forms.Label labelTreshold;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxNeighbors;
        private System.Windows.Forms.Label labelNeighbors;
        private System.Windows.Forms.TextBox textBoxRadius;
        private System.Windows.Forms.Label labelRadius;
        private System.Windows.Forms.TextBox textBoxComponents;
        private System.Windows.Forms.Label labelComponents;
        private System.Windows.Forms.TextBox textBoxGridY;
        private System.Windows.Forms.Label labelGridY;
        private System.Windows.Forms.TextBox textBoxGridX;
        private System.Windows.Forms.Label labelGridX;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxRecordAmount;
        private System.Windows.Forms.Button buttonRecordAmount;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.ToolStripMenuItem testRoomToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxBrightess;
        private System.Windows.Forms.RadioButton radioButtonBrightess;
        private System.Windows.Forms.RadioButton radioButtonStandart;
        private System.Windows.Forms.CheckBox checkBoxFaceApproximate;
    }
}

