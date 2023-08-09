using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static ClientTest.ApiCaller;
using static ClientTest.Common;

namespace ClientTest
{
    public partial class Form1 : Form
    {
        private List<DSOData> _dsoList = new List<DSOData>();
        private DSOData _dso = new DSOData();

        public Form1()
        {
            InitializeComponent();
            CheckConfig();

            // UpdateStatusBar();
            // ToDo: Initialise UI based on existing camera settings
        }

        private void CheckConfig()
        {
            bool configured = false;
            ConfigData cnfigData = new ConfigData();
            (configured, cnfigData) = Common.CheckConfig();
            EnableDisableTabs(configured, cnfigData);
        }

        private void EnableDisableTabs(bool configured, ConfigData cnfigData)
        {
            TPTab.Enabled = configured;
            WATab.Enabled = configured;
            astroTab.Enabled = configured;

            if (configured)
            {
                ipTextBox.Text = cnfigData.IP;
                latitudeTB.Text = cnfigData.Latitude.ToString();
                longitudeTB.Text = cnfigData.Longitude.ToString();
            }
            else
            {
                MessageBox.Show("Complete Configuration Data to continue");
            }
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
        private async void TPExposureCB_SelectedIndexChanged(object sender, EventArgs e)
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

        #endregion

        #region Wide Angle Controls
        private async void WAExposureCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            double expValue = 0.0;
            AutoManual autoManual = AutoManual.Manual;
            if (WAExposureCB.SelectedIndex == 0)
            {
                autoManual = AutoManual.Auto;
                WAExposureGB.BackColor = Color.Lime;
            }
            else
            {
                expValue = (Double)CalculateExposureValue(WAExposureCB.Text);
                WAExposureGB.BackColor = Color.Transparent;

            }
            D2Message? message = await SetExposureMode(CameraId.WideAngle, autoManual);
            if (autoManual == AutoManual.Manual)
            {
                message = await (SetExposureValue(CameraId.WideAngle, expValue));
            }

        }

        private async void WAGainTB_ValueChanged(object sender, EventArgs e)
        {
            var gainValue = WAGainTB.Value;
            WAGainLabel.Text = gainValue.ToString();
            D2Message? message = await SetGainMode(CameraId.WideAngle, AutoManual.Manual);
            message = await SetGainValue(CameraId.WideAngle, gainValue);
        }
        #endregion

        #region Common to TP & WA
        public static void TrackBar_MouseDown(object sender, MouseEventArgs e)
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
                    case "WAGainTB":
                        {
                            value = 64;
                            break;
                        }
                }
                ((TrackBar)sender).Value = value;
            }
        }
        #endregion

        #region Dev
        private async void TPISPButton_Click(object sender, EventArgs e)
        {
            D2Message? message = await GetTelephotoWorkingState(CameraId.Telephoto);
            string val = "";
            if (message != null)
            {
                val = $"Exposure Mode: {message.ExpMode}{Environment.NewLine}";
                val += $"Exposure Value: {message.Exp}{Environment.NewLine}";
                val += $"Gain Mode: {message.GainMode}{Environment.NewLine}";
                val += $"Gain Value: {message.Gain}{Environment.NewLine}";
                val += $"White Balance Mode: {message.AwbMode}{Environment.NewLine}";
                val += $"White Balance Value: {message.AwbCT}{Environment.NewLine}";
                val += $"IR State: {message.IrState}{Environment.NewLine}";
                val += $"Preview: {message.Quality}{Environment.NewLine}";
                val += $"Brightness: {message.Brightness}{Environment.NewLine}";
                val += $"Contrast: {message.Contrast}{Environment.NewLine}";
                val += $"Hue: {message.Hue}{Environment.NewLine}";
                val += $"Saturation: {message.Saturation}{Environment.NewLine}";
                val += $"Sharpness: {message.Sharpness}{Environment.NewLine}";
            }
            else
            {
                val = "Message = null";
            }
            richTextBox1.Clear();
            richTextBox1.Text = val;
        }
        private async void WAISPButton_Click(object sender, EventArgs e)
        {
            D2Message? message = await GetWideangleIspParameter(CameraId.WideAngle);
            string val = "";
            if (message != null)
            {
                val = $"Exposure Mode: {message.ExpMode}{Environment.NewLine}";
                val += $"Exposure Value: {message.Exp}{Environment.NewLine}";
                val += $"Gain Value: {message.Gain}{Environment.NewLine}";
                val += $"White Balance Mode: {message.AwbMode}{Environment.NewLine}";
                val += $"White Balance Value: {message.AwbCT}{Environment.NewLine}";
                val += $"IR State: {message.IrState}{Environment.NewLine}";
                val += $"Brightness: {message.Brightness}{Environment.NewLine}";
                val += $"Contrast: {message.Contrast}{Environment.NewLine}";
                val += $"Hue: {message.Hue}{Environment.NewLine}";
                val += $"Saturation: {message.Saturation}{Environment.NewLine}";
                val += $"Sharpness: {message.Sharpness}{Environment.NewLine}";
            }
            else
            {
                val = "Message = null";
            }
            richTextBox1.Clear();
            richTextBox1.Text = val;
        }
        #endregion

        #region Setup
        private void enterLatButton_Click(object sender, EventArgs e)
        {
            var lat = ConvertLatitude(latitudeTB.Text);
            latitudeTB.Text = lat.ToString();
        }

        private void enterLonButton_Click(object sender, EventArgs e)
        {
            var lon = ConvertLongitude(longitudeTB.Text);
            longitudeTB.Text = lon.ToString();
        }

        private void saveDetailsButton_Click(object sender, EventArgs e)
        {
            Common.SaveConfig(latitudeTB.Text, longitudeTB.Text, ipTextBox.Text);
            CheckConfig();
        }
        #endregion

        private void ClearRTB(RichTextBox rtb)
        {
            rtb.Clear();
            rtb.Update();
        }

        private void ObjectTypeCB_TextChanged(object sender, EventArgs e)
        {
            ObjectLB.Items.Clear();
            _dsoList.Clear();
            ClearRTB(ObjectDescriptionRTB);
            switch (ObjectTypeCB.SelectedIndex)
            {
                case 0: // Dwarf 2 planet list
                    {

                        var planets = Enum.GetValues(typeof(Planets))
                                    .Cast<Planets>()
                                    .ToList();

                        foreach (var planet in planets)
                        {
                            ObjectLB.Items.Add(planet);
                        }
                        break;
                    }
                case 1: // Messier objects from spreadsheet
                    {
                        _dsoList = ReadDSOData("Messier");
                        foreach (DSOData dso in _dsoList)
                        {
                            ObjectLB.Items.Add(dso.Name);
                        }
                        break;
                    }


            }
        }

        private void ObjectLB_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearRTB(ObjectDescriptionRTB);
            var selItem = ((ListBox)sender).SelectedItem.ToString();
            var dso = _dsoList.Where(n => (n.Name.ToString() == selItem));
            _dso = dso.First();
            ObjectDescriptionRTB.Text = _dso.Description;
        }
    }
}