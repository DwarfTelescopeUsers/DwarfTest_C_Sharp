namespace ClientTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            BtnRotateAnti = new Button();
            BtnRotateStop = new Button();
            BtnRotateClock = new Button();
            CamControlGB = new TabControl();
            ConfigTab = new TabPage();
            saveDetailsButton = new Button();
            siteDetailsGB = new GroupBox();
            enterLatButton = new Button();
            enterLonButton = new Button();
            LongitudeLabel = new Label();
            longitudeTB = new TextBox();
            latitudeLabel = new Label();
            latitudeTB = new TextBox();
            NetworkIPGB = new GroupBox();
            ipTextBox = new TextBox();
            TPTab = new TabPage();
            groupBox3 = new GroupBox();
            TPPreviewLabel = new Label();
            TPPreviewTB = new TrackBar();
            TPSharpnessGB = new GroupBox();
            TPSharpnessLabel = new Label();
            TPSharpnessTB = new TrackBar();
            TPHueGB = new GroupBox();
            TPHueLabel = new Label();
            TPHueTB = new TrackBar();
            TPSaturationGB = new GroupBox();
            TPSaturationLabel = new Label();
            TPSaturationTB = new TrackBar();
            TPContrastGB = new GroupBox();
            TPContrastLabel = new Label();
            TPContrastTB = new TrackBar();
            TPBrightnessGB = new GroupBox();
            TPBrightnessLabel = new Label();
            TPBrightnessTB = new TrackBar();
            TPIRCutGB = new GroupBox();
            TPIRPassRB = new RadioButton();
            TPIRCutRB = new RadioButton();
            TPGainGB = new GroupBox();
            TPGainCB = new ComboBox();
            TPExposureGB = new GroupBox();
            TPExposureCB = new ComboBox();
            WATab = new TabPage();
            WAGainGB = new GroupBox();
            WAGainLabel = new Label();
            WAGainTB = new TrackBar();
            WAExposureGB = new GroupBox();
            WAExposureCB = new ComboBox();
            tabPage1 = new TabPage();
            WAISPButton = new Button();
            TPISPButton = new Button();
            richTextBox1 = new RichTextBox();
            astroTab = new TabPage();
            objectGB = new GroupBox();
            richTextBox2 = new RichTextBox();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            BtnTPOff = new Button();
            BtnTPOn = new Button();
            BtnWAOff = new Button();
            BtnWAOn = new Button();
            BtnRotateUp = new Button();
            BtnRotateDown = new Button();
            vlcControl = new Vlc.DotNet.Forms.VlcControl();
            statusStrip1 = new StatusStrip();
            toolStripFirmwareLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripPowerPB = new ToolStripProgressBar();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripSDCardPB = new ToolStripProgressBar();
            StatusBarTimer = new System.Windows.Forms.Timer(components);
            CamControlGB.SuspendLayout();
            ConfigTab.SuspendLayout();
            siteDetailsGB.SuspendLayout();
            NetworkIPGB.SuspendLayout();
            TPTab.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPPreviewTB).BeginInit();
            TPSharpnessGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPSharpnessTB).BeginInit();
            TPHueGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPHueTB).BeginInit();
            TPSaturationGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPSaturationTB).BeginInit();
            TPContrastGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPContrastTB).BeginInit();
            TPBrightnessGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPBrightnessTB).BeginInit();
            TPIRCutGB.SuspendLayout();
            TPGainGB.SuspendLayout();
            TPExposureGB.SuspendLayout();
            WATab.SuspendLayout();
            WAGainGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WAGainTB).BeginInit();
            WAExposureGB.SuspendLayout();
            tabPage1.SuspendLayout();
            astroTab.SuspendLayout();
            objectGB.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vlcControl).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnRotateAnti
            // 
            BtnRotateAnti.Location = new Point(11, 78);
            BtnRotateAnti.Name = "BtnRotateAnti";
            BtnRotateAnti.Size = new Size(89, 23);
            BtnRotateAnti.TabIndex = 1;
            BtnRotateAnti.Text = "Anticlockwise";
            BtnRotateAnti.UseVisualStyleBackColor = true;
            BtnRotateAnti.Click += BtnRotateAnti_Click;
            // 
            // BtnRotateStop
            // 
            BtnRotateStop.Location = new Point(106, 78);
            BtnRotateStop.Name = "BtnRotateStop";
            BtnRotateStop.Size = new Size(75, 23);
            BtnRotateStop.TabIndex = 2;
            BtnRotateStop.Text = "Stop";
            BtnRotateStop.UseVisualStyleBackColor = true;
            BtnRotateStop.Click += BtnStop_Click;
            // 
            // BtnRotateClock
            // 
            BtnRotateClock.Location = new Point(187, 78);
            BtnRotateClock.Name = "BtnRotateClock";
            BtnRotateClock.Size = new Size(85, 23);
            BtnRotateClock.TabIndex = 3;
            BtnRotateClock.Text = "Clockwise";
            BtnRotateClock.UseVisualStyleBackColor = true;
            BtnRotateClock.Click += BtnRotateClock_Click;
            // 
            // CamControlGB
            // 
            CamControlGB.Controls.Add(ConfigTab);
            CamControlGB.Controls.Add(TPTab);
            CamControlGB.Controls.Add(WATab);
            CamControlGB.Controls.Add(tabPage1);
            CamControlGB.Controls.Add(astroTab);
            CamControlGB.Location = new Point(12, 173);
            CamControlGB.Name = "CamControlGB";
            CamControlGB.SelectedIndex = 0;
            CamControlGB.Size = new Size(423, 528);
            CamControlGB.TabIndex = 5;
            CamControlGB.MouseDown += TrackBar_MouseDown;
            // 
            // ConfigTab
            // 
            ConfigTab.Controls.Add(saveDetailsButton);
            ConfigTab.Controls.Add(siteDetailsGB);
            ConfigTab.Controls.Add(NetworkIPGB);
            ConfigTab.Location = new Point(4, 24);
            ConfigTab.Name = "ConfigTab";
            ConfigTab.Size = new Size(415, 500);
            ConfigTab.TabIndex = 2;
            ConfigTab.Text = "Configuration";
            ConfigTab.UseVisualStyleBackColor = true;
            // 
            // saveDetailsButton
            // 
            saveDetailsButton.Location = new Point(305, 461);
            saveDetailsButton.Name = "saveDetailsButton";
            saveDetailsButton.Size = new Size(94, 23);
            saveDetailsButton.TabIndex = 2;
            saveDetailsButton.Text = "Save Details";
            saveDetailsButton.UseVisualStyleBackColor = true;
            saveDetailsButton.Click += saveDetailsButton_Click;
            // 
            // siteDetailsGB
            // 
            siteDetailsGB.Controls.Add(enterLatButton);
            siteDetailsGB.Controls.Add(enterLonButton);
            siteDetailsGB.Controls.Add(LongitudeLabel);
            siteDetailsGB.Controls.Add(longitudeTB);
            siteDetailsGB.Controls.Add(latitudeLabel);
            siteDetailsGB.Controls.Add(latitudeTB);
            siteDetailsGB.Location = new Point(3, 61);
            siteDetailsGB.Name = "siteDetailsGB";
            siteDetailsGB.Size = new Size(271, 130);
            siteDetailsGB.TabIndex = 1;
            siteDetailsGB.TabStop = false;
            siteDetailsGB.Text = "Site Details";
            // 
            // enterLatButton
            // 
            enterLatButton.Location = new Point(218, 37);
            enterLatButton.Name = "enterLatButton";
            enterLatButton.Size = new Size(43, 23);
            enterLatButton.TabIndex = 7;
            enterLatButton.Text = "Enter";
            enterLatButton.UseVisualStyleBackColor = true;
            enterLatButton.Click += enterLatButton_Click;
            // 
            // enterLonButton
            // 
            enterLonButton.Location = new Point(217, 91);
            enterLonButton.Name = "enterLonButton";
            enterLonButton.Size = new Size(43, 23);
            enterLonButton.TabIndex = 4;
            enterLonButton.Text = "Enter";
            enterLonButton.UseVisualStyleBackColor = true;
            enterLonButton.Click += enterLonButton_Click;
            // 
            // LongitudeLabel
            // 
            LongitudeLabel.AutoSize = true;
            LongitudeLabel.Location = new Point(5, 72);
            LongitudeLabel.Name = "LongitudeLabel";
            LongitudeLabel.Size = new Size(61, 15);
            LongitudeLabel.TabIndex = 3;
            LongitudeLabel.Text = "Longitude";
            // 
            // longitudeTB
            // 
            longitudeTB.Location = new Point(5, 91);
            longitudeTB.Name = "longitudeTB";
            longitudeTB.Size = new Size(206, 23);
            longitudeTB.TabIndex = 2;
            // 
            // latitudeLabel
            // 
            latitudeLabel.AutoSize = true;
            latitudeLabel.Location = new Point(5, 19);
            latitudeLabel.Name = "latitudeLabel";
            latitudeLabel.Size = new Size(50, 15);
            latitudeLabel.TabIndex = 1;
            latitudeLabel.Text = "Latitude";
            // 
            // latitudeTB
            // 
            latitudeTB.Location = new Point(5, 38);
            latitudeTB.Name = "latitudeTB";
            latitudeTB.Size = new Size(206, 23);
            latitudeTB.TabIndex = 0;
            // 
            // NetworkIPGB
            // 
            NetworkIPGB.Controls.Add(ipTextBox);
            NetworkIPGB.Location = new Point(3, 3);
            NetworkIPGB.Name = "NetworkIPGB";
            NetworkIPGB.Size = new Size(217, 52);
            NetworkIPGB.TabIndex = 0;
            NetworkIPGB.TabStop = false;
            NetworkIPGB.Text = "IP Address";
            // 
            // ipTextBox
            // 
            ipTextBox.Location = new Point(6, 22);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(205, 23);
            ipTextBox.TabIndex = 2;
            // 
            // TPTab
            // 
            TPTab.Controls.Add(groupBox3);
            TPTab.Controls.Add(TPSharpnessGB);
            TPTab.Controls.Add(TPHueGB);
            TPTab.Controls.Add(TPSaturationGB);
            TPTab.Controls.Add(TPContrastGB);
            TPTab.Controls.Add(TPBrightnessGB);
            TPTab.Controls.Add(TPIRCutGB);
            TPTab.Controls.Add(TPGainGB);
            TPTab.Controls.Add(TPExposureGB);
            TPTab.Location = new Point(4, 24);
            TPTab.Name = "TPTab";
            TPTab.Padding = new Padding(3);
            TPTab.Size = new Size(415, 500);
            TPTab.TabIndex = 0;
            TPTab.Text = "Telephoto Settings";
            TPTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(TPPreviewLabel);
            groupBox3.Controls.Add(TPPreviewTB);
            groupBox3.Location = new Point(230, 309);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(202, 75);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Preview Quality";
            // 
            // TPPreviewLabel
            // 
            TPPreviewLabel.AutoSize = true;
            TPPreviewLabel.Location = new Point(172, 32);
            TPPreviewLabel.Name = "TPPreviewLabel";
            TPPreviewLabel.Size = new Size(19, 15);
            TPPreviewLabel.TabIndex = 1;
            TPPreviewLabel.Text = "55";
            // 
            // TPPreviewTB
            // 
            TPPreviewTB.Location = new Point(9, 19);
            TPPreviewTB.Maximum = 80;
            TPPreviewTB.Minimum = 30;
            TPPreviewTB.Name = "TPPreviewTB";
            TPPreviewTB.Size = new Size(163, 45);
            TPPreviewTB.SmallChange = 5;
            TPPreviewTB.TabIndex = 0;
            TPPreviewTB.TickFrequency = 5;
            TPPreviewTB.Value = 55;
            TPPreviewTB.ValueChanged += TPPreviewTB_ValueChanged;
            // 
            // TPSharpnessGB
            // 
            TPSharpnessGB.BackColor = Color.Transparent;
            TPSharpnessGB.Controls.Add(TPSharpnessLabel);
            TPSharpnessGB.Controls.Add(TPSharpnessTB);
            TPSharpnessGB.Location = new Point(230, 228);
            TPSharpnessGB.Name = "TPSharpnessGB";
            TPSharpnessGB.Size = new Size(202, 75);
            TPSharpnessGB.TabIndex = 8;
            TPSharpnessGB.TabStop = false;
            TPSharpnessGB.Text = "Sharpness";
            // 
            // TPSharpnessLabel
            // 
            TPSharpnessLabel.AutoSize = true;
            TPSharpnessLabel.Location = new Point(172, 33);
            TPSharpnessLabel.Name = "TPSharpnessLabel";
            TPSharpnessLabel.Size = new Size(19, 15);
            TPSharpnessLabel.TabIndex = 1;
            TPSharpnessLabel.Text = "50";
            // 
            // TPSharpnessTB
            // 
            TPSharpnessTB.Location = new Point(9, 19);
            TPSharpnessTB.Maximum = 100;
            TPSharpnessTB.Name = "TPSharpnessTB";
            TPSharpnessTB.Size = new Size(163, 45);
            TPSharpnessTB.TabIndex = 0;
            TPSharpnessTB.Value = 50;
            TPSharpnessTB.ValueChanged += TPSharpnessTB_ValueChanged;
            TPSharpnessTB.MouseDown += TrackBar_MouseDown;
            // 
            // TPHueGB
            // 
            TPHueGB.BackColor = Color.Transparent;
            TPHueGB.Controls.Add(TPHueLabel);
            TPHueGB.Controls.Add(TPHueTB);
            TPHueGB.Location = new Point(3, 309);
            TPHueGB.Name = "TPHueGB";
            TPHueGB.Size = new Size(202, 75);
            TPHueGB.TabIndex = 7;
            TPHueGB.TabStop = false;
            TPHueGB.Text = "Hue";
            // 
            // TPHueLabel
            // 
            TPHueLabel.AutoSize = true;
            TPHueLabel.Location = new Point(172, 32);
            TPHueLabel.Name = "TPHueLabel";
            TPHueLabel.Size = new Size(25, 15);
            TPHueLabel.TabIndex = 1;
            TPHueLabel.Text = "180";
            // 
            // TPHueTB
            // 
            TPHueTB.Location = new Point(9, 19);
            TPHueTB.Maximum = 360;
            TPHueTB.Name = "TPHueTB";
            TPHueTB.Size = new Size(163, 45);
            TPHueTB.TabIndex = 0;
            TPHueTB.Value = 180;
            TPHueTB.ValueChanged += TPHueTB_ValueChanged;
            TPHueTB.MouseDown += TrackBar_MouseDown;
            // 
            // TPSaturationGB
            // 
            TPSaturationGB.BackColor = Color.Transparent;
            TPSaturationGB.Controls.Add(TPSaturationLabel);
            TPSaturationGB.Controls.Add(TPSaturationTB);
            TPSaturationGB.Location = new Point(3, 228);
            TPSaturationGB.Name = "TPSaturationGB";
            TPSaturationGB.Size = new Size(202, 75);
            TPSaturationGB.TabIndex = 6;
            TPSaturationGB.TabStop = false;
            TPSaturationGB.Text = "Saturation";
            // 
            // TPSaturationLabel
            // 
            TPSaturationLabel.AutoSize = true;
            TPSaturationLabel.Location = new Point(172, 33);
            TPSaturationLabel.Name = "TPSaturationLabel";
            TPSaturationLabel.Size = new Size(19, 15);
            TPSaturationLabel.TabIndex = 1;
            TPSaturationLabel.Text = "50";
            // 
            // TPSaturationTB
            // 
            TPSaturationTB.Location = new Point(9, 19);
            TPSaturationTB.Maximum = 100;
            TPSaturationTB.Name = "TPSaturationTB";
            TPSaturationTB.Size = new Size(163, 45);
            TPSaturationTB.TabIndex = 0;
            TPSaturationTB.Value = 50;
            TPSaturationTB.ValueChanged += TPSaturationTB_ValueChanged;
            TPSaturationTB.MouseDown += TrackBar_MouseDown;
            // 
            // TPContrastGB
            // 
            TPContrastGB.BackColor = Color.Transparent;
            TPContrastGB.Controls.Add(TPContrastLabel);
            TPContrastGB.Controls.Add(TPContrastTB);
            TPContrastGB.Location = new Point(3, 147);
            TPContrastGB.Name = "TPContrastGB";
            TPContrastGB.Size = new Size(202, 75);
            TPContrastGB.TabIndex = 5;
            TPContrastGB.TabStop = false;
            TPContrastGB.Text = "Contrast";
            // 
            // TPContrastLabel
            // 
            TPContrastLabel.AutoSize = true;
            TPContrastLabel.Location = new Point(172, 36);
            TPContrastLabel.Name = "TPContrastLabel";
            TPContrastLabel.Size = new Size(19, 15);
            TPContrastLabel.TabIndex = 1;
            TPContrastLabel.Text = "50";
            // 
            // TPContrastTB
            // 
            TPContrastTB.Location = new Point(9, 19);
            TPContrastTB.Maximum = 100;
            TPContrastTB.Name = "TPContrastTB";
            TPContrastTB.Size = new Size(163, 45);
            TPContrastTB.TabIndex = 0;
            TPContrastTB.Value = 50;
            TPContrastTB.ValueChanged += TPContrastTB_ValueChanged;
            TPContrastTB.MouseDown += TrackBar_MouseDown;
            // 
            // TPBrightnessGB
            // 
            TPBrightnessGB.BackColor = Color.Transparent;
            TPBrightnessGB.Controls.Add(TPBrightnessLabel);
            TPBrightnessGB.Controls.Add(TPBrightnessTB);
            TPBrightnessGB.Location = new Point(3, 66);
            TPBrightnessGB.Name = "TPBrightnessGB";
            TPBrightnessGB.Size = new Size(202, 75);
            TPBrightnessGB.TabIndex = 4;
            TPBrightnessGB.TabStop = false;
            TPBrightnessGB.Text = "Brightness";
            // 
            // TPBrightnessLabel
            // 
            TPBrightnessLabel.AutoSize = true;
            TPBrightnessLabel.Location = new Point(172, 33);
            TPBrightnessLabel.Name = "TPBrightnessLabel";
            TPBrightnessLabel.Size = new Size(19, 15);
            TPBrightnessLabel.TabIndex = 1;
            TPBrightnessLabel.Text = "50";
            // 
            // TPBrightnessTB
            // 
            TPBrightnessTB.Location = new Point(9, 19);
            TPBrightnessTB.Maximum = 100;
            TPBrightnessTB.Name = "TPBrightnessTB";
            TPBrightnessTB.Size = new Size(163, 45);
            TPBrightnessTB.TabIndex = 0;
            TPBrightnessTB.Value = 50;
            TPBrightnessTB.ValueChanged += TPBrightnessTB_ValueChanged;
            TPBrightnessTB.MouseDown += TrackBar_MouseDown;
            // 
            // TPIRCutGB
            // 
            TPIRCutGB.Controls.Add(TPIRPassRB);
            TPIRCutGB.Controls.Add(TPIRCutRB);
            TPIRCutGB.Location = new Point(313, 6);
            TPIRCutGB.Name = "TPIRCutGB";
            TPIRCutGB.Size = new Size(119, 54);
            TPIRCutGB.TabIndex = 3;
            TPIRCutGB.TabStop = false;
            TPIRCutGB.Text = "Infra red";
            // 
            // TPIRPassRB
            // 
            TPIRPassRB.AutoSize = true;
            TPIRPassRB.Location = new Point(61, 22);
            TPIRPassRB.Name = "TPIRPassRB";
            TPIRPassRB.Size = new Size(48, 19);
            TPIRPassRB.TabIndex = 1;
            TPIRPassRB.Text = "Pass";
            TPIRPassRB.UseVisualStyleBackColor = true;
            TPIRPassRB.Click += TPIRPassRB_Click;
            // 
            // TPIRCutRB
            // 
            TPIRCutRB.AutoSize = true;
            TPIRCutRB.Checked = true;
            TPIRCutRB.Location = new Point(11, 22);
            TPIRCutRB.Name = "TPIRCutRB";
            TPIRCutRB.Size = new Size(44, 19);
            TPIRCutRB.TabIndex = 0;
            TPIRCutRB.TabStop = true;
            TPIRCutRB.Text = "Cut";
            TPIRCutRB.UseVisualStyleBackColor = true;
            TPIRCutRB.Click += TPIRCutRB_Click;
            // 
            // TPGainGB
            // 
            TPGainGB.BackColor = Color.Lime;
            TPGainGB.Controls.Add(TPGainCB);
            TPGainGB.Location = new Point(137, 6);
            TPGainGB.Name = "TPGainGB";
            TPGainGB.Size = new Size(125, 54);
            TPGainGB.TabIndex = 2;
            TPGainGB.TabStop = false;
            TPGainGB.Text = "Gain";
            // 
            // TPGainCB
            // 
            TPGainCB.FormattingEnabled = true;
            TPGainCB.Items.AddRange(new object[] { "Auto", "0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130", "140", "150", "160", "170", "180", "190", "200", "210", "220", "230", "240" });
            TPGainCB.Location = new Point(6, 22);
            TPGainCB.Name = "TPGainCB";
            TPGainCB.Size = new Size(108, 23);
            TPGainCB.TabIndex = 0;
            TPGainCB.Text = "Auto";
            TPGainCB.SelectedIndexChanged += TPGainCB_SelectedIndexChanged;
            // 
            // TPExposureGB
            // 
            TPExposureGB.BackColor = Color.Lime;
            TPExposureGB.Controls.Add(TPExposureCB);
            TPExposureGB.Location = new Point(3, 6);
            TPExposureGB.Name = "TPExposureGB";
            TPExposureGB.Size = new Size(125, 54);
            TPExposureGB.TabIndex = 1;
            TPExposureGB.TabStop = false;
            TPExposureGB.Text = "Exposure (s)";
            // 
            // TPExposureCB
            // 
            TPExposureCB.FormattingEnabled = true;
            TPExposureCB.Items.AddRange(new object[] { "Auto", "1/10000", "1/8000", "1/6400", "1/5000", "1/4000", "1/3200", "1/2500", "1/1600", "1/1250", "1/1000", "1/800", "1/640", "1/500", "1/400", "1/320", "1/250", "1/160", "1/125", "1/100", "1/80", "1/60", "1/50", "1/40", "1/30", "1/20", "1/15", "1/13", "1/10", "1/8", "1/6", "1/5", "1/4", "1/3", "0.4", "0.5", "0.6", "0.8", "1", "1.3", "1.6", "2", "2.5", "3.2", "4", "5", "6", "8", "10", "13", "15" });
            TPExposureCB.Location = new Point(6, 22);
            TPExposureCB.Name = "TPExposureCB";
            TPExposureCB.Size = new Size(108, 23);
            TPExposureCB.TabIndex = 0;
            TPExposureCB.Text = "Auto";
            TPExposureCB.SelectedIndexChanged += TPExposureCB_SelectedIndexChanged;
            // 
            // WATab
            // 
            WATab.Controls.Add(WAGainGB);
            WATab.Controls.Add(WAExposureGB);
            WATab.Location = new Point(4, 24);
            WATab.Name = "WATab";
            WATab.Padding = new Padding(3);
            WATab.Size = new Size(415, 500);
            WATab.TabIndex = 1;
            WATab.Text = "Wideangle Settings";
            WATab.UseVisualStyleBackColor = true;
            // 
            // WAGainGB
            // 
            WAGainGB.BackColor = Color.Transparent;
            WAGainGB.Controls.Add(WAGainLabel);
            WAGainGB.Controls.Add(WAGainTB);
            WAGainGB.Location = new Point(6, 74);
            WAGainGB.Name = "WAGainGB";
            WAGainGB.Size = new Size(202, 75);
            WAGainGB.TabIndex = 5;
            WAGainGB.TabStop = false;
            WAGainGB.Text = "Gain";
            // 
            // WAGainLabel
            // 
            WAGainLabel.AutoSize = true;
            WAGainLabel.Location = new Point(172, 33);
            WAGainLabel.Name = "WAGainLabel";
            WAGainLabel.Size = new Size(19, 15);
            WAGainLabel.TabIndex = 1;
            WAGainLabel.Text = "64";
            // 
            // WAGainTB
            // 
            WAGainTB.Location = new Point(9, 19);
            WAGainTB.Maximum = 160;
            WAGainTB.Minimum = 64;
            WAGainTB.Name = "WAGainTB";
            WAGainTB.Size = new Size(163, 45);
            WAGainTB.TabIndex = 0;
            WAGainTB.Value = 64;
            WAGainTB.ValueChanged += WAGainTB_ValueChanged;
            WAGainTB.MouseDown += TrackBar_MouseDown;
            // 
            // WAExposureGB
            // 
            WAExposureGB.BackColor = Color.Lime;
            WAExposureGB.Controls.Add(WAExposureCB);
            WAExposureGB.Location = new Point(6, 6);
            WAExposureGB.Name = "WAExposureGB";
            WAExposureGB.Size = new Size(125, 62);
            WAExposureGB.TabIndex = 2;
            WAExposureGB.TabStop = false;
            WAExposureGB.Text = "Exposure (s)";
            // 
            // WAExposureCB
            // 
            WAExposureCB.FormattingEnabled = true;
            WAExposureCB.Items.AddRange(new object[] { "Auto", "3/10000", "1/2500", "1/2000", "1/1600", "1/1250", "1/1000", "1/800", "1/640", "1/500", "1/400", "1/320", "1/250", "1/160", "1/125", "1/100", "1/80", "1/60", "1/50", "1/40", "1/30", "1/25", "1/20", "1/15", "1/13", "1/10", "1/8", "1/6", "1/5", "1/4", "1/3", "0.4", "0.5", "0.6", "0.8", "1" });
            WAExposureCB.Location = new Point(6, 22);
            WAExposureCB.Name = "WAExposureCB";
            WAExposureCB.Size = new Size(108, 23);
            WAExposureCB.TabIndex = 0;
            WAExposureCB.Text = "Auto";
            WAExposureCB.SelectedIndexChanged += WAExposureCB_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(WAISPButton);
            tabPage1.Controls.Add(TPISPButton);
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(415, 500);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // WAISPButton
            // 
            WAISPButton.Location = new Point(234, 453);
            WAISPButton.Name = "WAISPButton";
            WAISPButton.Size = new Size(137, 23);
            WAISPButton.TabIndex = 2;
            WAISPButton.Text = "Wide Angle  ISP Values";
            WAISPButton.UseVisualStyleBackColor = true;
            WAISPButton.Click += WAISPButton_Click;
            // 
            // TPISPButton
            // 
            TPISPButton.Location = new Point(28, 453);
            TPISPButton.Name = "TPISPButton";
            TPISPButton.Size = new Size(137, 23);
            TPISPButton.TabIndex = 1;
            TPISPButton.Text = "Telephoto ISP Values";
            TPISPButton.UseVisualStyleBackColor = true;
            TPISPButton.Click += TPISPButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(397, 444);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // astroTab
            // 
            astroTab.Controls.Add(objectGB);
            astroTab.Location = new Point(4, 24);
            astroTab.Name = "astroTab";
            astroTab.Size = new Size(415, 500);
            astroTab.TabIndex = 4;
            astroTab.Text = "Astrophotography";
            astroTab.UseVisualStyleBackColor = true;
            // 
            // objectGB
            // 
            objectGB.Controls.Add(richTextBox2);
            objectGB.Controls.Add(comboBox1);
            objectGB.Location = new Point(3, 330);
            objectGB.Name = "objectGB";
            objectGB.Size = new Size(409, 167);
            objectGB.TabIndex = 0;
            objectGB.TabStop = false;
            objectGB.Text = "Select Object";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(6, 51);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(397, 110);
            richTextBox2.TabIndex = 1;
            richTextBox2.Text = "";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(127, 23);
            comboBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnTPOff);
            groupBox1.Controls.Add(BtnTPOn);
            groupBox1.Controls.Add(BtnWAOff);
            groupBox1.Controls.Add(BtnWAOn);
            groupBox1.Location = new Point(317, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(114, 155);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Camera Selection";
            // 
            // BtnTPOff
            // 
            BtnTPOff.Location = new Point(19, 121);
            BtnTPOff.Name = "BtnTPOff";
            BtnTPOff.Size = new Size(75, 23);
            BtnTPOff.TabIndex = 8;
            BtnTPOff.Text = "TP Off";
            BtnTPOff.UseVisualStyleBackColor = true;
            BtnTPOff.Click += BtnTPOff_Click;
            // 
            // BtnTPOn
            // 
            BtnTPOn.Location = new Point(19, 92);
            BtnTPOn.Name = "BtnTPOn";
            BtnTPOn.Size = new Size(75, 23);
            BtnTPOn.TabIndex = 7;
            BtnTPOn.Text = "TP On";
            BtnTPOn.UseVisualStyleBackColor = true;
            BtnTPOn.Click += BtnTPOn_Click;
            // 
            // BtnWAOff
            // 
            BtnWAOff.Location = new Point(19, 52);
            BtnWAOff.Name = "BtnWAOff";
            BtnWAOff.Size = new Size(75, 23);
            BtnWAOff.TabIndex = 6;
            BtnWAOff.Text = "WA Off";
            BtnWAOff.UseVisualStyleBackColor = true;
            BtnWAOff.Click += BtnWAOff_Click;
            // 
            // BtnWAOn
            // 
            BtnWAOn.Location = new Point(19, 23);
            BtnWAOn.Name = "BtnWAOn";
            BtnWAOn.Size = new Size(75, 23);
            BtnWAOn.TabIndex = 5;
            BtnWAOn.Text = "WA On";
            BtnWAOn.UseVisualStyleBackColor = true;
            BtnWAOn.Click += BtnWAOn_Click;
            // 
            // BtnRotateUp
            // 
            BtnRotateUp.Location = new Point(99, 49);
            BtnRotateUp.Name = "BtnRotateUp";
            BtnRotateUp.Size = new Size(89, 23);
            BtnRotateUp.TabIndex = 8;
            BtnRotateUp.Text = "Up";
            BtnRotateUp.UseVisualStyleBackColor = true;
            BtnRotateUp.Click += BtnRotateUp_Click;
            // 
            // BtnRotateDown
            // 
            BtnRotateDown.Location = new Point(99, 107);
            BtnRotateDown.Name = "BtnRotateDown";
            BtnRotateDown.Size = new Size(89, 23);
            BtnRotateDown.TabIndex = 9;
            BtnRotateDown.Text = "Down";
            BtnRotateDown.UseVisualStyleBackColor = true;
            BtnRotateDown.Click += BtnRotateDown_Click;
            // 
            // vlcControl
            // 
            vlcControl.BackColor = Color.Black;
            vlcControl.Location = new Point(437, 12);
            vlcControl.Name = "vlcControl";
            vlcControl.Size = new Size(850, 600);
            vlcControl.Spu = -1;
            vlcControl.TabIndex = 10;
            vlcControl.Text = "videoWindow";
            vlcControl.VlcLibDirectory = null;
            vlcControl.VlcMediaplayerOptions = null;
            vlcControl.VlcLibDirectoryNeeded += vlcControl_VlcLibDirectoryNeeded;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripFirmwareLabel1, toolStripStatusLabel1, toolStripPowerPB, toolStripStatusLabel2, toolStripSDCardPB });
            statusStrip1.Location = new Point(0, 708);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.ShowItemToolTips = true;
            statusStrip1.Size = new Size(1293, 22);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripFirmwareLabel1
            // 
            toolStripFirmwareLabel1.Name = "toolStripFirmwareLabel1";
            toolStripFirmwareLabel1.Size = new Size(100, 17);
            toolStripFirmwareLabel1.Text = "Firmware Version:";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(61, 17);
            toolStripStatusLabel1.Text = "Power (%)";
            // 
            // toolStripPowerPB
            // 
            toolStripPowerPB.AutoToolTip = true;
            toolStripPowerPB.Name = "toolStripPowerPB";
            toolStripPowerPB.Size = new Size(100, 16);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(70, 17);
            toolStripStatusLabel2.Text = "SD Card (%)";
            // 
            // toolStripSDCardPB
            // 
            toolStripSDCardPB.AutoToolTip = true;
            toolStripSDCardPB.Name = "toolStripSDCardPB";
            toolStripSDCardPB.Size = new Size(100, 16);
            // 
            // StatusBarTimer
            // 
            StatusBarTimer.Interval = 60000;
            StatusBarTimer.Tick += StatusBarTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1293, 730);
            Controls.Add(statusStrip1);
            Controls.Add(vlcControl);
            Controls.Add(BtnRotateDown);
            Controls.Add(BtnRotateUp);
            Controls.Add(groupBox1);
            Controls.Add(CamControlGB);
            Controls.Add(BtnRotateClock);
            Controls.Add(BtnRotateStop);
            Controls.Add(BtnRotateAnti);
            Name = "Form1";
            Text = "Form1";
            CamControlGB.ResumeLayout(false);
            ConfigTab.ResumeLayout(false);
            siteDetailsGB.ResumeLayout(false);
            siteDetailsGB.PerformLayout();
            NetworkIPGB.ResumeLayout(false);
            NetworkIPGB.PerformLayout();
            TPTab.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPPreviewTB).EndInit();
            TPSharpnessGB.ResumeLayout(false);
            TPSharpnessGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPSharpnessTB).EndInit();
            TPHueGB.ResumeLayout(false);
            TPHueGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPHueTB).EndInit();
            TPSaturationGB.ResumeLayout(false);
            TPSaturationGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPSaturationTB).EndInit();
            TPContrastGB.ResumeLayout(false);
            TPContrastGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPContrastTB).EndInit();
            TPBrightnessGB.ResumeLayout(false);
            TPBrightnessGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPBrightnessTB).EndInit();
            TPIRCutGB.ResumeLayout(false);
            TPIRCutGB.PerformLayout();
            TPGainGB.ResumeLayout(false);
            TPExposureGB.ResumeLayout(false);
            WATab.ResumeLayout(false);
            WAGainGB.ResumeLayout(false);
            WAGainGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WAGainTB).EndInit();
            WAExposureGB.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            astroTab.ResumeLayout(false);
            objectGB.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)vlcControl).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnRotateAnti;
        private Button BtnRotateStop;
        private Button BtnRotateClock;
        private TabControl CamControlGB;
        private TabPage TPTab;
        private TabPage WATab;
        private GroupBox groupBox1;
        private Button BtnTPOff;
        private Button BtnTPOn;
        private Button BtnWAOff;
        private Button BtnWAOn;
        private Button BtnRotateUp;
        private Button BtnRotateDown;
        private Vlc.DotNet.Forms.VlcControl vlcControl;
        private GroupBox TPExposureGB;
        private ComboBox TPExposureCB;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripFirmwareLabel1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar toolStripPowerPB;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripProgressBar toolStripSDCardPB;
        private System.Windows.Forms.Timer StatusBarTimer;
        private GroupBox WAExposureGB;
        private ComboBox WAExposureCB;
        private GroupBox TPGainGB;
        private ComboBox TPGainCB;
        private GroupBox TPIRCutGB;
        private RadioButton TPIRPassRB;
        private RadioButton TPIRCutRB;
        private GroupBox TPBrightnessGB;
        private Label TPBrightnessLabel;
        private TrackBar TPBrightnessTB;
        private GroupBox TPContrastGB;
        private Label TPContrastLabel;
        private TrackBar TPContrastTB;
        private GroupBox TPSaturationGB;
        private Label TPSaturationLabel;
        private TrackBar TPSaturationTB;
        private GroupBox TPHueGB;
        private Label TPHueLabel;
        private TrackBar TPHueTB;
        private GroupBox TPSharpnessGB;
        private Label TPSharpnessLabel;
        private TrackBar TPSharpnessTB;
        private GroupBox groupBox3;
        private Label TPPreviewLabel;
        private TrackBar TPPreviewTB;
        private GroupBox WAGainGB;
        private Label WAGainLabel;
        private TrackBar WAGainTB;
        private TabPage ConfigTab;
        private GroupBox NetworkIPGB;
        private TextBox ipTextBox;
        private TabPage tabPage1;
        private Button WAISPButton;
        private Button TPISPButton;
        private RichTextBox richTextBox1;
        private Button saveDetailsButton;
        private GroupBox siteDetailsGB;
        private Button enterLonButton;
        private Label LongitudeLabel;
        private TextBox longitudeTB;
        private Label latitudeLabel;
        private TextBox latitudeTB;
        private Button enterLatButton;
        private TabPage astroTab;
        private GroupBox objectGB;
        private RichTextBox richTextBox2;
        private ComboBox comboBox1;
    }
}