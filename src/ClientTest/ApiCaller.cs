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
        public enum CameraId
        {
            Telephoto = 0,
            WideAngle = 1
        }

        public enum ShotMode
        {
            Single = 0,
            Continuous = 1
        }

        private const int autofocusGlobal = 0;
        private const int autofocusArea = 1;

        private const int IRCut = 0;
        private const int IRPass = 3;

        // goto
        public enum Planets
        {
            Mercury = 0,
            Venus = 1,
            Mars = 2,
            Jupiter = 3,
            Saturn = 4,
            Uranus = 5,
            Neptune = 6,
            Moon = 7
        }


        // RAW astro photo
        private const int binning1x1 = 0;
        private const int binning2x2 = 1;
        private const int fileFits = 0;
        private const int fileTiff = 1;

        // raw preview
        private const int rawPreviewContinousSuperimpose = 0;
        private const int rawPreviewSingle15 = 1;
        private const int rawPreviewSingleComposite = 2;


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
                Interface = CommandOpcodes.TurnOnCameraCmd,
                CamId = (int)cameraId
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task TurnOffCamera(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOffCameraCmd,
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
                Interface = CommandOpcodes.TakePhotoCmd,
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
                Interface = CommandOpcodes.StartRecordingCmd,
                CamId = (int)cameraId,
                Name = $"DwarfTest-Video-{DateTime.Now}"
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StopRecording(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopRecordingCmd,
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
                Interface = CommandOpcodes.SetBrightnessValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetContrastValue()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetContrastValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetSaturationValue()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSaturationValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }
        public static async Task SetHueValue()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetHueValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetSharpnessValue()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSharpnessValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetExposureMode()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetExposureModeCmd,
                CamId = 0,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetExposureValue()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetExposureValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetGainMode()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetGainModeCmd,
                CamId = 0,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetGainValue()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetGainValueCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StartAutoFocus()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartAutofocusCmd,
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
                Interface = CommandOpcodes.SetWhiteBalanceModeCmd,
                CamId = 0,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetWhiteBalanceScene()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetWhiteBalanceSceneCmd,
                CamId = 0,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetWhiteBalanceColor()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetWhiteBalanceColorTemperatureCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetIRCut()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        // -----------------
        public static async Task SendIRTelephotoStatusCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendWorkingStateTelephotoCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendWideangleCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendSetupGotoCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendStartGotoCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendTakeAstroPhotoCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendStopAstroPhotoCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendTakeAstroDarkFramesCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendQueryShotFieldCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendTraceInitCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendStartTrackingCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendStopTrackingCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendStartPanoCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendStopPanoCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendStartMotionCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendStopMotionCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendSetSpeedCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendSetDirectionCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendSetSubdivideCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendSystemStatusCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendMicrosdStatusCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendMicrosdAvailableCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendDwarfSoftwareVersionCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task SendDwarfChargingStatusCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = 0,
                Value = 50
            };
            await SendMessage(d2Message);
        }
       //---------------------
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
