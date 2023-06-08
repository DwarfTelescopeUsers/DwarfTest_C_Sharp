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
            ExposureGB = new GroupBox();
            ExposureCB = new ComboBox();
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
            groupBox2 = new GroupBox();
            comboBox1 = new ComboBox();
            CamControlGB.SuspendLayout();
            TPTab.SuspendLayout();
            ExposureGB.SuspendLayout();
            WATab.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vlcControl).BeginInit();
            statusStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            // 
            // TPTab
            // 
            TPTab.Controls.Add(ExposureGB);
            TPTab.Location = new Point(4, 24);
            TPTab.Name = "TPTab";
            TPTab.Padding = new Padding(3);
            TPTab.Size = new Size(610, 500);
            TPTab.TabIndex = 0;
            TPTab.Text = "Telephoto Settings";
            TPTab.UseVisualStyleBackColor = true;
            // 
            // ExposureGB
            // 
            ExposureGB.Controls.Add(ExposureCB);
            ExposureGB.Location = new Point(6, 6);
            ExposureGB.Name = "ExposureGB";
            ExposureGB.Size = new Size(125, 62);
            ExposureGB.TabIndex = 1;
            ExposureGB.TabStop = false;
            ExposureGB.Text = "Exposure (s)";
            // 
            // ExposureCB
            // 
            ExposureCB.FormattingEnabled = true;
            ExposureCB.Items.AddRange(new object[] { "Auto", "1/10000", "1/8000", "1/6400", "1/5000", "1/4000", "1/3200", "1/2500", "1/1600", "1/1250", "1/1000", "1/800", "1/640", "1/500", "1/400", "1/320", "1/250", "1/160", "1/125", "1/100", "1/80", "1/60", "1/50", "1/40", "1/30", "1/20", "1/15", "1/13", "1/10", "1/8", "1/6", "1/5", "1/4", "1/3", "0.4", "0.5", "0.6", "0.8", "1", "1.3", "1.6", "2", "2.5", "3.2", "4", "5", "6", "8", "10", "13", "15" });
            ExposureCB.Location = new Point(6, 22);
            ExposureCB.Name = "ExposureCB";
            ExposureCB.Size = new Size(108, 23);
            ExposureCB.TabIndex = 0;
            ExposureCB.SelectedIndexChanged += ExposureCB_SelectedIndexChanged;
            // 
            // WATab
            // 
            WATab.Controls.Add(groupBox2);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Location = new Point(6, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(125, 62);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Exposure (s)";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Auto", "1/10000", "1/8000", "1/6400", "1/5000", "1/4000", "1/3200", "1/2500", "1/1600", "1/1250", "1/1000", "1/800", "1/640", "1/500", "1/400", "1/320", "1/250", "1/160", "1/125", "1/100", "1/80", "1/60", "1/50", "1/40", "1/30", "1/20", "1/15", "1/13", "1/10", "1/8", "1/6", "1/5", "1/4", "1/3", "0.4", "0.5", "0.6", "0.8", "1", "1.3", "1.6", "2", "2.5", "3.2", "4", "5", "6", "8", "10", "13", "15" });
            comboBox1.Location = new Point(6, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(108, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            ExposureGB.ResumeLayout(false);
            WATab.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)vlcControl).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
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
        private GroupBox ExposureGB;
        private ComboBox ExposureCB;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripFirmwareLabel1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar toolStripPowerPB;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripProgressBar toolStripSDCardPB;
        private System.Windows.Forms.Timer StatusBarTimer;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
    }
}