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
            TPTab = new TabPage();
            IRFilterGB = new GroupBox();
            IRFilterCB = new ComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            TPGainGB = new GroupBox();
            TPGainTB = new TrackBar();
            TPBrightnessGB = new GroupBox();
            TPBrightnessTB = new TrackBar();
            TPSaturationGB = new GroupBox();
            TPSaturationTB = new TrackBar();
            TPHueGB = new GroupBox();
            TPHueTB = new TrackBar();
            TPSharpnessGB = new GroupBox();
            TPSharpnessTB = new TrackBar();
            TPPreviewGB = new GroupBox();
            TPPreviewTB = new TrackBar();
            TPContrastGB = new GroupBox();
            TPContrastTB = new TrackBar();
            TPWhiteBalanceGB = new GroupBox();
            TPWhiteBalanceTB = new TrackBar();
            groupBox4 = new GroupBox();
            trackBar3 = new TrackBar();
            TPExposureGB = new GroupBox();
            TPExposureCB = new ComboBox();
            WATab = new TabPage();
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
            TPTab.SuspendLayout();
            IRFilterGB.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            TPGainGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPGainTB).BeginInit();
            TPBrightnessGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPBrightnessTB).BeginInit();
            TPSaturationGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPSaturationTB).BeginInit();
            TPHueGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPHueTB).BeginInit();
            TPSharpnessGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPSharpnessTB).BeginInit();
            TPPreviewGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPPreviewTB).BeginInit();
            TPContrastGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPContrastTB).BeginInit();
            TPWhiteBalanceGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TPWhiteBalanceTB).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            TPExposureGB.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vlcControl).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnRotateAnti
            // 
            BtnRotateAnti.Location = new Point(44, 76);
            BtnRotateAnti.Name = "BtnRotateAnti";
            BtnRotateAnti.Size = new Size(89, 23);
            BtnRotateAnti.TabIndex = 1;
            BtnRotateAnti.Text = "Anticlockwise";
            BtnRotateAnti.UseVisualStyleBackColor = true;
            BtnRotateAnti.Click += BtnRotateAnti_Click;
            // 
            // BtnRotateStop
            // 
            BtnRotateStop.Location = new Point(139, 76);
            BtnRotateStop.Name = "BtnRotateStop";
            BtnRotateStop.Size = new Size(75, 23);
            BtnRotateStop.TabIndex = 2;
            BtnRotateStop.Text = "Stop";
            BtnRotateStop.UseVisualStyleBackColor = true;
            BtnRotateStop.Click += BtnStop_Click;
            // 
            // BtnRotateClock
            // 
            BtnRotateClock.Location = new Point(220, 76);
            BtnRotateClock.Name = "BtnRotateClock";
            BtnRotateClock.Size = new Size(85, 23);
            BtnRotateClock.TabIndex = 3;
            BtnRotateClock.Text = "Clockwise";
            BtnRotateClock.UseVisualStyleBackColor = true;
            BtnRotateClock.Click += BtnRotateClock_Click;
            // 
            // CamControlGB
            // 
            CamControlGB.Controls.Add(TPTab);
            CamControlGB.Controls.Add(WATab);
            CamControlGB.Location = new Point(12, 201);
            CamControlGB.Name = "CamControlGB";
            CamControlGB.SelectedIndex = 0;
            CamControlGB.Size = new Size(618, 528);
            CamControlGB.TabIndex = 5;
            CamControlGB.SelectedIndexChanged += CamControlGB_TabIndexChanged;
            // 
            // TPTab
            // 
            TPTab.Controls.Add(IRFilterGB);
            TPTab.Controls.Add(flowLayoutPanel1);
            TPTab.Controls.Add(TPExposureGB);
            TPTab.Location = new Point(4, 24);
            TPTab.Name = "TPTab";
            TPTab.Padding = new Padding(3);
            TPTab.Size = new Size(610, 500);
            TPTab.TabIndex = 0;
            TPTab.Text = "Telephoto Settings";
            TPTab.UseVisualStyleBackColor = true;
            // 
            // IRFilterGB
            // 
            IRFilterGB.Controls.Add(IRFilterCB);
            IRFilterGB.Location = new Point(369, 3);
            IRFilterGB.Name = "IRFilterGB";
            IRFilterGB.Size = new Size(125, 62);
            IRFilterGB.TabIndex = 3;
            IRFilterGB.TabStop = false;
            IRFilterGB.Text = "IR Filter";
            // 
            // IRFilterCB
            // 
            IRFilterCB.FormattingEnabled = true;
            IRFilterCB.Items.AddRange(new object[] { "IR Cut", "IR Pass" });
            IRFilterCB.Location = new Point(6, 22);
            IRFilterCB.Name = "IRFilterCB";
            IRFilterCB.Size = new Size(108, 23);
            IRFilterCB.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(TPGainGB);
            flowLayoutPanel1.Controls.Add(TPBrightnessGB);
            flowLayoutPanel1.Controls.Add(TPSaturationGB);
            flowLayoutPanel1.Controls.Add(TPHueGB);
            flowLayoutPanel1.Controls.Add(TPSharpnessGB);
            flowLayoutPanel1.Controls.Add(TPPreviewGB);
            flowLayoutPanel1.Controls.Add(TPContrastGB);
            flowLayoutPanel1.Controls.Add(TPWhiteBalanceGB);
            flowLayoutPanel1.Controls.Add(groupBox4);
            flowLayoutPanel1.Location = new Point(6, 74);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(488, 276);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // TPGainGB
            // 
            TPGainGB.Controls.Add(TPGainTB);
            TPGainGB.Location = new Point(3, 3);
            TPGainGB.Name = "TPGainGB";
            TPGainGB.Size = new Size(155, 84);
            TPGainGB.TabIndex = 0;
            TPGainGB.TabStop = false;
            TPGainGB.Text = "Gain";
            // 
            // TPGainTB
            // 
            TPGainTB.Location = new Point(7, 22);
            TPGainTB.Maximum = 240;
            TPGainTB.Minimum = -1;
            TPGainTB.Name = "TPGainTB";
            TPGainTB.Size = new Size(135, 45);
            TPGainTB.TabIndex = 1;
            TPGainTB.TickFrequency = 10;
            TPGainTB.ValueChanged += TPGainTB_ValueChanged;
            TPGainTB.MouseDown += TPGainTB_MouseDown;
            // 
            // TPBrightnessGB
            // 
            TPBrightnessGB.Controls.Add(TPBrightnessTB);
            TPBrightnessGB.Location = new Point(164, 3);
            TPBrightnessGB.Name = "TPBrightnessGB";
            TPBrightnessGB.Size = new Size(155, 84);
            TPBrightnessGB.TabIndex = 1;
            TPBrightnessGB.TabStop = false;
            TPBrightnessGB.Text = "Brightness";
            // 
            // TPBrightnessTB
            // 
            TPBrightnessTB.Location = new Point(7, 22);
            TPBrightnessTB.Maximum = 255;
            TPBrightnessTB.Name = "TPBrightnessTB";
            TPBrightnessTB.Size = new Size(135, 45);
            TPBrightnessTB.TabIndex = 1;
            TPBrightnessTB.TickFrequency = 10;
            TPBrightnessTB.Value = 128;
            TPBrightnessTB.ValueChanged += TPBrightnessTB_ValueChanged;
            TPBrightnessTB.MouseDown += TPBrightnessTB_MouseDown;
            // 
            // TPSaturationGB
            // 
            TPSaturationGB.Controls.Add(TPSaturationTB);
            TPSaturationGB.Location = new Point(325, 3);
            TPSaturationGB.Name = "TPSaturationGB";
            TPSaturationGB.Size = new Size(155, 84);
            TPSaturationGB.TabIndex = 2;
            TPSaturationGB.TabStop = false;
            TPSaturationGB.Text = "Saturation";
            // 
            // TPSaturationTB
            // 
            TPSaturationTB.Location = new Point(7, 22);
            TPSaturationTB.Maximum = 255;
            TPSaturationTB.Name = "TPSaturationTB";
            TPSaturationTB.Size = new Size(135, 45);
            TPSaturationTB.TabIndex = 1;
            TPSaturationTB.TickFrequency = 10;
            TPSaturationTB.Value = 128;
            // 
            // TPHueGB
            // 
            TPHueGB.Controls.Add(TPHueTB);
            TPHueGB.Location = new Point(3, 93);
            TPHueGB.Name = "TPHueGB";
            TPHueGB.Size = new Size(155, 84);
            TPHueGB.TabIndex = 3;
            TPHueGB.TabStop = false;
            TPHueGB.Text = "Hue";
            // 
            // TPHueTB
            // 
            TPHueTB.Location = new Point(7, 22);
            TPHueTB.Maximum = 360;
            TPHueTB.Name = "TPHueTB";
            TPHueTB.Size = new Size(135, 45);
            TPHueTB.TabIndex = 1;
            TPHueTB.TickFrequency = 20;
            TPHueTB.Value = 180;
            // 
            // TPSharpnessGB
            // 
            TPSharpnessGB.Controls.Add(TPSharpnessTB);
            TPSharpnessGB.Location = new Point(164, 93);
            TPSharpnessGB.Name = "TPSharpnessGB";
            TPSharpnessGB.Size = new Size(155, 84);
            TPSharpnessGB.TabIndex = 4;
            TPSharpnessGB.TabStop = false;
            TPSharpnessGB.Text = "Sharpness";
            // 
            // TPSharpnessTB
            // 
            TPSharpnessTB.Location = new Point(7, 22);
            TPSharpnessTB.Maximum = 100;
            TPSharpnessTB.Name = "TPSharpnessTB";
            TPSharpnessTB.Size = new Size(135, 45);
            TPSharpnessTB.TabIndex = 1;
            TPSharpnessTB.TickFrequency = 10;
            TPSharpnessTB.Value = 50;
            // 
            // TPPreviewGB
            // 
            TPPreviewGB.Controls.Add(TPPreviewTB);
            TPPreviewGB.Location = new Point(325, 93);
            TPPreviewGB.Name = "TPPreviewGB";
            TPPreviewGB.Size = new Size(155, 84);
            TPPreviewGB.TabIndex = 5;
            TPPreviewGB.TabStop = false;
            TPPreviewGB.Text = "Preview";
            // 
            // TPPreviewTB
            // 
            TPPreviewTB.Location = new Point(7, 22);
            TPPreviewTB.Maximum = 160;
            TPPreviewTB.Name = "TPPreviewTB";
            TPPreviewTB.Size = new Size(135, 45);
            TPPreviewTB.TabIndex = 1;
            TPPreviewTB.TickFrequency = 10;
            // 
            // TPContrastGB
            // 
            TPContrastGB.Controls.Add(TPContrastTB);
            TPContrastGB.Location = new Point(3, 183);
            TPContrastGB.Name = "TPContrastGB";
            TPContrastGB.Size = new Size(155, 84);
            TPContrastGB.TabIndex = 6;
            TPContrastGB.TabStop = false;
            TPContrastGB.Text = "Contrast";
            // 
            // TPContrastTB
            // 
            TPContrastTB.Location = new Point(7, 22);
            TPContrastTB.Maximum = 255;
            TPContrastTB.Name = "TPContrastTB";
            TPContrastTB.Size = new Size(135, 45);
            TPContrastTB.TabIndex = 1;
            TPContrastTB.TickFrequency = 10;
            TPContrastTB.Value = 128;
            TPContrastTB.ValueChanged += TPContrastTB_ValueChanged;
            TPContrastTB.MouseDown += TPContrastTB_MouseDown;
            // 
            // TPWhiteBalanceGB
            // 
            TPWhiteBalanceGB.Controls.Add(TPWhiteBalanceTB);
            TPWhiteBalanceGB.Location = new Point(164, 183);
            TPWhiteBalanceGB.Name = "TPWhiteBalanceGB";
            TPWhiteBalanceGB.Size = new Size(155, 84);
            TPWhiteBalanceGB.TabIndex = 7;
            TPWhiteBalanceGB.TabStop = false;
            TPWhiteBalanceGB.Text = "White Balance";
            // 
            // TPWhiteBalanceTB
            // 
            TPWhiteBalanceTB.Location = new Point(7, 22);
            TPWhiteBalanceTB.Maximum = 160;
            TPWhiteBalanceTB.Name = "TPWhiteBalanceTB";
            TPWhiteBalanceTB.Size = new Size(135, 45);
            TPWhiteBalanceTB.TabIndex = 1;
            TPWhiteBalanceTB.TickFrequency = 10;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(trackBar3);
            groupBox4.Location = new Point(325, 183);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(155, 84);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Preview";
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(7, 22);
            trackBar3.Maximum = 160;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(135, 45);
            trackBar3.TabIndex = 1;
            trackBar3.TickFrequency = 10;
            // 
            // TPExposureGB
            // 
            TPExposureGB.Controls.Add(TPExposureCB);
            TPExposureGB.Location = new Point(6, 6);
            TPExposureGB.Name = "TPExposureGB";
            TPExposureGB.Size = new Size(125, 62);
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
            TPExposureCB.SelectedIndexChanged += TPExposureCB_SelectedIndexChanged;
            TPExposureCB.MouseDown += TPExposureCB_MouseDown;
            // 
            // WATab
            // 
            WATab.Location = new Point(4, 24);
            WATab.Name = "WATab";
            WATab.Padding = new Padding(3);
            WATab.Size = new Size(610, 500);
            WATab.TabIndex = 1;
            WATab.Text = "Wideangle Settings";
            WATab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnTPOff);
            groupBox1.Controls.Add(BtnTPOn);
            groupBox1.Controls.Add(BtnWAOff);
            groupBox1.Controls.Add(BtnWAOn);
            groupBox1.Location = new Point(512, 12);
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
            BtnRotateUp.Location = new Point(132, 47);
            BtnRotateUp.Name = "BtnRotateUp";
            BtnRotateUp.Size = new Size(89, 23);
            BtnRotateUp.TabIndex = 8;
            BtnRotateUp.Text = "Up";
            BtnRotateUp.UseVisualStyleBackColor = true;
            BtnRotateUp.Click += BtnRotateUp_Click;
            // 
            // BtnRotateDown
            // 
            BtnRotateDown.Location = new Point(132, 105);
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
            vlcControl.Location = new Point(656, 21);
            vlcControl.Name = "vlcControl";
            vlcControl.Size = new Size(908, 704);
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
            statusStrip1.Location = new Point(0, 732);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.ShowItemToolTips = true;
            statusStrip1.Size = new Size(1576, 22);
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
            ClientSize = new Size(1576, 754);
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
            TPTab.ResumeLayout(false);
            IRFilterGB.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            TPGainGB.ResumeLayout(false);
            TPGainGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPGainTB).EndInit();
            TPBrightnessGB.ResumeLayout(false);
            TPBrightnessGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPBrightnessTB).EndInit();
            TPSaturationGB.ResumeLayout(false);
            TPSaturationGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPSaturationTB).EndInit();
            TPHueGB.ResumeLayout(false);
            TPHueGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPHueTB).EndInit();
            TPSharpnessGB.ResumeLayout(false);
            TPSharpnessGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPSharpnessTB).EndInit();
            TPPreviewGB.ResumeLayout(false);
            TPPreviewGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPPreviewTB).EndInit();
            TPContrastGB.ResumeLayout(false);
            TPContrastGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPContrastTB).EndInit();
            TPWhiteBalanceGB.ResumeLayout(false);
            TPWhiteBalanceGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TPWhiteBalanceTB).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            TPExposureGB.ResumeLayout(false);
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
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox TPGainGB;
        private TrackBar TPGainTB;
        private GroupBox TPBrightnessGB;
        private TrackBar TPBrightnessTB;
        private GroupBox TPSaturationGB;
        private TrackBar TPSaturationTB;
        private GroupBox TPHueGB;
        private TrackBar TPHueTB;
        private GroupBox TPSharpnessGB;
        private TrackBar TPSharpnessTB;
        private GroupBox TPPreviewGB;
        private TrackBar TPPreviewTB;
        private GroupBox TPContrastGB;
        private TrackBar TPContrastTB;
        private GroupBox TPWhiteBalanceGB;
        private TrackBar TPWhiteBalanceTB;
        private GroupBox groupBox4;
        private TrackBar trackBar3;
        private GroupBox IRFilterGB;
        private ComboBox IRFilterCB;
    }
}