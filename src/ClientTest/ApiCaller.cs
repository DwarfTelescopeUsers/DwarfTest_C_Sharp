using ClientTest.Models;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClientTest
{
    internal class ApiCaller
    {
        // ===============
        // 3.1 image transmission
        // ===============

        // camera
        private const int turnOnCameraCmd = 10000;
        private const int turnOffCameraCmd = 10017;
        public enum CameraId
        {
            Telephoto = 0,
            WideAngle = 1
        }

        // ===============
        // 3.2 photo and video
        // ===============

        // photo
        private const int takePhotoCmd = 10006;
        public enum ShotMode
        {
            Single = 0,
            Continuous = 1
        }

        // video
        private const int startRecordingCmd = 10007;
        private const int stopRecordingCmd = 10009;

        // timelapse photos
        private const int startTimelapseCmd = 10018;
        private const int stopTimelapseCmd = 10019;

        // ===============
        // 3.3 Adjust ISP parameters
        // ===============

        // brightness
        private const int setBrightnessValueCmd = 10204;

        // contrast
        private const int setContrastValueCmd = 10205;

        // saturation
        private const int setSaturationValueCmd = 10206;

        // hue
        private const int setHueValueCmd = 10207;

        // sharpness
        private const int setSharpnessValueCmd = 10208;

        // exposure
        private const int setExposureModeCmd = 10001;
        private const int setExposureValueCmd = 10003;

        // gain
        private const int setGainModeCmd = 10004;
        private const int setGainValueCmd = 10005;

        // autofocus
        private const int startAutofocusCmd = 10211;
        private const int autofocusGlobal = 0;
        private const int autofocusArea = 1;

        // white balance
        private const int setWhiteBalanceModeCmd = 10212;
        private const int setWhiteBalanceSceneCmd = 10213;
        private const int setWhiteBalanceColorTemperatureCmd = 10214;

        // IR
        private const int setIRCutCmd = 10203;
        private const int IRCut = 0;
        private const int IRPass = 3;

        // ===============
        // 3.4 status
        // ===============

        // telephoto
        private const int statusTelephotoCmd = 10215;
        private const int statusIRTelephotoCmd = 10216;
        private const int statusWorkingStateTelephotoCmd = 10022;

        // wideangle
        private const int statusWideangleCmd = 10217;

        // ===============
        // 4.1 Astro
        // ===============

        // goto
        private const int setupGotoCmd = 11205;
        private const int startGotoCmd = 11203;
        private const int Mercury = 0;
        private const int Venus = 1;
        private const int Mars = 2;
        private const int Jupiter = 3;
        private const int Saturn = 4;
        private const int Uranus = 5;
        private const int Neptune = 6;
        private const int Moon = 7;

        // RAW astro photo
        private const int takeAstroPhotoCmd = 10011;
        private const int stopAstroPhotoCmd = 10015;
        private const int binning1x1 = 0;
        private const int binning2x2 = 1;
        private const int fileFits = 0;
        private const int fileTiff = 1;

        // raw preview
        private const int setRawPreviewCmd = 10020;
        private const int rawPreviewContinousSuperimpose = 0;
        private const int rawPreviewSingle15 = 1;
        private const int rawPreviewSingleComposite = 2;

        // astro dark frames
        private const int takeAstroDarkFramesCmd = 10026;

        // query shot field
        private const int queryShotFieldCmd = 10026;

        // ===============
        // 4.2 tracking
        // ===============

        private const int traceInitCmd = 11200;
        private const int startTrackingCmd = 11201;
        private const int stopTrackingCmd = 11202;

        // ===============
        // 4.3 panoromic
        // ===============

        private const int startPanoCmd = 10103;
        private const int stopPanoCmd = 10106;

        // ===============
        // 5 motion control
        // ===============

        private const int startMotionCmd = 10100;
        private const int stopMotionCmd = 10101;
        private const int setSpeedCmd = 10107;
        private const int setDirectionCmd = 10108;
        private const int setSubdivideCmd = 10109;

        // ===============
        // 7.1 system status
        // ===============

        private const int systemStatusCmd = 11407;

        // ===============
        // 7.2 microsd card status
        // ===============

        private const int microsdStatusCmd = 11405;
        private const int microsdAvailableCmd = 11409;

        // ===============
        // 7.4 dwarf status
        // ===============

        private const int dwarfSoftwareVersionCmd = 11410;
        private const int dwarfChargingStatusCmd = 11011;

        // "wss://localhost:7122/ws"
        private static readonly string uri = "ws://192.168.1.162:9900";

        private static readonly JsonSerializerOptions jsoptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // ===============
        // 3.1 image transmission
        // ===============
        public static async Task TurnOnCamera(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = turnOnCameraCmd,
                CamId = (int)cameraId
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task TurnOffCamera(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = turnOffCameraCmd,
                CamId = (int)cameraId
            };

            D2Message? response = await SendMessage(d2Message);
        }

        // ===============
        // 3.2 photo and video
        // ===============
        //TODO: write these mwthods

        public static async Task TakePhoto(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = takePhotoCmd,
                CamId = (int)cameraId,
                Mode = 0,
                Count = 1,
                Name = $"DwarfTest-Photo-{DateTime.Now}"
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StartRecording(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = startRecordingCmd,
                CamId = (int)cameraId,
                Name = $"DwarfTest-Video-{DateTime.Now}"
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StopRecording(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = stopRecordingCmd,
                CamId = (int)cameraId
            };

            D2Message? response = await SendMessage(d2Message);
        }

        // ===============
        // 3.3 Adjust ISP parameters
        // ===============

        public static async Task SetBrightnessValue()
        {
            D2Message d2Message = new()
            {
                Interface = setBrightnessValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetContrastValue()
        {
            D2Message d2Message = new()
            {
                Interface = setContrastValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetSaturationValue()
        {
            D2Message d2Message = new()
            {
                Interface = setSaturationValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }
        public static async Task SetHueValue()
        {
            D2Message d2Message = new()
            {
                Interface = setHueValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetSharpnessValue()
        {
            D2Message d2Message = new()
            {
                Interface = setSharpnessValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetExposureMode()
        {
            D2Message d2Message = new()
            {
                Interface = setExposureModeCmd,
                CamId = 0,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetExposureValue()
        {
            D2Message d2Message = new()
            {
                Interface = setExposureValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetGainMode()
        {
            D2Message d2Message = new()
            {
                Interface = setGainModeCmd,
                CamId = 0,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetGainValue()
        {
            D2Message d2Message = new()
            {
                Interface = setGainValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StartAutoFocus()
        {
            D2Message d2Message = new()
            {
                Interface = startAutofocusCmd,
                CamId = 0,
                Mode = 0,
                CenterX = 0,
                CenterY = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetWhiteBalanceMode()
        {
            D2Message d2Message = new()
            {
                Interface = setWhiteBalanceModeCmd,
                CamId = 0,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetWhiteBalanceScene()
        {
            D2Message d2Message = new()
            {
                Interface = setWhiteBalanceSceneCmd,
                CamId = 0,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetWhiteBalanceColor()
        {
            D2Message d2Message = new()
            {
                Interface = setWhiteBalanceColorTemperatureCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetIRCut()
        {
            D2Message d2Message = new()
            {
                Interface = setIRCutCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }





        public static async Task RotateAnticlockwise()
        {
            D2Message d2Message = new()
            {
                Interface = 10100,
                Id = 1,
                Mode = 1,
                MStep = 1,
                Speed = 1000,
                Direction = 0, // Anti-clockwise
                Pulse = 2,
                AccelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StopSpin()
        {
            D2Message d2Message = new()
            {
                Interface = 10101,
                Id = 1,
                DecelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task RotateClockwise()
        {
            D2Message d2Message = new()
            {
                Interface = 10100,
                Id = 1,
                Mode = 1,
                MStep = 1,
                Speed = 1000,
                Direction = 1, // Clockwise
                Pulse = 2,
                AccelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
        }




        public static async Task<D2Message?> SendMessage(D2Message d2Message)
        {
            try
            {
                string sendMessage = JsonSerializer.Serialize(d2Message, jsoptions);
                Debug.WriteLine($"Send message: {sendMessage}");

                using ClientWebSocket webSocket = new();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);

                byte[] sendBuffer = Encoding.UTF8.GetBytes(sendMessage);
                await webSocket.SendAsync(new ArraySegment<byte>(sendBuffer), WebSocketMessageType.Text, true, CancellationToken.None);

                byte[] receiveBuffer = new byte[1024];
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
                Debug.WriteLine($"Received message: {receivedMessage}");

                var receiveD2Message = JsonSerializer.Deserialize<D2Message>(receivedMessage, jsoptions);
                return receiveD2Message;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex}");
                return null;
            }
        }
    }
}
