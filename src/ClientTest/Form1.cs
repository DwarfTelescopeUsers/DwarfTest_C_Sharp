using System.Windows.Forms.VisualStyles;
using static ClientTest.ApiCaller;
using static ClientTest.Telephoto;

namespace ClientTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            UpdateStatusBar();
            // ToDo: Initialise UI based on existing camera settings
        }

        private async void BtnWAOn_Click(object sender, EventArgs e)
        {
            var response = await TurnOnCamera(CameraId.WideAngle, Binning.Binning1x1);
            BtnWAOn.BackColor = Color.LimeGreen;
            BtnTPOn.BackColor = Color.Transparent;
            Uri uri = new Uri(vlcWAUri);
            vlcControl.Play(uri);
        }

        private async void BtnWAOff_Click(object sender, EventArgs e)
        {
            var response = await TurnOffCamera(CameraId.WideAngle);
            BtnWAOn.BackColor = Color.Transparent;
            vlcControl.Stop();
        }

        private async void BtnTPOn_Click(object sender, EventArgs e)
        {
            var response = await TurnOnCamera(CameraId.Telephoto, Binning.Binning2x2);
            BtnWAOn.BackColor = Color.Transparent;
            BtnTPOn.BackColor = Color.LimeGreen;
            Uri uri = new Uri(vlcTPUri);
            vlcControl.Play(uri);
        }

        private async void BtnTPOff_Click(object sender, EventArgs e)
        {
            var response = await TurnOffCamera(CameraId.Telephoto);
            BtnTPOn.BackColor = Color.Transparent;
            vlcControl.Stop();
        }

        private async void BtnRotateAnti_Click(object sender, EventArgs e)
        {
            await RotateMotor(MotorId.Spin, MotorDirection.ACW_Up);
        }

        private async void BtnRotateClock_Click(object sender, EventArgs e)
        {
            await RotateMotor(MotorId.Spin, MotorDirection.CW_Down);
        }
        private async void BtnRotateUp_Click(object sender, EventArgs e)
        {
            await RotateMotor(MotorId.Pitch, MotorDirection.ACW_Up);
        }

        private async void BtnRotateDown_Click(object sender, EventArgs e)
        {
            await RotateMotor(MotorId.Pitch, MotorDirection.CW_Down);
        }

        private async void BtnStop_Click(object sender, EventArgs e)
        {
            await StopSpin(MotorId.Spin);
            await StopSpin(MotorId.Pitch);
        }

        private async void UpdateStatusBar()
        {
            var response = await GetDwarfSoftwareVersionNumberCmd();
            if (!(response == null) && !(response.Version == null))
            {
                toolStripFirmwareLabel1.Text = $"Firmware Version: {response.Version}";
            }
            response = await PowerAcquisition();
            if (!(response == null) && !(response.Value == null))
            {
                toolStripPowerPB.Value = (int)response.Value;
                toolStripPowerPB.ToolTipText = $"Power: {response.Value}%";
            }
            response = await MicrosdStatus();
            if (!(response == null) && !(response.Size == null) && !(response.Avail == null))
            {
                var avail = (int)response.Avail;
                var size = (int)response.Size;
                float pcnt = 100 * (avail / size);
                toolStripSDCardPB.Value = (int)pcnt;
                toolStripSDCardPB.ToolTipText = $"Available: {avail}Gb, Size: {size}Gb";
            }
        }
        private void StatusBarTimer_Tick(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void vlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(".", "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        #region Telephoto Controls
        private async void ExposureCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            double expValue = 0.0;
            AutoManual autoManual = AutoManual.Manual;
            if (TPExposureCB.SelectedIndex == 0)
            {
                autoManual = AutoManual.Auto;
                TPExposureGB.BackColor = Color.Lime;
            }
            else
            {
                expValue = (Double)CalculateExposureValue(TPExposureCB.Text);
                TPExposureGB.BackColor = Color.Transparent;

            }

            D2Message? message = await SetExposureMode(CameraId.Telephoto, autoManual);
            if (autoManual == AutoManual.Manual)
            {
                message = await (SetExposureValue(CameraId.Telephoto, expValue));
            }
        }

        private async void TPGainCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gainValue = 0;
            AutoManual autoManual = AutoManual.Manual;
            if (TPGainCB.SelectedIndex == 0)
            {
                autoManual = AutoManual.Auto;
                TPGainGB.BackColor = Color.Lime;
            }
            else
            {
                gainValue = Convert.ToInt16(TPGainCB.Text);
                TPGainGB.BackColor = Color.Transparent;

            }

            D2Message? message = await SetGainMode(CameraId.Telephoto, autoManual);
            if (autoManual == AutoManual.Manual)
            {
                message = await SetGainValue(CameraId.Telephoto, gainValue);
            }
        }

        private async void TPIRCutRB_Click(object sender, EventArgs e)
        {
            TPIRPassRB.Checked = false;
            TPIRCutRB.Checked = true;
            D2Message? message = await SetIRCut(CameraId.Telephoto, IRCut.IRCut);
        }

        private async void TPIRPassRB_Click(object sender, EventArgs e)
        {
            TPIRPassRB.Checked = true;
            TPIRCutRB.Checked = false;
            D2Message? message = await SetIRCut(CameraId.Telephoto, IRCut.IRPass);
        }

        private async void TPBrightnessTB_ValueChanged(object sender, EventArgs e)
        {
            var value = TPBrightnessTB.Value;
            TPBrightnessLabel.Text = value.ToString();
            // Input values 0 - 100. Actual values sent 0 - 255
            value = (int)(value * 2.55);
            D2Message? message = await SetBrightnessValue(CameraId.Telephoto, value);
        }

        private async void TPContrastTB_ValueChanged(object sender, EventArgs e)
        {
            var value = TPContrastTB.Value;
            TPContrastLabel.Text = value.ToString();
            // Input values 0 - 100. Actual values sent 0 - 255
            value = (int)(value * 2.55);
            D2Message? message = await SetContrastValue(CameraId.Telephoto, value);
        }

        private async void TPSaturationTB_ValueChanged(object sender, EventArgs e)
        {
            var value = TPSaturationTB.Value;
            TPSaturationLabel.Text = value.ToString();
            // Input values 0 - 100. Actual values sent 0 - 255
            value = (int)(value * 2.55);
            D2Message? message = await SetSaturationValue(CameraId.Telephoto, value);
        }

        private async void TPHueTB_ValueChanged(object sender, EventArgs e)
        {
            var value = TPHueTB.Value;
            TPHueLabel.Text = value.ToString();
            // Input values 0 - 360.
            D2Message? message = await SetHueValue(CameraId.Telephoto, value);
        }

        private async void TPSharpnessTB_ValueChanged(object sender, EventArgs e)
        {
            var value = TPSharpnessTB.Value;
            TPSharpnessLabel.Text = value.ToString();
            // Input values 0 - 100.
            D2Message? message = await SetSharpnessValue(CameraId.Telephoto, value);
        }

        private void TPPreviewTB_ValueChanged(object sender, EventArgs e)
        {
            // ToDo: Add functionality once API is updated
        }

        private void TPTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            // Right click on the control acts a Reset
            if (e.Button == MouseButtons.Right)
            {
                int value = 0;
                switch (((TrackBar)sender).Name)
                {
                    case "TPBrightnessTB":
                    case "TPContrastTB":
                    case "TPSaturationTB":
                    case "TPSharpnessTB":
                        {
                            value = 50;
                            break;
                        }
                    case "TPHueTB":
                        {
                            value = 180;
                            break;
                        }
                }
                ((TrackBar)sender).Value = value;
            }
        }

        #endregion

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoManual autoManual = AutoManual.Manual;
            if (comboBox1.SelectedIndex == 0)
            {
                autoManual = (AutoManual)3;
            }
            D2Message? message = await SetExposureMode(CameraId.WideAngle, autoManual);
        }

        
    }
}
//this.vlcControl