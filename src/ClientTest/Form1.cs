using static ClientTest.ApiCaller;

namespace ClientTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnPowerOn_Click(object sender, EventArgs e)
        {
            var response = await TurnOnCamera(CameraId.WideAngle, Binning.Binning1x1);
        }

        private async void BtnPowerOff_Click(object sender, EventArgs e)
        {
            var response = await TurnOffCamera(CameraId.WideAngle);
        }

        private async void BtnRotateAnti_Click(object sender, EventArgs e)
        {
            await RotateAnticlockwise();
        }

        private async void BtnStop1_Click(object sender, EventArgs e)
        {
            await StopSpin();
        }

        private async void BtnRotateClock_Click(object sender, EventArgs e)
        {
            await RotateClockwise();
        }
    }
}