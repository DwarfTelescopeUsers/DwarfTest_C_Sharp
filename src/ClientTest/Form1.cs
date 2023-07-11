using static ClientTest.ApiCaller;

namespace ClientTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            UpdateStatusBar();
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

        private async void ExposureCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoManual autoManual = AutoManual.Manual;
            if (ExposureCB.SelectedIndex == 0)
            {
                autoManual = AutoManual.Auto;
            }
            D2Message? message = await SetExposureMode(CameraId.Telephoto, autoManual);
        }

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