using static ClientTest.ApiCaller;

namespace ClientTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            UpdateStatusBar();
            UpdateTPData();
        }

        private async void UpdateTPData()
        {
            var response = await GetTelephotoIspParameters(CameraId.Telephoto);
            if (response != null)
            {
                // Exposure
                var exposure = response.Exp == null ? 0 : response.Exp;
                var floatValue = response.ExpMode == (int)AutoManual.Manual ? exposure : -1;
                for (var idx = 0; idx < TPExposureValues.Count(); idx++)
                {
                    var expected = (double)TPExposureValues[idx];
                    if ((expected * 0.9) < floatValue && floatValue < (expected * 1.1))
                        TPExposureCB.SelectedIndex = idx;
                }

                // Gain
                floatValue = response.Gain == null ? 0 : response.Gain;
                if (TPGainTB.Value != floatValue)
                {
                    TPGainTB.Value = (int)(response.GainMode == (int)GainMode.Auto ? floatValue : -1);
                }

                // Brightness
                var intValue = response.Brightness == null ? 128 : response.Brightness;
                if (TPBrightnessTB.Value != intValue)
                {
                    TPBrightnessTB.Value = (int)intValue;
                }

                // Hue
                intValue = response.Hue == null ? 180 : response.Hue;
                if (TPBrightnessTB.Value != intValue)
                {
                    TPHueTB.Value = (int)intValue;
                }

                // Contrast
                intValue = response.Contrast == null ? 128 : response.Contrast;
                if (TPContrastTB.Value != intValue)
                {
                    TPContrastTB.Value = (int)intValue;
                }

                // Saturation
                intValue = response.Saturation == null ? 50 : response.Saturation;
                if (TPSaturationTB.Value != intValue)
                {
                    TPSaturationTB.Value = (int)intValue;
                }

                // Sharpness
                intValue = response.Sharpness == null ? 50 : response.Sharpness;
                if (TPSharpnessTB.Value != intValue)
                {
                    TPSharpnessTB.Value = (int)intValue;
                }


            }
        }

        private async void BtnWAOn_Click(object sender, EventArgs e)
        {
            var response = await TurnOnCamera(CameraId.WideAngle, Binning.Binning1x1);
            BtnWAOn.BackColor = Color.LimeGreen;
            BtnTPOn.BackColor = Color.Transparent;
            Uri uri = new Uri("http://192.168.0.67:8092/thirdstream");
            vlcControl.Play(uri);
        }

        private async void BtnWAOff_Click(object sender, EventArgs e)
        {
            var response = await TurnOffCamera(CameraId.WideAngle);
            BtnWAOn.BackColor = Color.Transparent;
        }

        private async void BtnTPOn_Click(object sender, EventArgs e)
        {
            var response = await TurnOnCamera(CameraId.Telephoto, Binning.Binning2x2);
            BtnWAOn.BackColor = Color.Transparent;
            BtnTPOn.BackColor = Color.LimeGreen;
            Uri uri = new Uri("http://192.168.0.67:8092/mainstream");
            vlcControl.Play(uri);
        }

        private async void BtnTPOff_Click(object sender, EventArgs e)
        {
            var response = await TurnOffCamera(CameraId.Telephoto);
            BtnTPOn.BackColor = Color.Transparent;
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

        #region TP Settings
        // TP Exposure value changes. Right mouse sets 'Auto'

        private void TPExposureCB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TPExposureCB.SelectedIndex = 0;  // Reset to 'Auto'
                TPExposureGB.BackColor = Color.LimeGreen;
            }
        }

        private async void TPExposureCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TPExposureCB.SelectedIndex == 0)
            {
                TPExposureGB.BackColor = Color.LimeGreen;
                await SetExposureMode(CameraId.Telephoto, AutoManual.Auto);
            }
            else
            {
                TPExposureGB.BackColor = Color.Transparent;
                var value = (double)TPExposureValues[TPExposureCB.SelectedIndex];
                await SetExposureMode(CameraId.Telephoto, AutoManual.Manual);
                await SetExposureValue(CameraId.Telephoto, value);
            }
        }

        // TP Gain Changes. Right click sets 'Auto'
        private void TPGainTB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TPGainTB.Value = -1;  // Reset to 'Auto'
                TPGainGB.BackColor = Color.LimeGreen;
            }
        }

        private async void TPGainTB_ValueChanged(object sender, EventArgs e)
        {
            if (TPGainTB.Value == -1)
            {
                TPGainGB.BackColor = Color.LimeGreen;
                await SetGainMode(CameraId.Telephoto, AutoManual.Auto);
            }
            else
            {
                TPGainGB.BackColor = Color.Transparent;
                await SetGainMode(CameraId.Telephoto, AutoManual.Manual);
                await SetGainValue(CameraId.Telephoto, TPGainTB.Value);
            }
        }

        // Brightness value changes. Right click performs 'reset' (Value = 128)
        private async void TPBrightnessTB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TPBrightnessTB.Value = 128;
                await SetBrightnessValue(CameraId.Telephoto, TPBrightnessTB.Value);
            }
        }

        private async void TPBrightnessTB_ValueChanged(object sender, EventArgs e)
        {
            await SetBrightnessValue(CameraId.Telephoto, TPBrightnessTB.Value);
        }

        // Contrast value changes. Right mouse performs 'reset' (Value = 50)
        private async void TPContrastTB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TPContrastTB.Value = 50;
                await SetContrastValue(CameraId.Telephoto,TPContrastTB.Value);
            }
        }

        private async void TPContrastTB_ValueChanged(object sender, EventArgs e)
        {
            await SetContrastValue(CameraId.Telephoto, TPContrastTB.Value);
        }
        #endregion

        private void CamControlGB_TabIndexChanged(object sender, EventArgs e)
        {
            UpdateTPData();
        }


    }
}
